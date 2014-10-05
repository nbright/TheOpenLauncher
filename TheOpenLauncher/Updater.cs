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

        public void ApplyUpdate(AppInfo appInfo, UpdateInfo info, UpdateHost updateInfoSource) {
            FileIndex index = FileIndex.Deserialize(InstallationSettings.InstallationFolder + "/UpdateIndex.dat");
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
            private List<Action<UpdateInfo, UpdateHost>> updateInfoCallbacks = new List<Action<UpdateInfo, UpdateHost>>(); //TODO: list is messy solution, needs rewrite

            public void RetrieveUpdateInfo(AppInfo appInfo, UpdateHost appInfoSource, double version, Action<UpdateInfo, UpdateHost> callback) {
                client.DownloadStringCompleted += client_DownloadStringCompleted;
                updateInfoCallbacks.Add(callback);
                client.DownloadStringAsync(appInfoSource.GetVersionInfoURL(appInfo, version), new Object[] { appInfoSource, version });
            }

            private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e) {
                UpdateHost appInfoSource = (UpdateHost)((object[])e.UserState)[0];
                double version = (double)((object[])e.UserState)[1];

                if (e.Error != null) {
                    InvokeUpdateInfoCallbacksAndClear(null, null);
                } else {
                    UpdateInfo info = UpdateInfo.FromJson(e.Result);
                    if (info == null) {
                        InvokeUpdateInfoCallbacksAndClear(null, null);
                        return;
                    }
                    info.version = version;
                    InvokeUpdateInfoCallbacksAndClear(info, appInfoSource);
                }
            }

            private void InvokeUpdateInfoCallbacksAndClear(UpdateInfo result, UpdateHost uri) {
                foreach (Action<UpdateInfo, UpdateHost> callback in updateInfoCallbacks) {
                    callback.Invoke(result, uri);
                }
                updateInfoCallbacks.Clear();
            }
        }
    }
}
