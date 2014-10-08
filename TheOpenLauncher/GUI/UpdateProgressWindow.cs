using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheOpenLauncher
{
    public partial class UpdateProgressWindow : MetroForm
    {
        private Updater updater;
        public UpdateProgressWindow(Updater updater)
        {
            InitializeComponent();
            this.updater = updater;
            this.Text = LauncherLocale.Current.Get("Updater.Progress.Title");
            cancelButton.Text = LauncherLocale.Current.Get("Updater.Progress.CancelButton");
            HandleCreated += UpdateProgressWindow_HandleCreated;
        }

        void UpdateProgressWindow_HandleCreated(object sender, EventArgs e) {
            updater.ProgressChanged += (source, eventInfo) => {
                this.SetProgress(eventInfo.PercentageDone, eventInfo.CurrentAction);
            };
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(this, "Cancelling the update will leave the application in a semi-updated state. Before the application can run, it must be either fully updated or reïnstalled. Are you sure want to cancel?",
                "Cancel update?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes) {
                    string lockFile = InstallationSettings.InstallationFolder + "/Updater.lock";
                    if(File.Exists(lockFile)){
                        File.WriteAllText(lockFile, "Incomplete");
                    }
                    Application.Exit();
            }
        }

        public void SetProgress(int progressBarValue, string currentAction)
        {
            this.Invoke((Action)(() => {
                progressBar.Value = progressBarValue;
                currentActionLabel.Text = currentAction;
            }));
        }
    }
}
