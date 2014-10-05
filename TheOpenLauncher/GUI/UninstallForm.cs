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
    public partial class UninstallForm : MetroForm
    {
        public UninstallForm()
        {
            InitializeComponent();

            this.Text = LauncherLocale.Current.Get("Uninstaller.Title");
            uninstallInfo.Text = LauncherLocale.Current.Get("Uninstaller.InfoLabel");
            cancelButton.Text = LauncherLocale.Current.Get("Uninstaller.CancelButton");
            removeButton.Text = LauncherLocale.Current.Get("Uninstaller.RemoveButton");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {

        }
    }
}
