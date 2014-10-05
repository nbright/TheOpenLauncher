using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using TheOpenLauncher.VersionPublisher.GUI;

namespace TheOpenLauncher.VersionPublisher {
    [Serializable]
    public class Project : ISerializable {
        public string Name = "";
        public string AppID = "";
        public string ProjectFolder;
        public Publisher publisher;
        public List<UpdateInfo> Updates;
        public UpdateInfo LatestVersion {
            get {
                UpdateInfo latest = null;
                foreach (UpdateInfo cur in Updates) {
                    if (latest == null || latest.version < cur.version) {
                        latest = cur;
                    }
                }
                return latest;
            }
        }

        public Project() { }
        private Project(SerializationInfo info, StreamingContext context) {
            Name = info.GetString("Name");
            AppID = info.GetString("AppID");
            ProjectFolder = info.GetString("ProjectFolder");
            publisher = (Publisher)info.GetValue("Publisher", typeof(Publisher));
            Updates = (List<UpdateInfo>)info.GetValue("Updates", typeof(List<UpdateInfo>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("Name", Name);
            info.AddValue("AppID", AppID);
            info.AddValue("ProjectFolder", ProjectFolder);
            info.AddValue("Publisher", publisher);
            info.AddValue("Updates", Updates);
        }

        public double[] GetVersionNumbers() {
            double[] result = new double[Updates.Count];
            for (int i = 0; i < Updates.Count; i++) {
                result[i] = Updates[i].version;
            }
            return result;
        }

        public void PublishUpdate(UpdateInfo update) {
            publisher.PublishUpdate(this, update);
            this.Updates.Add(update);
            Settings.Instance.Save();
        }

        private string AbsoluteToRelativePath(string basePath, string subfilePath) {
            if (!subfilePath.StartsWith(basePath)) {
                return null;
            } else {
                // The +1 is to avoid the directory separator
                return subfilePath.Substring(basePath.Length + 1);
            }
        }

        public void GetFilesDiffAsync(Action<List<FileDiffListItem>, Dictionary<String, String>> callback) {
            new Thread(() => { GetFilesDiff(callback); }).Start();
        }

        public void GetFilesDiff(Action<List<FileDiffListItem>, Dictionary<String, String>> callback) {
            UpdateInfo latestUpdate = LatestVersion;
            List<FileDiffListItem> diff = new List<FileDiffListItem>();
            Dictionary<String, String> items = new Dictionary<String, String>();

            foreach (string curFile in Directory.GetFiles(this.ProjectFolder, "*", SearchOption.AllDirectories)) {
                string curChecksum = FileHasher.GetFileChecksum(curFile);
                string curRelativePath = AbsoluteToRelativePath(this.ProjectFolder, curFile);
                items.Add(curRelativePath, curChecksum);

                if (latestUpdate != null) {
                    string baseCheckSum;
                    if (latestUpdate.fileChecksums.TryGetValue(curRelativePath, out baseCheckSum)) {
                        if (!baseCheckSum.Equals(curChecksum)) {
                            diff.Add(new FileDiffListItem(curRelativePath, FileDiffListItem.FileState.CHANGED));
                        }
                    } else {
                        diff.Add(new FileDiffListItem(curRelativePath, FileDiffListItem.FileState.ADDED));
                    }
                } else {
                    diff.Add(new FileDiffListItem(curRelativePath, FileDiffListItem.FileState.ADDED));
                }
            }

            if (latestUpdate != null) {
                foreach (KeyValuePair<string, string> cur in LatestVersion.fileChecksums) {
                    if (!File.Exists(ProjectFolder + "/" + cur.Key)) {
                        diff.Add(new FileDiffListItem(cur.Key, FileDiffListItem.FileState.REMOVED));
                    }
                }
            }

            callback.Invoke(diff, items);
        }
    }
}
