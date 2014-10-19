using FolderSelect;
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

namespace TheOpenLauncher {
    public partial class InstallationOptionsForm : MetroForm {
        public InstallationOptionsForm() {
            InitializeComponent();

            this.Text = LauncherLocale.Current.Get("Installer.Options.Title");
            filePickerLabel.Text = LauncherLocale.Current.Get("Installer.Options.FolderLabel");
            filePickerButton.Text = LauncherLocale.Current.Get("Installer.Options.FolderButton");
            shortcutsLabel.Text = LauncherLocale.Current.Get("Installer.Options.ShortcutsLabel");
            desktopShortcutCheckbox.Text = LauncherLocale.Current.Get("Installer.Options.DesktopShortcutLabel");
            startmenuEntryCheckbox.Text = LauncherLocale.Current.Get("Installer.Options.StartMenuShortcutLabel");
            cancelButton.Text = LauncherLocale.Current.Get("Installer.Options.CancelButton");
            saveButton.Text = LauncherLocale.Current.Get("Installer.Options.SaveButton");
        }

        private void InstallationOptionsForm_Load(object sender, EventArgs e) {
            this.filePickerTextBox.Text = InstallationSettings.InstallationFolder;
            this.startmenuEntryCheckbox.Checked = InstallationSettings.CreateStartMenuEntry;
            this.desktopShortcutCheckbox.Checked = InstallationSettings.CreateDesktopShortcut;
            CheckFilePickerValid();
        }

        private void filePickerButton_Click(object sender, EventArgs e) {
            FolderSelectDialog dialog = new FolderSelectDialog();
            dialog.Title = "Select the installation folder.";
            if (dialog.ShowDialog(this.Handle)) {
                filePickerTextBox.Text = dialog.FileName;
            }
        }

        private void saveButton_Click(object sender, EventArgs e) {
            if (!CheckFilePickerValid()) {
                MessageBox.Show(this, "Please select a valid installation path", "Invalid installation path.");
                return;
            }

            string installFolder = this.filePickerTextBox.Text;
            try {
                if (!Directory.Exists(installFolder)) {
                    Directory.CreateDirectory(installFolder);
                }
                File.Create(installFolder + "/write.test").Close();
            } catch (UnauthorizedAccessException) {
                Program.RequestElevation();
                return;
            } catch (PathTooLongException) { //Should be caught by CheckFilePickerValid
                return;
            } catch (IOException) {
                MessageBox.Show("The installer was unable to write to this path. Please select a different installation folder.", "Invalid installation path");
                return;
            } finally {
                if (File.Exists(installFolder + "/write.test")) {
                    File.Delete(installFolder + "/write.test");
                }
            }

            InstallationSettings.InstallationFolder = installFolder;
            InstallationSettings.CreateStartMenuEntry = this.startmenuEntryCheckbox.Checked;
            InstallationSettings.CreateDesktopShortcut = this.desktopShortcutCheckbox.Checked;

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void filePickerTextBox_TextChanged(object sender, EventArgs e) {
            CheckFilePickerValid();
        }

        private bool CheckFilePickerValid() {
            bool isValidPath = false;
            try {
                new System.IO.FileInfo(filePickerTextBox.Text);
                isValidPath = true;
            } catch (Exception) { }

            if (!isValidPath) {
                filePickerTextBox.Style = MetroFramework.MetroColorStyle.Red;
                filePickerTextBox.Refresh();
                return false;
            } else {
                filePickerTextBox.Style = MetroFramework.MetroColorStyle.Default;
                filePickerTextBox.Refresh();
                return true;
            }
        }
    }
}
