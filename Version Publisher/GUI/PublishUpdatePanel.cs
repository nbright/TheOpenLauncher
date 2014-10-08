using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MetroFramework.Controls;

namespace TheOpenLauncher.VersionPublisher.GUI {
    public partial class PublishUpdatePanel : UserControl {
        Project project;
        UpdateInfo newUpdateInfo;
        ProjectPage parentPage;

        public PublishUpdatePanel() {
            InitializeComponent();
        }

        public void SetParent(ProjectPage page) {
            parentPage = page;
        }

        public void SetProject(Project project) {
            this.project = project;
        }

        public void SetUpdate(UpdateInfo newUpdateInfo) {
            this.newUpdateInfo = newUpdateInfo;
        }

        private void publishUpdateButton_Click(object sender, EventArgs e) {
            newUpdateInfo.summary = summaryTextBox.Text;
            newUpdateInfo.version = VersionFormatter.FromString(versionTextBox.Text);
            newUpdateInfo.changeLog = newNotesTextBox.Text;
            newUpdateInfo.ReleaseDate = DateTime.UtcNow;

            try {
                project.PublishUpdate(newUpdateInfo);
            } catch(PublishingFailedException ex){
                MessageBox.Show(ex.Message, "Failed to publish update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                string message = "An exception occured while trying to publish the update: " + ex.Message + Environment.NewLine
                    + "Stacktrace:" + Environment.NewLine + ex.StackTrace;
                MessageBox.Show(message, "Failed to publish update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            parentPage.RefreshUpdateList();
            parentPage.SelectUpdate(0);
        }

        public void LoadUpdateChanges() {
            versionTextBox.Text = VersionFormatter.ToString(GetNextVersionNumber());
        }

        private int GetDecimalPlaces(double argument) {
            if (Math.Floor(argument) == argument) {
                return 0;
            }
            string numberString = VersionFormatter.ToString(argument);
            return numberString.Substring(numberString.IndexOf(".") + 1).Length;
        }

        private static double GetDecimalIncrement(int decimalPlaces) {
            string resultString = "0.";
            for (int i = 0; i < decimalPlaces - 1; i++) {
                resultString = resultString + "0";
            }
            resultString = resultString + "1";
            return VersionFormatter.FromString(resultString);
        }

        private double GetNextVersionNumber() {
            UpdateInfo[] updates = project.Updates.OrderByDescending((UpdateInfo info) => {
                return info.version;
            }).ToArray();

            if (updates.Length > 1) {
                double lastVersion = updates[0].version;
                double oneToLastVersion = updates[1].version;
                int decimalPlacesOfLast = GetDecimalPlaces(lastVersion);
                int decimalPlacesOfOneToLast = GetDecimalPlaces(oneToLastVersion);
                if (decimalPlacesOfLast > decimalPlacesOfOneToLast) {
                    return lastVersion + GetDecimalIncrement(decimalPlacesOfLast);
                } else {
                    return lastVersion + GetDecimalIncrement(decimalPlacesOfOneToLast);
                }
            } else if (updates.Length == 1) {
                return updates[0].version + GetDecimalIncrement(GetDecimalPlaces(updates[0].version));
            }
            return 1.0;
        }

        private void CheckFormCompletion() {
            double version;
            if (!String.IsNullOrWhiteSpace(summaryTextBox.Text) && !summaryTextBox.Text.Equals("Summary")
                && !String.IsNullOrWhiteSpace(versionTextBox.Text) && Double.TryParse(versionTextBox.Text, out version)
                && !String.IsNullOrWhiteSpace(newNotesTextBox.Text) && !newNotesTextBox.Text.Equals("Update notes")) {
                    publishUpdateButton.Enabled = true;
                    return;
            }
            publishUpdateButton.Enabled = false;
        }

        #region TextBox UI event handlers
        private void summaryTextBox_TextChanged(object sender, EventArgs e) {
            CheckFormCompletion();
        }

        private void versionTextBox_TextChanged(object sender, EventArgs e) {
            CheckFormCompletion();
        }

        private void newNotesTextBox_TextChanged(object sender, EventArgs e) {
            CheckFormCompletion();
        }

        private void SetInactiveTextColor(MetroTextBox textbox, bool inactive) {
            textbox.UseCustomForeColor = true;
            textbox.ForeColor = inactive ? SystemColors.GrayText : SystemColors.ControlText;
        }

        private void summaryTextBox_Enter(object sender, EventArgs e) {
            if(summaryTextBox.Text.Equals("Summary")){
                summaryTextBox.Text = "";
                SetInactiveTextColor(summaryTextBox, false);
            }
        }

        private void summaryTextBox_Leave(object sender, EventArgs e) {
            if (String.IsNullOrWhiteSpace(summaryTextBox.Text)) {
                summaryTextBox.Text = "Summary";
                SetInactiveTextColor(summaryTextBox, true);
            }
        }

        private void versionTextBox_Enter(object sender, EventArgs e) {
            if (versionTextBox.Text.Equals("Version")) {
                versionTextBox.Text = "";
                SetInactiveTextColor(versionTextBox, false);
            }
        }

        private void versionTextBox_Leave(object sender, EventArgs e) {
            if (String.IsNullOrWhiteSpace(versionTextBox.Text)) {
                versionTextBox.Text = "Version";
                SetInactiveTextColor(versionTextBox, true);
            }
        }

        private void newNotesTextBox_Enter(object sender, EventArgs e) {
            if (newNotesTextBox.Text.Equals("Update notes")) {
                newNotesTextBox.Text = "";
                SetInactiveTextColor(newNotesTextBox, false);
            }
        }

        private void newNotesTextBox_Leave(object sender, EventArgs e) {
            if (String.IsNullOrWhiteSpace(newNotesTextBox.Text)) {
                newNotesTextBox.Text = "Update notes";
                SetInactiveTextColor(newNotesTextBox, true);
            }
        }
        #endregion
    }
}
