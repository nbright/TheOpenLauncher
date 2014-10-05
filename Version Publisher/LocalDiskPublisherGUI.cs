using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FolderSelect;

namespace TheOpenLauncher.VersionPublisher {
    public partial class LocalDiskPublisherGUI : UserControl {
        public LocalDiskPublisherGUI() {
            InitializeComponent();
        }

        private void folderPickButton_Click(object sender, EventArgs e) {
            FolderSelectDialog dialog = new FolderSelectDialog();
            dialog.Title = "Select the publishing target folder.";
            if (dialog.ShowDialog(this.Handle)) {
                folderTextBox.Text = dialog.FileName;
            }
        }

        public void SetFolder(string folder) {
            folderTextBox.Text = folder;
        }

        public void SetFolderEditable(bool editable) {
            folderTextBox.Enabled = editable;
            folderPickButton.Enabled = editable;
        }
    }
}
