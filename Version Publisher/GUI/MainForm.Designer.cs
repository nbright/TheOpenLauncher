namespace TheOpenLauncher.VersionPublisher.GUI {
    partial class MainForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            TheOpenLauncher.VersionPublisher.GUI.MetroListBox.ListIcon listIcon1 = new TheOpenLauncher.VersionPublisher.GUI.MetroListBox.ListIcon();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeperator = new TheOpenLauncher.VersionPublisher.GUI.MetroSeperator();
            this.pageList = new TheOpenLauncher.VersionPublisher.GUI.MetroListBox();
            this.tablessTabControl = new TheOpenLauncher.VersionPublisher.GUI.TablessTabControl();
            this.mainPage = new System.Windows.Forms.TabPage();
            this.infoLabel = new MetroFramework.Controls.MetroLabel();
            this.loadProjectButton = new MetroFramework.Controls.MetroButton();
            this.newProjectButton = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.tablessTabControl.SuspendLayout();
            this.mainPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 60);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pageList);
            this.splitContainer.Panel1MinSize = 100;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tablessTabControl);
            this.splitContainer.Size = new System.Drawing.Size(1010, 420);
            this.splitContainer.SplitterDistance = 191;
            this.splitContainer.TabIndex = 2;
            this.splitContainer.TabStop = false;
            this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // menuSeperator
            // 
            this.menuSeperator.BackColor = System.Drawing.Color.Transparent;
            this.menuSeperator.FadeLenght = 15;
            this.menuSeperator.FadesIn = true;
            this.menuSeperator.FadesOut = true;
            this.menuSeperator.IgnoreInputEvents = true;
            this.menuSeperator.LineColor = System.Drawing.SystemColors.Control;
            this.menuSeperator.Location = new System.Drawing.Point(192, 52);
            this.menuSeperator.Name = "menuSeperator";
            this.menuSeperator.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.menuSeperator.Size = new System.Drawing.Size(2, 569);
            this.menuSeperator.TabIndex = 3;
            this.menuSeperator.TabStop = false;
            // 
            // pageList
            // 
            this.pageList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pageList.ContextMenuStrip = this.contextMenu;
            this.pageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.pageList.DrawSeperator = false;
            this.pageList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(152)))), ((int)(((byte)(214)))));
            this.pageList.ItemHeight = 30;
            listIcon1.Icon = global::TheOpenLauncher.VersionPublisher.Properties.Resources.home;
            listIcon1.ItemSelectedIcon = global::TheOpenLauncher.VersionPublisher.Properties.Resources.home_selected;
            this.pageList.ItemIcons.Add(listIcon1);
            this.pageList.Items.AddRange(new object[] {
            "Main page"});
            this.pageList.Location = new System.Drawing.Point(0, 0);
            this.pageList.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.pageList.Name = "pageList";
            this.pageList.RepeatIcons = false;
            this.pageList.SeperatorColor = System.Drawing.SystemColors.Control;
            this.pageList.Size = new System.Drawing.Size(191, 420);
            this.pageList.TabIndex = 0;
            this.pageList.UseCustomForeColor = true;
            this.pageList.UseSelectable = true;
            this.pageList.SelectedValueChanged += new System.EventHandler(this.pageList_SelectedValueChanged);
            // 
            // tablessTabControl
            // 
            this.tablessTabControl.Controls.Add(this.mainPage);
            this.tablessTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablessTabControl.Location = new System.Drawing.Point(0, 0);
            this.tablessTabControl.Name = "tablessTabControl";
            this.tablessTabControl.SelectedIndex = 0;
            this.tablessTabControl.Size = new System.Drawing.Size(815, 420);
            this.tablessTabControl.TabIndex = 0;
            this.tablessTabControl.TabStop = false;
            // 
            // mainPage
            // 
            this.mainPage.Controls.Add(this.infoLabel);
            this.mainPage.Controls.Add(this.loadProjectButton);
            this.mainPage.Controls.Add(this.newProjectButton);
            this.mainPage.Location = new System.Drawing.Point(4, 22);
            this.mainPage.Name = "mainPage";
            this.mainPage.Size = new System.Drawing.Size(807, 394);
            this.mainPage.TabIndex = 0;
            this.mainPage.Text = "Main page";
            this.mainPage.UseVisualStyleBackColor = true;
            // 
            // infoLabel
            // 
            this.infoLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(209, 133);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(382, 57);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "Welcome to the Version Publisher for TheOpenLauncher. \r\n   To get started either " +
    "create a new or open an existing project.\r\n";
            // 
            // loadProjectButton
            // 
            this.loadProjectButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadProjectButton.Location = new System.Drawing.Point(222, 193);
            this.loadProjectButton.Name = "loadProjectButton";
            this.loadProjectButton.Size = new System.Drawing.Size(75, 23);
            this.loadProjectButton.TabIndex = 1;
            this.loadProjectButton.Text = "Load project";
            this.loadProjectButton.UseSelectable = true;
            this.loadProjectButton.Click += new System.EventHandler(this.loadProjectButton_Click);
            // 
            // newProjectButton
            // 
            this.newProjectButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newProjectButton.Location = new System.Drawing.Point(496, 193);
            this.newProjectButton.Name = "newProjectButton";
            this.newProjectButton.Size = new System.Drawing.Size(75, 23);
            this.newProjectButton.TabIndex = 2;
            this.newProjectButton.Text = "New project";
            this.newProjectButton.UseSelectable = true;
            this.newProjectButton.Click += new System.EventHandler(this.newProjectButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 500);
            this.Controls.Add(this.menuSeperator);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1020, 500);
            this.Name = "MainForm";
            this.Text = "Version Publisher";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.tablessTabControl.ResumeLayout(false);
            this.mainPage.ResumeLayout(false);
            this.mainPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroListBox pageList;
        private System.Windows.Forms.SplitContainer splitContainer;
        private GUI.TablessTabControl tablessTabControl;
        private System.Windows.Forms.TabPage mainPage;
        private MetroFramework.Controls.MetroLabel infoLabel;
        private MetroFramework.Controls.MetroButton newProjectButton;
        private MetroFramework.Controls.MetroButton loadProjectButton;
        private GUI.MetroSeperator menuSeperator;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;


    }
}

