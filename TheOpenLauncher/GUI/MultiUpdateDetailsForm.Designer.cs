namespace TheOpenLauncher
{
    partial class MultiUpdateDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiUpdateDetailsForm));
            this.infoLabel = new MetroFramework.Controls.MetroLabel();
            this.cancelButton = new MetroFramework.Controls.MetroButton();
            this.updateButton = new MetroFramework.Controls.MetroButton();
            this.updateNotesPanel = new MetroFramework.Controls.MetroPanel();
            this.detailsTextBox = new MetroFramework.Controls.MetroTextBox();
            this.updateNotesComboBox = new MetroFramework.Controls.MetroComboBox();
            this.updateNotesDropdownLabel = new MetroFramework.Controls.MetroLabel();
            this.updateNotesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(23, 60);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(370, 76);
            this.infoLabel.TabIndex = 6;
            this.infoLabel.Text = "Multiple updates for productname have been released. \r\nInstalling these updates i" +
    "s recommended for optimal security, \r\nstability and functionality.\r\n";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(23, 305);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseSelectable = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Enabled = false;
            this.updateButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.updateButton.Highlight = true;
            this.updateButton.Location = new System.Drawing.Point(285, 298);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(130, 30);
            this.updateButton.TabIndex = 4;
            this.updateButton.Text = "Apply # updates";
            this.updateButton.UseSelectable = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // updateNotesPanel
            // 
            this.updateNotesPanel.Controls.Add(this.detailsTextBox);
            this.updateNotesPanel.Controls.Add(this.updateNotesComboBox);
            this.updateNotesPanel.Controls.Add(this.updateNotesDropdownLabel);
            this.updateNotesPanel.HorizontalScrollbarBarColor = true;
            this.updateNotesPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.updateNotesPanel.HorizontalScrollbarSize = 10;
            this.updateNotesPanel.Location = new System.Drawing.Point(23, 139);
            this.updateNotesPanel.Name = "updateNotesPanel";
            this.updateNotesPanel.Size = new System.Drawing.Size(392, 153);
            this.updateNotesPanel.TabIndex = 7;
            this.updateNotesPanel.VerticalScrollbarBarColor = true;
            this.updateNotesPanel.VerticalScrollbarHighlightOnWheel = false;
            this.updateNotesPanel.VerticalScrollbarSize = 10;
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.Lines = new string[] {
        "Loading notes..."};
            this.detailsTextBox.Location = new System.Drawing.Point(4, 36);
            this.detailsTextBox.MaxLength = 32767;
            this.detailsTextBox.Multiline = true;
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.PasswordChar = '\0';
            this.detailsTextBox.ReadOnly = true;
            this.detailsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.detailsTextBox.SelectedText = "";
            this.detailsTextBox.Size = new System.Drawing.Size(385, 114);
            this.detailsTextBox.TabIndex = 4;
            this.detailsTextBox.Text = "Loading notes...";
            this.detailsTextBox.UseSelectable = true;
            // 
            // updateNotesComboBox
            // 
            this.updateNotesComboBox.FormattingEnabled = true;
            this.updateNotesComboBox.ItemHeight = 23;
            this.updateNotesComboBox.Location = new System.Drawing.Point(155, 1);
            this.updateNotesComboBox.Name = "updateNotesComboBox";
            this.updateNotesComboBox.Size = new System.Drawing.Size(234, 29);
            this.updateNotesComboBox.TabIndex = 3;
            this.updateNotesComboBox.UseSelectable = true;
            this.updateNotesComboBox.SelectedIndexChanged += new System.EventHandler(this.updateNotesCombobox_SelectedIndexChanged);
            // 
            // updateNotesDropdownLabel
            // 
            this.updateNotesDropdownLabel.AutoSize = true;
            this.updateNotesDropdownLabel.Location = new System.Drawing.Point(4, 4);
            this.updateNotesDropdownLabel.Name = "updateNotesDropdownLabel";
            this.updateNotesDropdownLabel.Size = new System.Drawing.Size(144, 19);
            this.updateNotesDropdownLabel.TabIndex = 2;
            this.updateNotesDropdownLabel.Text = "Show update notes for:";
            // 
            // MultiUpdateDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 351);
            this.Controls.Add(this.updateNotesPanel);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.updateButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MultiUpdateDetailsForm";
            this.Text = "Updates are available";
            this.Load += new System.EventHandler(this.MultiUpdateDetailsForm_Load);
            this.updateNotesPanel.ResumeLayout(false);
            this.updateNotesPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel infoLabel;
        private MetroFramework.Controls.MetroButton cancelButton;
        private MetroFramework.Controls.MetroButton updateButton;
        private MetroFramework.Controls.MetroPanel updateNotesPanel;
        private MetroFramework.Controls.MetroComboBox updateNotesComboBox;
        private MetroFramework.Controls.MetroLabel updateNotesDropdownLabel;
        private MetroFramework.Controls.MetroTextBox detailsTextBox;
    }
}