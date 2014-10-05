using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheOpenLauncher {
    public partial class InstallationFinishedForm : MetroForm {
        public InstallationFinishedForm() {
            InitializeComponent();

            this.Text = LauncherLocale.Current.Get("Installer.Finish.Title");
            infoLabel.Text = LauncherLocale.Current.Get("Installer.Finish.InfoLabel");
            runButton.Text = LauncherLocale.Current.Get("Installer.Finish.CloseAndRun");
            closeButton.Text = LauncherLocale.Current.Get("Installer.Finish.Close");
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void runButton_Click(object sender, EventArgs e) {
            Program.LaunchTargetApplication(this);
            this.Close();
        }
    }
}
