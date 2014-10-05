using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            updater.ProgressChanged += (source, eventInfo) => {
                this.SetProgress(eventInfo.PercentageDone, eventInfo.CurrentAction);
            };

            this.Text = LauncherLocale.Current.Get("Updater.Progress.Title");
            cancelButton.Text = LauncherLocale.Current.Get("Updater.Progress.CancelButton");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //TODO
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
