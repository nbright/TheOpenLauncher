using FolderSelect;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheOpenLauncher.VersionPublisher.GUI {
    public partial class NewProjectDialog : MetroForm {
        public Project newProject = new Project();
        private Type[] publishers;
        private PublisherInfo[] publisherInfos;

        private int defaultFormHeight;
        private int defaultPublisherSettingsHeight;

        public NewProjectDialog() {
            InitializeComponent();

            defaultFormHeight = this.Height;
            defaultPublisherSettingsHeight = publisherSettings.Height;

            publishers = Publisher.PublisherTypes;
            publisherInfos = new PublisherInfo[publishers.Length];
            for(int i = 0;i<publishers.Length;i++){
                publisherInfos[i] = (PublisherInfo)publishers[i].GetCustomAttributes(typeof(PublisherInfo), true)[0];
            }

            publisherComboBox.Items.AddRange(publisherInfos);

            publisherSettings.ControlAdded += publisherSettings_ControlAdded;
        }

        void publisherSettings_ControlAdded(object sender, ControlEventArgs e) {
            e.Control.TextChanged += (eSender, eventArgs) => { CheckFormComplete(); };
            e.Control.MouseClick += (eSender, eventArgs) => { CheckFormComplete(); };
            e.Control.KeyPress   += (eSender, eventArgs) => { CheckFormComplete(); };
            e.Control.ControlAdded += publisherSettings_ControlAdded;

            foreach(Control subControl in e.Control.Controls){
                publisherSettings_ControlAdded(null, new ControlEventArgs(subControl));
            }
        }

        private void createButton_Click(object sender, EventArgs e) {
            newProject.Name = nameTextBox.Text;
            newProject.ProjectFolder = folderTextBox.Text;
            newProject.AppID = appIDTextBox.Text;
            if (newProject.Updates == null) {
                newProject.Updates = new List<UpdateInfo>();
            }
            newProject.publisher.ApplySettingsPanel(publisherSettings);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CheckFormComplete() {
            bool formsFilled = !String.IsNullOrWhiteSpace(nameTextBox.Text)
                && !String.IsNullOrWhiteSpace(appIDTextBox.Text)
                && !String.IsNullOrWhiteSpace(folderTextBox.Text)
                && newProject.publisher != null;

            createButton.Enabled = formsFilled 
                && Directory.Exists(folderTextBox.Text)
                && newProject.publisher.IsSettingsPanelComplete(publisherSettings);
        }

        private void folderPickButton_Click(object sender, EventArgs e) {
            FolderSelectDialog dialog = new FolderSelectDialog();
            dialog.Title = "Select the project folder.";
            if (dialog.ShowDialog(this.Handle)) {
                folderTextBox.Text = dialog.FileName;
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e) {
            if (String.IsNullOrWhiteSpace(appIDTextBox.Text) || appIDTextBox.Text.StartsWith("YourCompany")) {
                appIDTextBox.Text = "YourCompany/"+nameTextBox.Text;
            }
            CheckFormComplete();
        }

        public void SetPublisher(Type publisherType) {
            for (int i = 0; i < publishers.Length;i++ ) {
                if(publishers[i] == publisherType){
                    publisherComboBox.SelectedIndex = i;
                }
            }
        }

        private void publisherComboBox_SelectedValueChanged(object sender, EventArgs e) {
            Type publisherType = publishers[publisherComboBox.SelectedIndex];
            Publisher publisher = null;
            try {
                publisher = (Publisher)Activator.CreateInstance(publisherType);
            } catch (TargetInvocationException ex) {
                MessageBox.Show("An exception occured while trying to create a new publisher of type " + publisherType.Name + ": " + ex.InnerException.Message);
            } catch (MethodAccessException) {
                MessageBox.Show("Invalid publisher type: The constructor is not accessible");
            } catch (MissingMethodException) {
                MessageBox.Show("Invalid publisher type: Missing empty constructor");
            }
            if (publisher != null) {
                publisherSettings.Controls.Clear();
                publisher.SetupSettingsPanel(publisherSettings);
            }
            
            newProject.publisher = publisher;
            CheckFormComplete();
        }

        private void folderTextBox_TextChanged(object sender, EventArgs e) {
            CheckFormComplete();
        }

        private void appIDTextBox_TextChanged(object sender, EventArgs e) {
            CheckFormComplete();
        }

        private void publisherSettings_Resize(object sender, EventArgs e) {
            int heightDiff = publisherSettings.Height - defaultPublisherSettingsHeight;
            if (this.Height < defaultFormHeight + heightDiff) {
                this.Height = defaultFormHeight + heightDiff;
            }
        }
    }
}
