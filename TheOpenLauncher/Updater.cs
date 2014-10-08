using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using TheOpenLauncher.Properties;
using System.Linq;

namespace TheOpenLauncher {
    public class Updater {
        public class ProgressChangedEventArgs : EventArgs
        {
    	    public int PercentageDone;
            public String CurrentAction;

            public ProgressChangedEventArgs(int percentageDone, string currentAction)
    	    {
                this.PercentageDone = percentageDone;
                this.CurrentAction = currentAction;
    	    }
        }

        public delegate void ProgressChangedEventHandler(object source, ProgressChangedEventArgs e);
        public event ProgressChangedEventHandler ProgressChanged;

        private AppInfoHelper appInfoHelper = new AppInfoHelper();
        private UpdateInfoHelper updateInfoHelper = new UpdateInfoHelper();
        private WebClient fileDownloader = new WebClient();

        public void RetrieveAppInfo(Action<AppInfo, UpdateHost> callback) {
            appInfoHelper.RetrieveAppInfo(callback);
        }

        public void RetrieveUpdateInfo(AppInfo appInfo, UpdateHost appInfoSource, double version, Action<UpdateInfo, UpdateHost> callback) {
            updateInfoHelper.RetrieveUpdateInfo(appInfo, appInfoSource, version, callback);
        }

        public void RetrieveUpdateInfos(AppInfo appInfo, UpdateHost appInfoSource, double[] version, Action<UpdateInfo, UpdateHost, int> callback) {
            updateInfoHelper.RetrieveUpdateInfos(appInfo, appInfoSource, version, callback);
        }

        public void ApplyUpdate(AppInfo appInfo, UpdateInfo info, UpdateHost updateInfoSource) {
            string lockFile = InstallationSettings.InstallationFolder + "/Updater.lock";
            if (File.Exists(lockFile)) {
                throw new Exception("Could not update: the application folder is already locked by another updater instance.");
            } else {
                File.Create(lockFile).Close();
            }
            
            FileIndex index = FileIndex.Deserialize(InstallationSettings.InstallationFolder + "/UpdateIndex.dat");

            //Update/delete existing files
            for(int i = 0;i<index.files.Count;i++) {
                ProgressChangedEventHandler eventDelegate = ProgressChanged;
                if (eventDelegate != null) {
                    int percentageDone = (int)( (((double)i / (double)index.files.Count) / 2d) * 100d );
                    eventDelegate(this, new ProgressChangedEventArgs(percentageDone, "Updating existing files"));
                }

                string curFile = index.files[i];
                string curLocalFile = InstallationSettings.InstallationFolder + '/' + curFile;

                if (info.fileChecksums.ContainsKey(curFile)) {
                    if (File.Exists(curLocalFile)) {
                        string curHash = FileHasher.GetFileChecksum(curLocalFile);
                        string updatedHash;
                        info.fileChecksums.TryGetValue(curFile, out updatedHash);

                        if (!curHash.Equals(updatedHash)) {
                            File.Delete(curLocalFile);
                            fileDownloader.DownloadFile(updateInfoSource.GetFileURL(appInfo, info, curFile), curLocalFile);
                        }
                    } else {
                        Directory.GetParent(curLocalFile).Create();
                        fileDownloader.DownloadFile(updateInfoSource.GetFileURL(appInfo, info, curFile), curLocalFile);
                    }
                } else {
                    File.Delete(curLocalFile);
                }
            }

            //Install new files
            for(int i = 0; i < info.fileChecksums.Keys.Count; i++){
                ProgressChangedEventHandler eventDelegate = ProgressChanged;
                if (eventDelegate != null) {
                    int percentageDone = Convert.ToInt32(((((double)i / (double)info.fileChecksums.Keys.Count) / 2d) * 100d) + 50d);
                    eventDelegate(this, new ProgressChangedEventArgs(percentageDone, "Installing new files"));
                }

                string curFile = info.fileChecksums.Keys.ElementAt(i);
                string curLocalFile = InstallationSettings.InstallationFolder + '/' + curFile;

                if(index.files.Contains(curFile)){
                    //Already handled file
                    continue;
                }

                if(File.Exists(curFile)){
                    //File exists but is missing in index?
                    string curHash = FileHasher.GetFileChecksum(curLocalFile);
                    string updatedHash;
                    info.fileChecksums.TryGetValue(curFile, out updatedHash);
                    if (updatedHash.Equals(curHash)) {
                        continue;
                    }
                }

                Directory.GetParent(curLocalFile).Create();
                fileDownloader.DownloadFile(updateInfoSource.GetFileURL(appInfo, info, curFile), curLocalFile);
            }

            index = new FileIndex(index.appID);
            index.applicationVersion = info.version;
            index.files.AddRange(info.fileChecksums.Keys);
            index.Serialize(InstallationSettings.InstallationFolder + "/UpdateIndex.dat");
            File.Delete(lockFile);
        }

        private class AppInfoHelper {
            private WebClient client = new WebClient();
            private List<Action<AppInfo, UpdateHost>> appInfoCallbacks = new List<Action<AppInfo, UpdateHost>>();

