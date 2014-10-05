namespace TheOpenLauncher.VersionPublisher.GUI {
    partial class NewProjectDialog {
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
            this.createButton = new MetroFramework.Controls.MetroButton();
            this.cancelButton = new MetroFramework.Controls.MetroButton();
            this.nameLabel = new MetroFramework.Controls.MetroLabel();
            this.appIDLabel = new MetroFramework.Controls.MetroLabel();
            this.folderLabel = new MetroFramework.Controls.MetroLabel();
            this.nameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.appIDTextBox = new MetroFramework.Controls.MetroTextBox();
            this.folderTextBox = new MetroFramework.Controls.MetroTextBox();
            this.publisherComboBox = new MetroFramework.Controls.MetroComboBox();
            this.publisherLabel = new MetroFramework.Controls.MetroLabel();
            this.folderPickButton = new MetroFramework.Controls.MetroButton();
            this.publisherSettings = new MetroFramework.Controls.MetroPanel();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createButton.Enabled = false;
            this.createButton.Location = new System.Drawing.Point(364, 234);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "Create";
            this.createButton.UseSelectable = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(13, 234);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseSelectable = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(13, 60);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(48, 19);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name:";
            // 
            // appIDLabel
            // 
            this.appIDLabel.AutoSize = true;
            this.appIDLabel.Location = new System.Drawing.Point(231, 60);
            this.appIDLabel.Name = "appIDLabel";
            this.appIDLabel.Size = new System.Drawing.Size(49, 19);
            this.appIDLabel.TabIndex = 3;
            this.appIDLabel.Text = "AppID:";
            // 
            // folderLabel
            // 
            this.folderLabel.AutoSize = true;
            this.folderLabel.Location = new System.Drawing.Point(13, 108);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(92, 19);
            this.folderLabel.TabIndex = 4;
            this.folderLabel.Text = "Project folder:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Lines = new string[0];
            this.nameTextBox.Location = new System.Drawing.Point(21, 82);
            this.nameTextBox.MaxLength = 32767;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.PasswordChar = '\0';
            this.nameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nameTextBox.SelectedText = "";
            this.nameTextBox.Size = new System.Drawing.Size(191, 23);
            this.nameTextBox.TabIndex = 5;
            this.nameTextBox.UseSelectable = true;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // appIDTextBox
            // 
            this.appIDTextBox.Lines = new string[0];
            this.appIDTextBox.Location = new System.Drawing.Point(242, 82);
            this.appIDTextBox.MaxLength = 32767;
            this.appIDTextBox.Name = "appIDTextBox";
            this.appIDTextBox.PasswordChar = '\0';
            this.appIDTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.appIDTextBox.SelectedText = "";
            this.appIDTextBox.Size = new System.Drawing.Size(191, 23);
            this.appIDTextBox.TabIndex = 6;
            this.appIDTextBox.UseSelectable = true;
            this.appIDTextBox.TextChanged += new System.EventHandler(this.appIDTextBox_TextChanged);
            // 
            // folderTextBox
            // 
            this.folderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTextBox.Lines = new string[0];
            this.folderTextBox.Location = new System.Drawing.Point(21, 130);
            this.folderTextBox.MaxLength = 32767;
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.PasswordChar = '\0';
            this.folderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.folderTextBox.SelectedText = "";
            this.folderTextBox.Size = new System.Drawing.Size(329, 23);
            this.folderTextBox.TabIndex = 7;
            this.folderTextBox.UseSelectable = true;
            this.folderTextBox.TextChanged += new System.EventHandler(this.folderTextBox_TextChanged);
            // 
            // publisherComboBox
            // 
            this.publisherComboBox.FormattingEnabled = true;
            this.publisherComboBox.ItemHeight = 23;
            this.publisherComboBox.Location = new System.Drawing.Point(21, 178);
            this.publisherComboBox.Name = "publisherComboBox";
            this.publisherComboBox.Size = new System.Drawing.Size(191, 29);
            this.publisherComboBox.TabIndex = 8;
            this.publisherComboBox.UseSelectable = true;
            this.publisherComboBox.SelectedValueChanged += new System.EventHandler(this.publisherComboBox_SelectedValueChanged);
            // 
            // publisherLabel
            // 
            this.publisherLabel.AutoSize = true;
            this.publisherLabel.Location = new System.Drawing.Point(13, 156);
            this.publisherLabel.Name = "publisherLabel";
            this.publisherLabel.Size = new System.Drawing.Size(119, 19);
            this.publisherLabel.TabIndex = 9;
            this.publisherLabel.Text = "Publishing channel:";
            // 
            // folderPickButton
            // 
            this.folderPickButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.folderPickButton.Location = new System.Drawing.Point(356, 130);
            this.folderPickButton.Name = "folderPickButton";
            this.folderPickButton.Size = new System.Drawing.Size(75, 23);
            this.folderPickButton.TabIndex = 10;
            this.folderPickButton.Text = "Choose..";
            this.folderPickButton.UseSelectable = true;
            this.folderPickButton.Click += new System.EventHandler(this.folderPickButton_Click);
            // 
            // publisherSettings
            // 
            this.publisherSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.publisherSettings.HorizontalScrollbarBarColor = true;
            this.publisherSettings.HorizontalScrollbarHighlightOnWheel = false;
            this.publisherSettings.HorizontalScrollbarSize = 10;
            this.publisherSettings.Location = new System.Drawing.Point(21, 214);
            this.publisherSettings.Name = "publisherSettings";
            this.publisherSettings.Size = new System.Drawing.Size(412, 14);
            this.publisherSettings.TabIndex = 11;
            this.publisherSettings.VerticalScrollbarBarColor = true;
            this.publisherSettings.VerticalScrollbarHighlightOnWheel = false;
            this.publisherSettings.VerticalScrollbarSize = 10;
            this.publisherSettings.Resize += new System.EventHandler(this.publisherSettings_Resize);
            // 
            // NewProjectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 270);
            this.Controls.Add(this.publisherSettings);
            this.Controls.Add(this.folderPickButton);
            this.Controls.Add(this.publisherLabel);
            this.Controls.Add(this.publisherComboBox);
            this.Controls.Add(this.folderTextBox);
            this.Controls.Add(this.appIDTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.folderLabel);
            this.Controls.Add(this.appIDLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.MinimumSize = new System.Drawing.Size(452, 270);
            this.Name = "NewProjectDialog";
            this.Padding = new System.Windows.Forms.Padding(10, 60, 10, 10);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "New project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton createButton;
        private MetroFramework.Controls.MetroButton cancelButton;
        private MetroFramework.Controls.MetroLabel nameLabel;
        private MetroFramework.Controls.MetroLabel appIDLabel;
        private MetroFramework.Controls.MetroLabel folderLabel;
        private MetroFramework.Controls.MetroLabel publisherLabel;
        private MetroFramework.Controls.MetroButton folderPickButton;
        public MetroFramework.Controls.MetroTextBox appIDTextBox;
        public MetroFramework.Controls.MetroComboBox publisherComboBox;
        public MetroFramework.Controls.MetroTextBox nameTextBox;
        public MetroFramework.Controls.MetroTextBox folderTextBox;
        public MetroFramework.Controls.MetroPanel publisherSettings;
    }
}