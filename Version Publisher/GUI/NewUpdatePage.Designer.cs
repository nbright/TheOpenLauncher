namespace TheOpenLauncher.VersionPublisher.GUI {
    partial class NewUpdatePage {
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
            this.nextTabButton = new MetroFramework.Controls.MetroButton();
            this.noChangesLabel = new MetroFramework.Controls.MetroLabel();
            this.newUpdateChangesListBox = new TheOpenLauncher.VersionPublisher.GUI.MetroListBox();
            this.SuspendLayout();
            // 
            // nextTabButton
            // 
            this.nextTabButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextTabButton.Enabled = false;
            this.nextTabButton.Location = new System.Drawing.Point(340, 426);
            this.nextTabButton.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.nextTabButton.Name = "nextTabButton";
            this.nextTabButton.Size = new System.Drawing.Size(172, 31);
            this.nextTabButton.TabIndex = 1;
            this.nextTabButton.Text = "Create update from changes...";
            this.nextTabButton.UseSelectable = true;
            this.nextTabButton.Click += new System.EventHandler(this.nextTabButton_Click);
            // 
            // noChangesLabel
            // 
            this.noChangesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.noChangesLabel.AutoSize = true;
            this.noChangesLabel.Location = new System.Drawing.Point(217, 182);
            this.noChangesLabel.Name = "noChangesLabel";
            this.noChangesLabel.Size = new System.Drawing.Size(78, 19);
            this.noChangesLabel.TabIndex = 2;
            this.noChangesLabel.Text = "No changes";
            // 
            // newUpdateChangesListBox
            // 
            this.newUpdateChangesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newUpdateChangesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newUpdateChangesListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.newUpdateChangesListBox.DrawSeperator = true;
            this.newUpdateChangesListBox.ItemHeight = 35;
            this.newUpdateChangesListBox.Location = new System.Drawing.Point(3, 3);
            this.newUpdateChangesListBox.Name = "newUpdateChangesListBox";
            this.newUpdateChangesListBox.RepeatIcons = false;
            this.newUpdateChangesListBox.SeperatorColor = System.Drawing.SystemColors.Control;
            this.newUpdateChangesListBox.Size = new System.Drawing.Size(512, 420);
            this.newUpdateChangesListBox.TabIndex = 0;
            this.newUpdateChangesListBox.UseSelectable = true;
            // 
            // NewUpdatePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.noChangesLabel);
            this.Controls.Add(this.nextTabButton);
            this.Controls.Add(this.newUpdateChangesListBox);
            this.Name = "NewUpdatePage";
            this.Size = new System.Drawing.Size(518, 463);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton nextTabButton;
        private MetroListBox newUpdateChangesListBox;
        private MetroFramework.Controls.MetroLabel noChangesLabel;
    }
}
