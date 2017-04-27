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
            this.GameTabPage = new System.Windows.Forms.TabPage();
            this.GameTabPanel = new System.Windows.Forms.Panel();
            this.DisableTextureStreamingCheckbox = new System.Windows.Forms.CheckBox();
            this.UseAllCoresCheckbox = new System.Windows.Forms.CheckBox();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.LauncherPathTextBox = new System.Windows.Forms.TextBox();
            this.LauncherPathLabel = new System.Windows.Forms.Label();
            this.GameTabPage.SuspendLayout();
            this.GameTabPanel.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // LaunchButton
            // 
            this.LaunchButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LaunchButton.Location = new System.Drawing.Point(10, 267);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(912, 70);
            this.LaunchButton.TabIndex = 0;
            this.LaunchButton.Text = "Launch!";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // GameTabPage
            // 
            this.GameTabPage.Controls.Add(this.GameTabPanel);
            this.GameTabPage.Location = new System.Drawing.Point(10, 48);
            this.GameTabPage.Name = "GameTabPage";
            this.GameTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GameTabPage.Size = new System.Drawing.Size(892, 199);
            this.GameTabPage.TabIndex = 0;
            this.GameTabPage.Text = "Game";
            this.GameTabPage.UseVisualStyleBackColor = true;
            // 
            // GameTabPanel
            // 
            this.GameTabPanel.BackColor = System.Drawing.Color.Transparent;
            this.GameTabPanel.Controls.Add(this.LauncherPathTextBox);
            this.GameTabPanel.Controls.Add(this.UseAllCoresCheckbox);
            this.GameTabPanel.Controls.Add(this.LauncherPathLabel);
            this.GameTabPanel.Controls.Add(this.DisableTextureStreamingCheckbox);
            this.GameTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameTabPanel.Location = new System.Drawing.Point(3, 3);
            this.GameTabPanel.Name = "GameTabPanel";
            this.GameTabPanel.Size = new System.Drawing.Size(886, 193);
            this.GameTabPanel.TabIndex = 7;
            // 
            // DisableTextureStreamingCheckbox
            // 
            this.DisableTextureStreamingCheckbox.AutoSize = true;
            this.DisableTextureStreamingCheckbox.Checked = true;
            this.DisableTextureStreamingCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisableTextureStreamingCheckbox.Location = new System.Drawing.Point(9, 45);
            this.DisableTextureStreamingCheckbox.Name = "DisableTextureStreamingCheckbox";
            this.DisableTextureStreamingCheckbox.Size = new System.Drawing.Size(375, 36);
            this.DisableTextureStreamingCheckbox.TabIndex = 2;
            this.DisableTextureStreamingCheckbox.Text = "Disable texture streaming";
            this.DisableTextureStreamingCheckbox.UseVisualStyleBackColor = true;
            // 
            // UseAllCoresCheckbox
            // 
            this.UseAllCoresCheckbox.AutoSize = true;
            this.UseAllCoresCheckbox.Checked = true;
            this.UseAllCoresCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseAllCoresCheckbox.Location = new System.Drawing.Point(9, 3);
            this.UseAllCoresCheckbox.Name = "UseAllCoresCheckbox";
            this.UseAllCoresCheckbox.Size = new System.Drawing.Size(216, 36);
            this.UseAllCoresCheckbox.TabIndex = 2;
            this.UseAllCoresCheckbox.Text = "Use all cores";
            this.UseAllCoresCheckbox.UseVisualStyleBackColor = true;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.GameTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(10, 10);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(912, 257);
            this.MainTabControl.TabIndex = 7;
            // 
            // LauncherPathTextBox
            // 
            this.LauncherPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LauncherPathTextBox.Location = new System.Drawing.Point(9, 129);
            this.LauncherPathTextBox.Name = "LauncherPathTextBox";
            this.LauncherPathTextBox.Size = new System.Drawing.Size(855, 38);
            this.LauncherPathTextBox.TabIndex = 15;
            // 
            // LauncherPathLabel
            // 
            this.LauncherPathLabel.AutoSize = true;
            this.LauncherPathLabel.Location = new System.Drawing.Point(3, 94);
            this.LauncherPathLabel.Name = "LauncherPathLabel";
            this.LauncherPathLabel.Size = new System.Drawing.Size(205, 32);
            this.LauncherPathLabel.TabIndex = 18;
            this.LauncherPathLabel.Text = "Launcher path:";
            this.LauncherPathLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // BNSBoostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(932, 347);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.LaunchButton);
            this.Name = "BNSBoostForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "BNSBoost";
            this.Load += new System.EventHandler(this.Form_Load);
            this.GameTabPage.ResumeLayout(false);
            this.GameTabPanel.ResumeLayout(false);
            this.GameTabPanel.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.TabPage GameTabPage;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.Panel GameTabPanel;
        private System.Windows.Forms.CheckBox DisableTextureStreamingCheckbox;
        private System.Windows.Forms.CheckBox UseAllCoresCheckbox;
        private System.Windows.Forms.Label LauncherPathLabel;
        private System.Windows.Forms.TextBox LauncherPathTextBox;
    }
}