            public void RetrieveAppInfo(Action<AppInfo, UpdateHost> callback) {
                client.DownloadStringCompleted += client_DownloadStringCompleted;
                appInfoCallbacks.Add(callback);
                client.DownloadStringAsync(UpdateHost.GetUpdateHosts()[0].AppInfoURL, 0);
            }

            private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e) {
                if (e.Error != null) {
                    if (!TryNextURL((int)e.UserState)) {
                        InvokeUpdateInfoCallbacksAndClear(null, null);
                    }
                } else {
                    AppInfo info = AppInfo.FromJson(e.Result);
                    if (info == null) {
                        if (!TryNextURL((int)e.UserState)) {
                            InvokeUpdateInfoCallbacksAndClear(null, null);
                        }
                        return;
                    }

                    if (!LauncherSettings.AppID.Equals(info.appId)) {
                        MessageBox.Show("Invalid update mirror: appID does not match local value!", "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (!TryNextURL((int)e.UserState)) {
                            InvokeUpdateInfoCallbacksAndClear(null, null);
                        }
                        return;
                    }
                    InvokeUpdateInfoCallbacksAndClear(info, UpdateHost.GetUpdateHosts()[(int)e.UserState]);
                }
            }

            private void InvokeUpdateInfoCallbacksAndClear(AppInfo result, UpdateHost uri) {
                foreach (Action<AppInfo, UpdateHost> callback in appInfoCallbacks) {
                    callback.Invoke(result, uri);
                }
                appInfoCallbacks.Clear();
            }

            private bool TryNextURL(int currentIndex) {
                int nextIndex = (currentIndex) + 1;
                if (nextIndex < UpdateHost.GetUpdateHosts().Length) {
                    client.DownloadStringAsync(UpdateHost.GetUpdateHosts()[nextIndex].AppInfoURL, nextIndex);
                    return true;
                }
                return false;
            }
        }

        private class UpdateInfoHelper {
            private WebClient client = new WebClient();

            public UpdateInfoHelper() {
                client.DownloadStringCompleted += client_DownloadStringCompleted;
            }

            public void RetrieveUpdateInfo(AppInfo appInfo, UpdateHost appInfoSource, double version, Action<UpdateInfo, UpdateHost> callback) {
                if (client.IsBusy) {
                    throw new Exception("Cannot execute multiple updateinfo requests at once.");
                }
                client.DownloadStringAsync(appInfoSource.GetVersionInfoURL(appInfo, version), new UpdateInfoDownloadHelper(callback, appInfoSource, version ));
            }

            public void RetrieveUpdateInfos(AppInfo appInfo, UpdateHost appInfoSource, double[] versions, Action<UpdateInfo, UpdateHost, int> callback) {
                if (client.IsBusy) {
                    throw new Exception("Cannot execute multiple updateinfo requests at once.");
                }
                for (int i = 0; i < versions.Length;i++ ) {
                    WebClient curClient = new WebClient();
                    curClient.DownloadStringCompleted += client_DownloadStringCompleted;
                    curClient.DownloadStringAsync(appInfoSource.GetVersionInfoURL(appInfo, versions[i]), new UpdateInfoDownloadHelper(callback, appInfoSource, versions, i));
                }
            }

            private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e) {
                UpdateInfoDownloadHelper helper = (UpdateInfoDownloadHelper)e.UserState;

                if (e.Error != null) {
                    helper.InvokeCallback(null, null);
                } else {
                    UpdateInfo info = UpdateInfo.FromJson(e.Result);
                    if (info == null) {
                        helper.InvokeCallback(null, null);
                        return;
                    }
                    info.version = helper.Version;
                    helper.InvokeCallback(info, helper.appInfoSource);
                }
            }

            private class UpdateInfoDownloadHelper {
                public Action<UpdateInfo, UpdateHost> singleUpdateCallback;
                public Action<UpdateInfo, UpdateHost, int> multiUpdateCallback;
                public UpdateHost appInfoSource;
                public double[] versions;
                public int index;

                public UpdateInfoDownloadHelper(Action<UpdateInfo, UpdateHost> callback, UpdateHost appInfoSource, double version) {
                    this.singleUpdateCallback = callback;
                    this.appInfoSource = appInfoSource;
                    this.versions = new double[] { version };
                }

                public UpdateInfoDownloadHelper(Action<UpdateInfo, UpdateHost, int> callback, UpdateHost appInfoSource, double[] version, int i) {
                    this.multiUpdateCallback = callback;
                    this.appInfoSource = appInfoSource;
                    this.versions = version;
                    this.index = i;
                }

                public bool IsSingleUpdate{
                    get {
                        return singleUpdateCallback != null;
                    }
                }

                public double Version {
                    get {
                        return versions[index];
                    }
                }

                public void InvokeCallback(UpdateInfo info, UpdateHost source) {
                    if (IsSingleUpdate) {
                        singleUpdateCallback.Invoke(info, source);
                    } else {
                        multiUpdateCallback.Invoke(info, source, index);
                    }
                }
            }
        }
    }
}
