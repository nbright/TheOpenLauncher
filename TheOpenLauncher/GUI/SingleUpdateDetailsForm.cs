using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TheOpenLauncher
{
    public partial class SingleUpdateDetailsForm : MetroForm
    {
        private Updater updater;
        private AppInfo appInfo;
        private UpdateHost updateHost;
        private double targetVersion;

        private UpdateInfo updateInfo;

        public SingleUpdateDetailsForm(Updater updater, AppInfo appInfo, UpdateHost updateHost, double targetVersion)
        {
            this.updater = updater;
            this.appInfo = appInfo;
            this.updateHost = updateHost;
            this.targetVersion = targetVersion;
            InitializeComponent();

            this.Text = LauncherLocale.Current.Get("Updater.Single.Title");
            detailsTextBox.Text = LauncherLocale.Current.Get("Updater.Single.NotesPlaceholder");
            cancelButton.Text = LauncherLocale.Current.Get("Updater.Single.CancelButton");
            updateButton.Text = LauncherLocale.Current.Get("Updater.Single.ApplyButton");
        }

        private void SetUpdateInfo(UpdateInfo info) {
            this.updateInfo = info;
            this.detailsTextBox.Text = info.changeLog;
            this.infoLabel.Text = LauncherLocale.Current.Get("Updater.Single.InfoLabel");
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            this.infoLabel.Text = this.infoLabel.Text.Replace("${updateVersion}", info.version.ToString(nfi));
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            updater.RetrieveUpdateInfo(appInfo, updateHost, targetVersion, (updateInfo, curUpdateHost) => {
                if (updateInfo == null) {
                    MessageBox.Show("No valid update info found.");
                    Application.Exit();
                    //TODO: Handle this. Should either search for new appInfo host or fail.
                }
                this.SetUpdateInfo(updateInfo);
            });
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateProgressWindow progressWindow = new UpdateProgressWindow(updater);
            progressWindow.SetProgress(10, "Applying update");
            progressWindow.Show();
            this.Hide();
            new Thread(() => {
                updater.ApplyUpdate(appInfo, updateInfo, updateHost);
            }).Start();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //TODO
        }
    }
}
