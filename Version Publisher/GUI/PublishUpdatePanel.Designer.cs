namespace TheOpenLauncher.VersionPublisher.GUI {
    partial class PublishUpdatePanel {
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
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.versionTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.newNotesTextBox = new MetroFramework.Controls.MetroTextBox();
            this.summaryTextBox = new MetroFramework.Controls.MetroTextBox();
            this.publishUpdateButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(9, 83);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(52, 19);
            this.metroLabel4.TabIndex = 15;
            this.metroLabel4.Text = "Version";
            // 
            // versionTextBox
            // 
            this.versionTextBox.Lines = new string[0];
            this.versionTextBox.Location = new System.Drawing.Point(16, 105);
            this.versionTextBox.MaxLength = 32767;
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.PasswordChar = '\0';
            this.versionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.versionTextBox.SelectedText = "";
            this.versionTextBox.Size = new System.Drawing.Size(95, 23);
            this.versionTextBox.TabIndex = 1;
            this.versionTextBox.UseSelectable = true;
            this.versionTextBox.TextChanged += new System.EventHandler(this.versionTextBox_TextChanged);
            this.versionTextBox.Enter += new System.EventHandler(this.versionTextBox_Enter);
            this.versionTextBox.Leave += new System.EventHandler(this.versionTextBox_Leave);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(9, 137);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(43, 19);
            this.metroLabel3.TabIndex = 13;
            this.metroLabel3.Text = "Notes";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(9, 31);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(65, 19);
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "Summary";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(3, 3);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(3);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(108, 25);
            this.metroLabel1.TabIndex = 11;
            this.metroLabel1.Text = "New update";
            // 
            // newNotesTextBox
            // 
            this.newNotesTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.newNotesTextBox.Lines = new string[] {
        "Update notes"};
            this.newNotesTextBox.Location = new System.Drawing.Point(16, 159);
            this.newNotesTextBox.MaxLength = 32767;
            this.newNotesTextBox.Multiline = true;
            this.newNotesTextBox.Name = "newNotesTextBox";
            this.newNotesTextBox.PasswordChar = '\0';
            this.newNotesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.newNotesTextBox.SelectedText = "";
            this.newNotesTextBox.Size = new System.Drawing.Size(452, 194);
            this.newNotesTextBox.TabIndex = 2;
            this.newNotesTextBox.Text = "Update notes";
            this.newNotesTextBox.UseCustomForeColor = true;
            this.newNotesTextBox.UseSelectable = true;
            this.newNotesTextBox.TextChanged += new System.EventHandler(this.newNotesTextBox_TextChanged);
            this.newNotesTextBox.Enter += new System.EventHandler(this.newNotesTextBox_Enter);
            this.newNotesTextBox.Leave += new System.EventHandler(this.newNotesTextBox_Leave);
            // 
            // summaryTextBox
            // 
            this.summaryTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.summaryTextBox.Lines = new string[] {
        "Summary"};
            this.summaryTextBox.Location = new System.Drawing.Point(16, 53);
            this.summaryTextBox.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.summaryTextBox.MaxLength = 32767;
            this.summaryTextBox.Name = "summaryTextBox";
            this.summaryTextBox.PasswordChar = '\0';
            this.summaryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.summaryTextBox.SelectedText = "";
            this.summaryTextBox.Size = new System.Drawing.Size(345, 23);
            this.summaryTextBox.TabIndex = 0;
            this.summaryTextBox.Text = "Summary";
            this.summaryTextBox.UseCustomForeColor = true;
            this.summaryTextBox.UseSelectable = true;
            this.summaryTextBox.TextChanged += new System.EventHandler(this.summaryTextBox_TextChanged);
            this.summaryTextBox.Enter += new System.EventHandler(this.summaryTextBox_Enter);
            this.summaryTextBox.Leave += new System.EventHandler(this.summaryTextBox_Leave);
            // 
            // publishUpdateButton
            // 
            this.publishUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.publishUpdateButton.Enabled = false;
            this.publishUpdateButton.Location = new System.Drawing.Point(537, 453);
            this.publishUpdateButton.Name = "publishUpdateButton";
            this.publishUpdateButton.Size = new System.Drawing.Size(101, 31);
            this.publishUpdateButton.TabIndex = 3;
            this.publishUpdateButton.Text = "Publish update";
            this.publishUpdateButton.UseSelectable = true;
            this.publishUpdateButton.Click += new System.EventHandler(this.publishUpdateButton_Click);
            // 
            // PublishUpdatePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.versionTextBox);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.newNotesTextBox);
            this.Controls.Add(this.summaryTextBox);
            this.Controls.Add(this.publishUpdateButton);
            this.Name = "PublishUpdatePanel";
            this.Size = new System.Drawing.Size(641, 487);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox versionTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox newNotesTextBox;
        private MetroFramework.Controls.MetroTextBox summaryTextBox;
        private MetroFramework.Controls.MetroButton publishUpdateButton;

    }
}
