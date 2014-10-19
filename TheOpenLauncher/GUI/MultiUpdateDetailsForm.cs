using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TheOpenLauncher.Properties;

namespace TheOpenLauncher
{
    public partial class MultiUpdateDetailsForm : MetroForm
    {
        private Updater updater;
        private AppInfo appInfo;
        private UpdateHost hostURL;
        private double[] targetVersions;
        private UpdateInfo[] updateInfos;

        public MultiUpdateDetailsForm(Updater updater, AppInfo appInfo, UpdateHost hostURL, double[] targetVersions) {
            this.updater = updater;
            this.appInfo = appInfo;
            this.hostURL = hostURL;
            this.targetVersions = targetVersions;
            updateInfos = new UpdateInfo[targetVersions.Length];
            InitializeComponent();

            this.Text = LauncherLocale.Current.Get("Updater.Multi.Title");
            infoLabel.Text = LauncherLocale.Current.Get("Updater.Multi.InfoLabel");
            updateNotesDropdownLabel.Text = LauncherLocale.Current.Get("Updater.Multi.NotesDropDownLabel");
            updateNotesComboBox.Items.AddRange(targetVersions.ToList().ConvertAll<string>(d => VersionFormatter.ToString(d)).ToArray());
            detailsTextBox.Text = LauncherLocale.Current.Get("Updater.Multi.NotesPlaceholder");
            cancelButton.Text = LauncherLocale.Current.Get("Updater.Multi.CancelButton");
            updateButton.Text = LauncherLocale.Current.Get("Updater.Multi.ApplyButton").Replace("${updateCount}", targetVersions.Length.ToString());
        }

        private void MultiUpdateDetailsForm_Load(object sender, EventArgs e) {
            updater.RetrieveUpdateInfos(appInfo, hostURL, targetVersions, (updateInfo, curUpdateHost, i) => {
                if (updateInfo == null) {
                    MessageBox.Show("No valid update info found.");
                    Application.Exit();
                    //TODO: Handle this. Should either search for new appInfo host or fail.
                }
                updateInfos[i] = updateInfo;
                OnUpdateInfoLoaded(i);
            });
        }

        private void OnUpdateInfoLoaded(int i) {
            if(updateNotesComboBox.SelectedIndex == i){
                detailsTextBox.Text = updateInfos[i].changeLog;
            }else if(updateNotesComboBox.SelectedIndex == -1){
                updateNotesComboBox.SelectedIndex = i;
            }
            bool allLoaded = true;
            foreach(UpdateInfo cur in updateInfos){
                if(cur == null){
                    allLoaded = false;
                    break;
                }
            }
            if(allLoaded){
                updateButton.Enabled = true;
            }
        }

        private void updateNotesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(updateInfos[updateNotesComboBox.SelectedIndex] == null){
                detailsTextBox.Text = LauncherLocale.Current.Get("Updater.Multi.NotesPlaceholder");
                return;
            }
            detailsTextBox.Text = updateInfos[updateNotesComboBox.SelectedIndex].changeLog;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            updateButton.Enabled = false;
            cancelButton.Enabled = false;
            UpdateProgressWindow progressWindow = new UpdateProgressWindow(updater);
            progressWindow.Show();
            progressWindow.SetProgress(0, "Applying updates");
            Thread updateThread = new Thread(() => {
                UpdateInfo targetVersion = null;
                foreach (UpdateInfo cur in updateInfos) {
                    if (cur.version == appInfo.LatestVersion) {
                        targetVersion = cur;
                    }
                }
                if (targetVersion == null) {
                    MessageBox.Show("Failed to retrieve update info for most recent update.");
                    this.Invoke((Action)(() => { this.Close(); }));
                    return;
                }
                updater.ApplyUpdate(appInfo, targetVersion, hostURL);
                this.Invoke((Action)(() => { this.Close(); }));
            });
            updateThread.Name = "Update thread";
            updateThread.IsBackground = true;
            updateThread.Start();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
