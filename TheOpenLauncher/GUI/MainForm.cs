using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TheOpenLauncher.Properties;

namespace TheOpenLauncher
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = LauncherLocale.Current.Get("Updater.Main.Title");
            progressLabel.Text = LauncherLocale.Current.Get("Updater.Main.CheckingForUpdates");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bool folderIsReady = true;
            
            string lockFile = InstallationSettings.InstallationFolder + "/Updater.lock";
            if(File.Exists(lockFile) && !File.ReadAllText(lockFile).Contains("Incomplete")){
                if (MessageBox.Show(this, "Another updater instance has locked the application directory. Force update?", "Updater already running", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes) {
                    File.Delete(lockFile);
                } else {
                    folderIsReady = false;
                }
            }

            if (folderIsReady) {
                new Thread(StartUpdateCheck).Start();
            } else {
                this.Close();
            }
        }

        private double[] GetUpdatedVersions(AppInfo info, double currentVersion, double targetVersion) {
            List<double> versions = new List<double>();
            foreach(double cur in info.versions){
                if(cur > currentVersion & cur <= targetVersion){
                    versions.Add(cur);
                }
            }
            return versions.ToArray();
        }

        private void StartUpdateCheck()
        {
            Updater updater = new Updater();
            updater.RetrieveAppInfo((appInfo, hostURL) =>
            {
                BeginInvoke((Action)(() => {
                    if (appInfo == null)
                    {
                        if (MessageBox.Show(this, "Cannot check for updates: No valid update mirrors online. Launch application anyway?", "Failed to check for updates", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).Equals(DialogResult.Yes))
                        {
                            Program.LaunchTargetApplication(this);
                        }
                        this.Close();
                        return;
                    }

                    FileIndex index = FileIndex.Deserialize(InstallationSettings.InstallationFolder+"/UpdateIndex.dat");
                    if (index.applicationVersion < appInfo.LatestVersion)
                    {
                        progressLabel.Text = LauncherLocale.Current.Get("Updater.Main.RetrievingUpdateInfo");

                        double[] newVersions = GetUpdatedVersions(appInfo, index.applicationVersion, appInfo.LatestVersion);
                        MetroForm form;
                        if (newVersions.Length == 1) {
                            form = new SingleUpdateDetailsForm(updater, appInfo, hostURL, newVersions[0]);
                        } else {
                            form = new MultiUpdateDetailsForm(updater, appInfo, hostURL, newVersions);
                        }
                        this.Hide();
                        form.ShowDialog();
                    }
                    progressLabel.Text = LauncherLocale.Current.Get("Updater.Main.LaunchApplication");
                    Program.LaunchTargetApplication(this);
                    this.Close();
                }));
            });
        }
    }
}
