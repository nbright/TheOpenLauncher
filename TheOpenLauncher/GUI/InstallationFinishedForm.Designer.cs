namespace TheOpenLauncher {
    partial class InstallationFinishedForm {
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
            this.infoLabel = new MetroFramework.Controls.MetroLabel();
            this.closeButton = new MetroFramework.Controls.MetroButton();
            this.runButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(24, 64);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(248, 38);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "applicationname was succesfully installed.\r\nWould you like to run it now?";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(356, 181);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseSelectable = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(243, 181);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(107, 23);
            this.runButton.TabIndex = 2;
            this.runButton.Text = "Close and run";
            this.runButton.UseSelectable = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // InstallationFinishedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 227);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.infoLabel);
            this.Name = "InstallationFinishedForm";
            this.Text = "applicationname has been installed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel infoLabel;
        private MetroFramework.Controls.MetroButton closeButton;
        private MetroFramework.Controls.MetroButton runButton;
    }
}