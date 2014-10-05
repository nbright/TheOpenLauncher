using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheOpenLauncher.VersionPublisher.GUI {
    public partial class NewUpdatePage : UserControl {
        ProjectPage parent;
        Project project;
        UpdateInfo newUpdateInfo;
        public NewUpdatePage() {
            InitializeComponent();
            noChangesLabel.Visible = false;
            if (MainForm.Instance != null) {
                MainForm.Instance.Activated += OnFormFocused;
            }
        }

        void OnFormFocused(object sender, EventArgs e) {
            if(parent.detailsTabControl.SelectedTab.Controls[0] == parent.newUpdatePage){
                RefreshChangeList();
            }
        }

        public void SetParent(ProjectPage parent) {
            this.parent = parent;
        }

        private void SetNewUpdateFileChangesList(FileDiffListItem[] changes) {
            this.newUpdateChangesListBox.Invoke((Action)(() => {
                this.newUpdateChangesListBox.Clear();
                foreach (FileDiffListItem cur in changes) {
                    this.newUpdateChangesListBox.Items.Add(cur.path);
                    this.newUpdateChangesListBox.ItemBackgroundColors.Add(FileDiffListItem.GetStateColor(cur.state));
                }
            }));
        }

        public void LoadUpdateChanges(Project project, UpdateInfo newUpdateInfo) {
            this.project = project;
            this.newUpdateInfo = newUpdateInfo;
            project.GetFilesDiffAsync((List<FileDiffListItem> diff, Dictionary<String, String> checksums) => {
                newUpdateInfo.fileChecksums = checksums;
                SetNewUpdateFileChangesList(diff.ToArray());
                if(diff.ToArray().Length == 0){
                    this.Invoke((Action)(() => {
                        nextTabButton.Enabled = false;
                        noChangesLabel.Visible = true;
                    }));
                } else {
                    this.Invoke((Action)(() => {
                        nextTabButton.Enabled = true;
                        noChangesLabel.Visible = false;
                    }));
                }
            });
        }

        private void nextTabButton_Click(object sender, EventArgs e) {
            parent.detailsTabControl.SelectedTab = parent.publishUpdateTab;
        }

        public void RefreshChangeList() {
            if(project != null){
                nextTabButton.Enabled = false;
                LoadUpdateChanges(project, newUpdateInfo);
            }
        }
    }
}
