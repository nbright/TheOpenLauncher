namespace TheOpenLauncher.VersionPublisher.GUI {
    partial class UpdateInfoPage {
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
            this.changesLabel = new MetroFramework.Controls.MetroLabel();
            this.notesTextBox = new MetroFramework.Controls.MetroTextBox();
            this.updateNotesLabel = new MetroFramework.Controls.MetroLabel();
            this.versionLabel = new MetroFramework.Controls.MetroLabel();
            this.summaryLabel = new MetroFramework.Controls.MetroLabel();
            this.changesListbox = new TheOpenLauncher.VersionPublisher.GUI.MetroListBox();
            this.SuspendLayout();
            // 
            // changesLabel
            // 
            this.changesLabel.AutoSize = true;
            this.changesLabel.Location = new System.Drawing.Point(15, 253);
            this.changesLabel.Name = "changesLabel";
            this.changesLabel.Size = new System.Drawing.Size(62, 19);
            this.changesLabel.TabIndex = 10;
            this.changesLabel.Text = "Changes:";
            // 
            // notesTextBox
            // 
            this.notesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notesTextBox.Lines = new string[] {
        "Loading notes.."};
            this.notesTextBox.Location = new System.Drawing.Point(15, 74);
            this.notesTextBox.MaxLength = 32767;
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.PasswordChar = '\0';
            this.notesTextBox.ReadOnly = true;
            this.notesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.notesTextBox.SelectedText = "";
            this.notesTextBox.Size = new System.Drawing.Size(502, 176);
            this.notesTextBox.TabIndex = 0;
            this.notesTextBox.Text = "Loading notes..";
            this.notesTextBox.UseSelectable = true;
            // 
            // updateNotesLabel
            // 
            this.updateNotesLabel.AutoSize = true;
            this.updateNotesLabel.Location = new System.Drawing.Point(15, 52);
            this.updateNotesLabel.Name = "updateNotesLabel";
            this.updateNotesLabel.Size = new System.Drawing.Size(90, 19);
            this.updateNotesLabel.TabIndex = 8;
            this.updateNotesLabel.Text = "Update notes:";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(15, 29);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(142, 19);
            this.versionLabel.TabIndex = 7;
            this.versionLabel.Text = "Version x - 12/11/2014";
            // 
            // summaryLabel
            // 
            this.summaryLabel.AutoSize = true;
            this.summaryLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.summaryLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.summaryLabel.Location = new System.Drawing.Point(3, 0);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(88, 25);
            this.summaryLabel.TabIndex = 6;
            this.summaryLabel.Text = "Summary";
            // 
            // changesListbox
            // 
            this.changesListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changesListbox.BackColor = System.Drawing.Color.Transparent;
            this.changesListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.changesListbox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.changesListbox.DrawSeperator = true;
            this.changesListbox.ItemHeight = 35;
            this.changesListbox.Location = new System.Drawing.Point(15, 275);
            this.changesListbox.Name = "changesListbox";
            this.changesListbox.RepeatIcons = false;
            this.changesListbox.SeperatorColor = System.Drawing.SystemColors.Control;
            this.changesListbox.Size = new System.Drawing.Size(502, 105);
            this.changesListbox.TabIndex = 1;
            this.changesListbox.UseSelectable = true;
            // 
            // UpdateInfoPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.changesListbox);
            this.Controls.Add(this.changesLabel);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.updateNotesLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.summaryLabel);
            this.Name = "UpdateInfoPage";
            this.Size = new System.Drawing.Size(517, 401);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel changesLabel;
        private MetroFramework.Controls.MetroTextBox notesTextBox;
        private MetroFramework.Controls.MetroLabel updateNotesLabel;
        private MetroFramework.Controls.MetroLabel versionLabel;
        private MetroFramework.Controls.MetroLabel summaryLabel;
        private MetroListBox changesListbox;

    }
}
