using FolderSelect;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheOpenLauncher.VersionPublisher.GUI {
    public partial class MainForm : MetroForm {
        private static MainForm instance;
        public static MainForm Instance { get { return instance; } }

        public Project SelectedProject {
            get {
                if (tablessTabControl.SelectedTab.Controls[0] is ProjectPage) {
                    return ((ProjectPage)(tablessTabControl.SelectedTab.Controls[0])).Project;
                }
                return null;
            }
        }

        private MetroListBox.ListIcon projectIcon = new MetroListBox.ListIcon();
        public MainForm() {
            instance = this;
            InitializeComponent();
            pageList.SelectedIndex = 0;
            projectIcon.Icon = TheOpenLauncher.VersionPublisher.Properties.Resources.toolkit;
            projectIcon.ItemSelectedIcon = TheOpenLauncher.VersionPublisher.Properties.Resources.toolkit_selected;

            foreach (Project curProject in Settings.Instance.Projects) {
                OpenProject(curProject);
            }
        }
        
        public int OpenProject(Project project) {
            ProjectPage page = new ProjectPage();
            this.pageList.Items.Add(project.Name);
            this.pageList.ItemIcons.Add(projectIcon);
            page.Dock = DockStyle.Fill;

            TabPage tabPage = new TabPage();
            tabPage.Controls.Add(page);
            this.tablessTabControl.TabPages.Add(tabPage);
            page.SetProject(project);

            return this.tablessTabControl.TabPages.Count - 1;
        }

        public void SelectPage(int pageI) {
            pageList.SelectedIndex = pageI;
            tablessTabControl.SelectedIndex = pageI;
        }

        private void pageList_SelectedValueChanged(object sender, EventArgs e) {
            tablessTabControl.SelectedIndex = pageList.SelectedIndex;
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e) {
            menuSeperator.Location = new Point(splitContainer.Panel1.Width, menuSeperator.Location.Y);
            menuSeperator.BringToFront();
        }

        private void newProjectButton_Click(object sender, EventArgs e) {
            NewProjectDialog dialog = new NewProjectDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                Settings.Instance.Projects.Add(dialog.newProject);
                Settings.Instance.Save();
                SelectPage(OpenProject(dialog.newProject));
            }
        }

        private UpdateInfo[] LoadUpdates(string folder, AppInfo info) {
            string versionsFolder = Path.Combine(folder, info.downloadBaseDir);
            UpdateInfo[] updates = new UpdateInfo[info.versions.Length];
            for(int i = 0;i<info.versions.Length;i++){
                double cur = info.versions[i];
                NumberFormatInfo formatInfo = new NumberFormatInfo();
                formatInfo.NumberDecimalSeparator = ".";
                string curVersionFolder = Path.Combine(versionsFolder, cur.ToString(formatInfo));
                string infoFile = Path.Combine(curVersionFolder, "info.json");
                updates[i] = UpdateInfo.FromJson(File.ReadAllText(infoFile));
            }
            return updates;
        }

        private void loadProjectButton_Click(object sender, EventArgs e) {
            FolderSelectDialog folderDialog = new FolderSelectDialog();
            folderDialog.Title = "Select the updates folder containing the appinfo.json file";
            if (folderDialog.ShowDialog(this.Handle)) {
                string appInfoFile = Path.Combine(folderDialog.FileName, "appinfo.json");
                if(!File.Exists(appInfoFile)){
                    MessageBox.Show("Could not load project folder: Folder does not contain appinfo.json", "Failed to load project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AppInfo info = AppInfo.FromJson(File.ReadAllText(appInfoFile));
                if(info == null){
                    MessageBox.Show("Could not load project folder: Invalid appinfo.json", "Failed to load project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UpdateInfo[] updates = LoadUpdates(folderDialog.FileName, info);
                
                NewProjectDialog dialog = new NewProjectDialog();
                dialog.appIDTextBox.Text = info.appId;
                dialog.newProject.Updates = updates.ToList();
                dialog.SetPublisher(typeof(LocalDiskPublisher)); //TODO: enable loading with different publisher types
                dialog.appIDTextBox.Enabled = false;
                dialog.publisherComboBox.Enabled = false;
                LocalDiskPublisherGUI gui = (LocalDiskPublisherGUI)dialog.publisherSettings.Controls[0];
                gui.SetFolder(folderDialog.FileName);
                gui.SetFolderEditable(false);

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    Settings.Instance.Projects.Add(dialog.newProject);
                    Settings.Instance.Save();
                    SelectPage(OpenProject(dialog.newProject));
                }
            }
        }
    }
}
