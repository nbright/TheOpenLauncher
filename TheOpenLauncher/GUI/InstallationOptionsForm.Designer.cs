namespace TheOpenLauncher
{
    partial class InstallationOptionsForm
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
            this.filePickerTextBox = new MetroFramework.Controls.MetroTextBox();
            this.filePickerLabel = new MetroFramework.Controls.MetroLabel();
            this.filePickerButton = new MetroFramework.Controls.MetroButton();
            this.desktopShortcutCheckbox = new MetroFramework.Controls.MetroCheckBox();
            this.shortcutsLabel = new MetroFramework.Controls.MetroLabel();
            this.startmenuEntryCheckbox = new MetroFramework.Controls.MetroCheckBox();
            this.saveButton = new MetroFramework.Controls.MetroButton();
            this.cancelButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // filePickerTextBox
            // 
            this.filePickerTextBox.Lines = new string[0];
            this.filePickerTextBox.Location = new System.Drawing.Point(46, 82);
            this.filePickerTextBox.MaxLength = 32767;
            this.filePickerTextBox.Name = "filePickerTextBox";
            this.filePickerTextBox.PasswordChar = '\0';
            this.filePickerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.filePickerTextBox.SelectedText = "";
            this.filePickerTextBox.Size = new System.Drawing.Size(300, 23);
            this.filePickerTextBox.TabIndex = 0;
            this.filePickerTextBox.UseSelectable = true;
            this.filePickerTextBox.UseStyleColors = true;
            this.filePickerTextBox.TextChanged += new System.EventHandler(this.filePickerTextBox_TextChanged);
            // 
            // filePickerLabel
            // 
            this.filePickerLabel.AutoSize = true;
            this.filePickerLabel.Location = new System.Drawing.Point(23, 60);
            this.filePickerLabel.Name = "filePickerLabel";
            this.filePickerLabel.Size = new System.Drawing.Size(109, 19);
            this.filePickerLabel.TabIndex = 1;
            this.filePickerLabel.Text = "Installation folder";
            // 
            // filePickerButton
            // 
            this.filePickerButton.Location = new System.Drawing.Point(352, 82);
            this.filePickerButton.Name = "filePickerButton";
            this.filePickerButton.Size = new System.Drawing.Size(75, 23);
            this.filePickerButton.TabIndex = 2;
            this.filePickerButton.Text = "Choose..";
            this.filePickerButton.UseSelectable = true;
            this.filePickerButton.Click += new System.EventHandler(this.filePickerButton_Click);
            // 
            // desktopShortcutCheckbox
            // 
            this.desktopShortcutCheckbox.AutoSize = true;
            this.desktopShortcutCheckbox.Location = new System.Drawing.Point(46, 134);
            this.desktopShortcutCheckbox.Name = "desktopShortcutCheckbox";
            this.desktopShortcutCheckbox.Size = new System.Drawing.Size(149, 15);
            this.desktopShortcutCheckbox.TabIndex = 3;
            this.desktopShortcutCheckbox.Text = "Create desktop shortcut";
            this.desktopShortcutCheckbox.UseSelectable = true;
            // 
            // shortcutsLabel
            // 
            this.shortcutsLabel.AutoSize = true;
            this.shortcutsLabel.Location = new System.Drawing.Point(24, 112);
            this.shortcutsLabel.Name = "shortcutsLabel";
            this.shortcutsLabel.Size = new System.Drawing.Size(62, 19);
            this.shortcutsLabel.TabIndex = 4;
            this.shortcutsLabel.Text = "Shortcuts";
            // 
            // startmenuEntryCheckbox
            // 
            this.startmenuEntryCheckbox.AutoSize = true;
            this.startmenuEntryCheckbox.Location = new System.Drawing.Point(46, 156);
            this.startmenuEntryCheckbox.Name = "startmenuEntryCheckbox";
            this.startmenuEntryCheckbox.Size = new System.Drawing.Size(147, 15);
            this.startmenuEntryCheckbox.TabIndex = 5;
            this.startmenuEntryCheckbox.Text = "Create start menu entry";
            this.startmenuEntryCheckbox.UseSelectable = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(352, 181);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseSelectable = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(271, 181);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseSelectable = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // InstallationOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 227);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.startmenuEntryCheckbox);
            this.Controls.Add(this.shortcutsLabel);
            this.Controls.Add(this.desktopShortcutCheckbox);
            this.Controls.Add(this.filePickerButton);
            this.Controls.Add(this.filePickerLabel);
            this.Controls.Add(this.filePickerTextBox);
            this.Name = "InstallationOptionsForm";
            this.Resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.InstallationOptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox filePickerTextBox;
        private MetroFramework.Controls.MetroLabel filePickerLabel;
        private MetroFramework.Controls.MetroButton filePickerButton;
        private MetroFramework.Controls.MetroCheckBox desktopShortcutCheckbox;
        private MetroFramework.Controls.MetroLabel shortcutsLabel;
        private MetroFramework.Controls.MetroCheckBox startmenuEntryCheckbox;
        private MetroFramework.Controls.MetroButton saveButton;
        private MetroFramework.Controls.MetroButton cancelButton;
    }
}