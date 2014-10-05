using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public MultiUpdateDetailsForm(Updater updater, AppInfo appInfo, UpdateHost hostURL, double[] targetVersions) {
            this.updater = updater;
            this.appInfo = appInfo;
            this.hostURL = hostURL;
            this.targetVersions = targetVersions;
            InitializeComponent();

            this.Text = LauncherLocale.Current.Get("Updater.Multi.Title");
            infoLabel.Text = LauncherLocale.Current.Get("Updater.Multi.InfoLabel");
            updateNotesDropdownLabel.Text = LauncherLocale.Current.Get("Updater.Multi.NotesDropDownLabel");
            detailsTextBox.Text = LauncherLocale.Current.Get("Updater.Multi.NotesPlaceholder");
            cancelButton.Text = LauncherLocale.Current.Get("Updater.Multi.CancelButton");
            updateButton.Text = LauncherLocale.Current.Get("Updater.Multi.ApplyButton").Replace("${updateCount}", 1337.ToString());
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
