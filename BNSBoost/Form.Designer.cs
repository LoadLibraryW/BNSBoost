namespace BNSBoost
{
    partial class BNSBoostForm
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
            this.LaunchButton = new System.Windows.Forms.Button();
            this.UseAllCoresCheckbox = new System.Windows.Forms.CheckBox();
            this.DisableTextureStreamingCheckbox = new System.Windows.Forms.CheckBox();
            this.LauncherPathLabel = new System.Windows.Forms.Label();
            this.GithubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.LauncherPathTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LaunchButton
            // 
            this.LaunchButton.Location = new System.Drawing.Point(516, 221);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(176, 70);
            this.LaunchButton.TabIndex = 0;
            this.LaunchButton.Text = "Launch!";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // UseAllCoresCheckbox
            // 
            this.UseAllCoresCheckbox.AutoSize = true;
            this.UseAllCoresCheckbox.Checked = true;
            this.UseAllCoresCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseAllCoresCheckbox.Enabled = false;
            this.UseAllCoresCheckbox.Location = new System.Drawing.Point(26, 28);
            this.UseAllCoresCheckbox.Name = "UseAllCoresCheckbox";
            this.UseAllCoresCheckbox.Size = new System.Drawing.Size(216, 36);
            this.UseAllCoresCheckbox.TabIndex = 1;
            this.UseAllCoresCheckbox.Text = "Use all cores";
            this.UseAllCoresCheckbox.UseVisualStyleBackColor = true;
            // 
            // DisableTextureStreamingCheckbox
            // 
            this.DisableTextureStreamingCheckbox.AutoSize = true;
            this.DisableTextureStreamingCheckbox.Checked = true;
            this.DisableTextureStreamingCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisableTextureStreamingCheckbox.Enabled = false;
            this.DisableTextureStreamingCheckbox.Location = new System.Drawing.Point(26, 84);
            this.DisableTextureStreamingCheckbox.Name = "DisableTextureStreamingCheckbox";
            this.DisableTextureStreamingCheckbox.Size = new System.Drawing.Size(375, 36);
            this.DisableTextureStreamingCheckbox.TabIndex = 2;
            this.DisableTextureStreamingCheckbox.Text = "Disable texture streaming";
            this.DisableTextureStreamingCheckbox.UseVisualStyleBackColor = true;
            // 
            // LauncherPathLabel
            // 
            this.LauncherPathLabel.AutoSize = true;
            this.LauncherPathLabel.Location = new System.Drawing.Point(20, 138);
            this.LauncherPathLabel.Name = "LauncherPathLabel";
            this.LauncherPathLabel.Size = new System.Drawing.Size(205, 32);
            this.LauncherPathLabel.TabIndex = 4;
            this.LauncherPathLabel.Text = "Launcher path:";
            // 
            // GithubLinkLabel
            // 
            this.GithubLinkLabel.AutoSize = true;
            this.GithubLinkLabel.Location = new System.Drawing.Point(12, 259);
            this.GithubLinkLabel.Name = "GithubLinkLabel";
            this.GithubLinkLabel.Size = new System.Drawing.Size(100, 32);
            this.GithubLinkLabel.TabIndex = 5;
            this.GithubLinkLabel.TabStop = true;
            this.GithubLinkLabel.Text = "Github";
            // 
            // LauncherPathTextBox
            // 
            this.LauncherPathTextBox.Location = new System.Drawing.Point(221, 135);
            this.LauncherPathTextBox.Name = "LauncherPathTextBox";
            this.LauncherPathTextBox.Size = new System.Drawing.Size(471, 38);
            this.LauncherPathTextBox.TabIndex = 6;
            // 
            // BNSBoostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 306);
            this.Controls.Add(this.LauncherPathTextBox);
            this.Controls.Add(this.GithubLinkLabel);
            this.Controls.Add(this.LauncherPathLabel);
            this.Controls.Add(this.DisableTextureStreamingCheckbox);
            this.Controls.Add(this.UseAllCoresCheckbox);
            this.Controls.Add(this.LaunchButton);
            this.Name = "BNSBoostForm";
            this.Text = "BNSBoost";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.CheckBox UseAllCoresCheckbox;
        private System.Windows.Forms.CheckBox DisableTextureStreamingCheckbox;
        private System.Windows.Forms.Label LauncherPathLabel;
        private System.Windows.Forms.LinkLabel GithubLinkLabel;
        private System.Windows.Forms.TextBox LauncherPathTextBox;
    }
}

