using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheOpenLauncher.VersionPublisher {
    [PublisherInfo(Name="Local disk", Description="Publish updates to your local computer.")]
    [Serializable]
    public class LocalDiskPublisher : Publisher{
        public String targetFolder;

        public LocalDiskPublisher() {
            
        }

        private LocalDiskPublisher(SerializationInfo info, StreamingContext context) {
            targetFolder = info.GetString("targetFolder");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("targetFolder", targetFolder);
        }

        public override string ToString() {
            return this.GetType().Name + "{ targetFolder = '" + targetFolder + "' }";
        }

        #region Publishing
        private void CopyAllInFolder(string sourceFolder, string destinationFolder) {
            DirectoryInfo source_dir = new DirectoryInfo(sourceFolder);
            DirectoryInfo dest_dir = new DirectoryInfo(destinationFolder);

            foreach (DirectoryInfo dir in source_dir.GetDirectories("*", SearchOption.AllDirectories)) {
                string newDir = Path.Combine(dest_dir.FullName, dir.FullName.Substring(source_dir.FullName.Length+1));
                Directory.CreateDirectory(newDir);
            }

            foreach (FileInfo file in source_dir.GetFiles("*", SearchOption.AllDirectories)) {
                string newFile = Path.Combine(dest_dir.FullName, file.FullName.Substring(source_dir.FullName.Length+1));
                file.CopyTo(newFile);
            }
        }

        public override void PublishUpdate(Project project, UpdateInfo newUpdate) {
            string updateVersion = VersionFormatter.ToString(newUpdate.version);

            AppInfo appInfo;
            string appInfoFile = Path.Combine(targetFolder, "appinfo.json");
            if (!File.Exists(appInfoFile)) {
                appInfo = new AppInfo();
                appInfo.appId = project.AppID;
                appInfo.versions = project.GetVersionNumbers();
                appInfo.downloadBaseDir = "versions";
                Directory.CreateDirectory(Path.Combine(targetFolder, "versions"));
                File.WriteAllText(appInfoFile, appInfo.ToJson());
            } else {
                appInfo = AppInfo.FromJson(File.ReadAllText(appInfoFile));
            }

            if (appInfo.versions.Contains(newUpdate.version)) {
                throw new PublishingFailedException("Version " + updateVersion + " already exists.");
            }

            string versionsFolder = Path.Combine(targetFolder, appInfo.downloadBaseDir);
            string newVersionFolder = Path.Combine(versionsFolder, updateVersion);
            string newVersionFilesFolder = Path.Combine(newVersionFolder, "dl");

            if (Directory.Exists(newVersionFolder)) {
                throw new PublishingFailedException("The destination folder for this version already exists!");
            } else {
                Directory.CreateDirectory(newVersionFilesFolder);
            }

            string infoFile = Path.Combine(newVersionFolder, "info.json");
            File.WriteAllText(infoFile, newUpdate.ToJson());

            CopyAllInFolder(project.ProjectFolder, newVersionFilesFolder);

            appInfo.versions = appInfo.versions.Concat(new double[] { newUpdate.version }).ToArray();
            File.WriteAllText(appInfoFile, appInfo.ToJson());
        } 
        #endregion

        #region GUI
        public override void SetupSettingsPanel(MetroPanel panel) {
            LocalDiskPublisherGUI gui = new LocalDiskPublisherGUI();
            gui.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Height = gui.Height;
            panel.Controls.Add(gui);
        }
        
        public override bool IsSettingsPanelComplete(MetroPanel panel) {
            string curFolder = ((LocalDiskPublisherGUI)panel.Controls[0]).folderTextBox.Text;
            return Directory.Exists(curFolder);
        }

        public override void ApplySettingsPanel(MetroPanel panel) {
            targetFolder = ((LocalDiskPublisherGUI)panel.Controls[0]).folderTextBox.Text;
        }
        #endregion
    }
}
