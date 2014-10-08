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

namespace TheOpenLauncher.VersionPublisher.GUI {
    //TODO: "major update" button -> toggles special color tab in version list + notifies user of major update (triggers on n+1.0 or checkbox)
    public partial class ProjectPage : UserControl {
        private Project project;
        public Project Project {
            get {
                return project;
            }
            set {
                SetProject(value);
            }
        }
        private IEnumerable<UpdateInfo> updates;
        private UpdateInfo newUpdateInfo;

        public ProjectPage() {
            InitializeComponent();
            newUpdatePage.SetParent(this);
            publishUpdatePanel.SetParent(this);

            if (MainForm.Instance != null) {
                MainForm.Instance.Activated += OnFormFocused;
            }
        }

        void OnFormFocused(object sender, EventArgs e) {
            if (MainForm.Instance.SelectedProject == project) {
                RefreshUpdateList();
            }
        }

        public void SetProject(Project project){
            this.project = project;
            SetUpdateList(project.Updates.ToArray());
            publishUpdatePanel.SetProject(project);
            if(updatesList.Items.Count > 0){
                updatesList.SelectedIndex = 0;
            } else {
                ShowCreateUpdateTab();
            }
        }

        private void SetUpdateList(UpdateInfo[] updatesUnsorted) {
            updatesList.Clear();

            if(updatesUnsorted == null){
                return;
            }

            updates = updatesUnsorted.OrderByDescending(update => update.version);
            foreach(UpdateInfo cur in updates){
                if(cur.summary == null){
                    updatesList.Items.Add("Version " + VersionFormatter.ToString(cur.version));
                } else {
                    updatesList.Items.Add(cur.summary);
                }
                updatesList.ItemSubTexts.Add(DateTools.GetSimpleDateRepresentation(cur.ReleaseDate));
            }
        }

        private void ShowCreateUpdateTab() {
            updatesList.SelectedIndex = -1;
            detailsTabControl.SelectedTab = newUpdateTab;

            newUpdateInfo = new UpdateInfo();
            newUpdatePage.LoadUpdateChanges(project, newUpdateInfo);
            publishUpdatePanel.SetUpdate(newUpdateInfo);
            publishUpdatePanel.LoadUpdateChanges();
        }

        private void createUpdateButton_Click(object sender, EventArgs e) {
            ShowCreateUpdateTab();
        }

        private void updatesList_SelectedIndexChanged(object sender, EventArgs e) {
            if (updatesList.SelectedIndex != -1) {
                detailsTabControl.SelectedTab = updateInfoTab;
                UpdateInfo previousUpdate = null;
                if(updatesList.SelectedIndex+1 < updatesList.Items.Count){
                    previousUpdate = updates.ElementAt(updatesList.SelectedIndex+1);
                }
                updateInfoPage.SetUpdateInfoPanel(previousUpdate, updates.ElementAt(updatesList.SelectedIndex));
            }
        }

        public void SelectUpdate(int i) {
            updatesList.SelectedIndex = i;
        }

        public void RefreshUpdateList() {
            SetProject(project);
        }
    }

    public class FileDiffListItem {
        public enum FileState{
            CHANGED, REMOVED, ADDED
        }

        public FileState state;
        public string path;
        public FileDiffListItem(string path, FileState state) {
            this.path = path;
            this.state = state;
        }

        public static Color GetStateColor(FileDiffListItem.FileState state) {
            switch (state) {
                case FileDiffListItem.FileState.ADDED: return Color.FromArgb(222, 255, 224);
                case FileDiffListItem.FileState.CHANGED: return Color.FromArgb(222, 234, 255);
                case FileDiffListItem.FileState.REMOVED: return Color.FromArgb(255, 222, 222);
            }
            return Color.Transparent;
        }
    }
}
