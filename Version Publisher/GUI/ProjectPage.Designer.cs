namespace TheOpenLauncher.VersionPublisher.GUI {
    partial class ProjectPage {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.createUpdateButton = new MetroFramework.Controls.MetroButton();
            this.detailsTabControl = new TheOpenLauncher.VersionPublisher.GUI.TablessTabControl();
            this.updateInfoTab = new System.Windows.Forms.TabPage();
            this.updateInfoPage = new TheOpenLauncher.VersionPublisher.GUI.UpdateInfoPage();
            this.newUpdateTab = new System.Windows.Forms.TabPage();
            this.newUpdatePage = new TheOpenLauncher.VersionPublisher.GUI.NewUpdatePage();
            this.publishUpdateTab = new System.Windows.Forms.TabPage();
            this.publishUpdatePanel = new TheOpenLauncher.VersionPublisher.GUI.PublishUpdatePanel();
            this.menuSeperator = new TheOpenLauncher.VersionPublisher.GUI.MetroSeperator();
            this.updatesList = new TheOpenLauncher.VersionPublisher.GUI.MetroListBox();
            this.detailsTabControl.SuspendLayout();
            this.updateInfoTab.SuspendLayout();
            this.newUpdateTab.SuspendLayout();
            this.publishUpdateTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // createUpdateButton
            // 
            this.createUpdateButton.Location = new System.Drawing.Point(0, 0);
            this.createUpdateButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.createUpdateButton.Name = "createUpdateButton";
            this.createUpdateButton.Size = new System.Drawing.Size(331, 39);
            this.createUpdateButton.TabIndex = 1;
            this.createUpdateButton.Text = "Create new update...";
            this.createUpdateButton.UseSelectable = true;
            this.createUpdateButton.Click += new System.EventHandler(this.createUpdateButton_Click);
            // 
            // detailsTabControl
            // 
            this.detailsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsTabControl.Controls.Add(this.updateInfoTab);
            this.detailsTabControl.Controls.Add(this.newUpdateTab);
            this.detailsTabControl.Controls.Add(this.publishUpdateTab);
            this.detailsTabControl.Location = new System.Drawing.Point(334, 0);
            this.detailsTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.detailsTabControl.Name = "detailsTabControl";
            this.detailsTabControl.SelectedIndex = 0;
            this.detailsTabControl.Size = new System.Drawing.Size(564, 544);
            this.detailsTabControl.TabIndex = 3;
            this.detailsTabControl.TabStop = false;
            // 
            // updateInfoTab
            // 
            this.updateInfoTab.Controls.Add(this.updateInfoPage);
            this.updateInfoTab.Location = new System.Drawing.Point(4, 22);
            this.updateInfoTab.Name = "updateInfoTab";
            this.updateInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.updateInfoTab.Size = new System.Drawing.Size(556, 518);
            this.updateInfoTab.TabIndex = 0;
            this.updateInfoTab.Text = "Update info";
            this.updateInfoTab.UseVisualStyleBackColor = true;
            // 
            // updateInfoPage
            // 
            this.updateInfoPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateInfoPage.Location = new System.Drawing.Point(3, 3);
            this.updateInfoPage.Name = "updateInfoPage";
            this.updateInfoPage.Size = new System.Drawing.Size(550, 512);
            this.updateInfoPage.TabIndex = 2;
            // 
            // newUpdateTab
            // 
            this.newUpdateTab.Controls.Add(this.newUpdatePage);
            this.newUpdateTab.Location = new System.Drawing.Point(4, 22);
            this.newUpdateTab.Name = "newUpdateTab";
            this.newUpdateTab.Size = new System.Drawing.Size(556, 518);
            this.newUpdateTab.TabIndex = 2;
            this.newUpdateTab.Text = "New update";
            this.newUpdateTab.UseVisualStyleBackColor = true;
            // 
            // newUpdatePage
            // 
            this.newUpdatePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newUpdatePage.Location = new System.Drawing.Point(0, 0);
            this.newUpdatePage.Name = "newUpdatePage";
            this.newUpdatePage.Size = new System.Drawing.Size(556, 518);
            this.newUpdatePage.TabIndex = 0;
            // 
            // publishUpdateTab
            // 
            this.publishUpdateTab.Controls.Add(this.publishUpdatePanel);
            this.publishUpdateTab.Location = new System.Drawing.Point(4, 22);
            this.publishUpdateTab.Name = "publishUpdateTab";
            this.publishUpdateTab.Padding = new System.Windows.Forms.Padding(3);
            this.publishUpdateTab.Size = new System.Drawing.Size(556, 518);
            this.publishUpdateTab.TabIndex = 1;
            this.publishUpdateTab.Text = "Publish update";
            this.publishUpdateTab.UseVisualStyleBackColor = true;
            // 
            // publishUpdatePanel
            // 
            this.publishUpdatePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.publishUpdatePanel.Location = new System.Drawing.Point(3, 3);
            this.publishUpdatePanel.Name = "publishUpdatePanel";
            this.publishUpdatePanel.Size = new System.Drawing.Size(550, 512);
            this.publishUpdatePanel.TabIndex = 0;
            // 
            // menuSeperator
            // 
            this.menuSeperator.BackColor = System.Drawing.Color.Transparent;
            this.menuSeperator.FadeLenght = 50;
            this.menuSeperator.FadesIn = true;
            this.menuSeperator.FadesOut = true;
            this.menuSeperator.IgnoreInputEvents = false;
            this.menuSeperator.LineColor = System.Drawing.SystemColors.Control;
            this.menuSeperator.Location = new System.Drawing.Point(332, 0);
            this.menuSeperator.Name = "menuSeperator";
            this.menuSeperator.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.menuSeperator.Size = new System.Drawing.Size(2, 538);
            this.menuSeperator.TabIndex = 1;
            // 
            // updatesList
            // 
            this.updatesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.updatesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.updatesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.updatesList.DrawSeperator = true;
            this.updatesList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(152)))), ((int)(((byte)(214)))));
            this.updatesList.ItemHeight = 50;
            this.updatesList.Location = new System.Drawing.Point(0, 42);
            this.updatesList.Name = "updatesList";
            this.updatesList.RepeatIcons = false;
            this.updatesList.SeperatorColor = System.Drawing.SystemColors.Control;
            this.updatesList.Size = new System.Drawing.Size(331, 500);
            this.updatesList.TabIndex = 0;
            this.updatesList.UseCustomForeColor = true;
            this.updatesList.UseSelectable = true;
            this.updatesList.SelectedIndexChanged += new System.EventHandler(this.updatesList_SelectedIndexChanged);
            // 
            // ProjectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.detailsTabControl);
            this.Controls.Add(this.createUpdateButton);
            this.Controls.Add(this.menuSeperator);
            this.Controls.Add(this.updatesList);
            this.Name = "ProjectPage";
            this.Size = new System.Drawing.Size(898, 544);
            this.detailsTabControl.ResumeLayout(false);
            this.updateInfoTab.ResumeLayout(false);
            this.newUpdateTab.ResumeLayout(false);
            this.publishUpdateTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroListBox updatesList;
        private MetroSeperator menuSeperator;
        private MetroFramework.Controls.MetroButton createUpdateButton;
        public TablessTabControl detailsTabControl;
        private System.Windows.Forms.TabPage updateInfoTab;
        public System.Windows.Forms.TabPage publishUpdateTab;
        private System.Windows.Forms.TabPage newUpdateTab;
        private PublishUpdatePanel publishUpdatePanel;
        private UpdateInfoPage updateInfoPage;
        public NewUpdatePage newUpdatePage;
    }
}
