namespace TheOpenLauncher.VersionPublisher {
    partial class LocalDiskPublisherGUI {
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
            this.folderPickButton = new MetroFramework.Controls.MetroButton();
            this.folderTextBox = new MetroFramework.Controls.MetroTextBox();
            this.folderLabel = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // folderPickButton
            // 
            this.folderPickButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.folderPickButton.Location = new System.Drawing.Point(324, 22);
            this.folderPickButton.Name = "folderPickButton";
            this.folderPickButton.Size = new System.Drawing.Size(75, 23);
            this.folderPickButton.TabIndex = 13;
            this.folderPickButton.Text = "Choose..";
            this.folderPickButton.UseSelectable = true;
            this.folderPickButton.Click += new System.EventHandler(this.folderPickButton_Click);
            // 
            // folderTextBox
            // 
            this.folderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTextBox.Lines = new string[0];
            this.folderTextBox.Location = new System.Drawing.Point(11, 22);
            this.folderTextBox.MaxLength = 32767;
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.PasswordChar = '\0';
            this.folderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.folderTextBox.SelectedText = "";
            this.folderTextBox.Size = new System.Drawing.Size(307, 23);
            this.folderTextBox.TabIndex = 12;
            this.folderTextBox.UseSelectable = true;
            // 
            // folderLabel
            // 
            this.folderLabel.AutoSize = true;
            this.folderLabel.Location = new System.Drawing.Point(3, 0);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(89, 19);
            this.folderLabel.TabIndex = 11;
            this.folderLabel.Text = "Target folder:";
            // 
            // LocalDiskPublisherGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.folderPickButton);
            this.Controls.Add(this.folderTextBox);
            this.Controls.Add(this.folderLabel);
            this.Name = "LocalDiskPublisherGUI";
            this.Size = new System.Drawing.Size(402, 78);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton folderPickButton;
        private MetroFramework.Controls.MetroLabel folderLabel;
        public MetroFramework.Controls.MetroTextBox folderTextBox;

    }
}
