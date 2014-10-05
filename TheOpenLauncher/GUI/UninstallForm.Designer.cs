namespace TheOpenLauncher
{
    partial class UninstallForm
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
            this.uninstallInfo = new MetroFramework.Controls.MetroLabel();
            this.removeButton = new MetroFramework.Controls.MetroButton();
            this.cancelButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // uninstallInfo
            // 
            this.uninstallInfo.AutoSize = true;
            this.uninstallInfo.Location = new System.Drawing.Point(24, 64);
            this.uninstallInfo.Name = "uninstallInfo";
            this.uninstallInfo.Size = new System.Drawing.Size(317, 38);
            this.uninstallInfo.TabIndex = 0;
            this.uninstallInfo.Text = "Are you sure you want to remove productname and \r\nall of its components from your" +
    " computer?";
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(321, 182);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 1;
            this.removeButton.Text = "Remove";
            this.removeButton.UseSelectable = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(240, 182);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseSelectable = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // UninstallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 228);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.uninstallInfo);
            this.Name = "UninstallForm";
            this.Resizable = false;
            this.Text = "productname uninstallation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel uninstallInfo;
        private MetroFramework.Controls.MetroButton removeButton;
        private MetroFramework.Controls.MetroButton cancelButton;
    }
}