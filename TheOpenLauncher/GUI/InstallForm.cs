using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TheOpenLauncher.Properties;

namespace TheOpenLauncher
{
    public partial class InstallForm : MetroForm
    {
        public InstallForm()
        {
            InitializeComponent();

            if (LauncherLocale.AvailableLocales.Length > 1) {
                foreach (string cur in LauncherLocale.AvailableLocales) {
                    this.languageComboBox.Items.Add(cur);
                    if (cur.Equals(LauncherLocale.Current.localeName)) {
                        languageComboBox.SelectedIndex = languageComboBox.Items.Count - 1;
                    }
                }
            } else {
                languageComboBox.Visible = false;
            }
            
            UpdateLocalizedText();
        }

        public void UpdateLocalizedText() {
            this.Text = LauncherLocale.Current.Get("Installer.Title");
            infoLabel.Text = LauncherLocale.Current.Get("Installer.IntroInfo");
            optionsButton.Text = LauncherLocale.Current.Get("Installer.OptionsButton");
            installButton.Text = LauncherLocale.Current.Get("Installer.InstallButton");
            cancelButton.Text = LauncherLocale.Current.Get("Installer.CancelButton");
        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            LauncherLocale.Current = LauncherLocale.LoadLocale(LauncherLocale.AvailableLocales[languageComboBox.SelectedIndex]);
            UpdateLocalizedText();
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            InstallationOptionsForm optionsForm = new InstallationOptionsForm();
            optionsForm.ShowDialog();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            try{
                new System.IO.FileInfo(InstallationSettings.InstallationFolder);
            }catch (Exception){
                MessageBox.Show(this, "Please set the installation path in the options panel.", "Invalid installation path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Hide();
            Installer installer = new Installer();
            try
            {
                installer.InstallApplication();
                this.Close();
            } catch (UnauthorizedAccessException) {
                Program.RequestElevation();
            } catch (Exception ex) {
                MessageBox.Show("An error occured while attempting to install the application. ("+ex.Message+")", "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
