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
            this.GameDirectoryPathTextBox = new System.Windows.Forms.TextBox();
            this.GameDirectoryPathLabel = new System.Windows.Forms.Label();
            this.DisableLoadingScreensCheckBox = new System.Windows.Forms.CheckBox();
            this.LauncherPathTextBox = new System.Windows.Forms.TextBox();
            this.UseAllCoresCheckbox = new System.Windows.Forms.CheckBox();
            this.LauncherPathLabel = new System.Windows.Forms.Label();
            this.DisableTextureStreamingCheckbox = new System.Windows.Forms.CheckBox();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.GameTabPage.SuspendLayout();
            this.GameTabPanel.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // LaunchButton
            // 
            this.LaunchButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LaunchButton.Location = new System.Drawing.Point(4, 192);
            this.LaunchButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(351, 29);
            this.LaunchButton.TabIndex = 0;
            this.LaunchButton.Text = "Launch!";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // GameTabPage
            // 
            this.GameTabPage.Controls.Add(this.GameTabPanel);
            this.GameTabPage.Location = new System.Drawing.Point(4, 22);
            this.GameTabPage.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.GameTabPage.Name = "GameTabPage";
            this.GameTabPage.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.GameTabPage.Size = new System.Drawing.Size(343, 162);
            this.GameTabPage.TabIndex = 0;
            this.GameTabPage.Text = "Game";
            this.GameTabPage.UseVisualStyleBackColor = true;
            // 
            // GameTabPanel
            // 
            this.GameTabPanel.BackColor = System.Drawing.Color.Transparent;
            this.GameTabPanel.Controls.Add(this.GameDirectoryPathTextBox);
            this.GameTabPanel.Controls.Add(this.GameDirectoryPathLabel);
            this.GameTabPanel.Controls.Add(this.DisableLoadingScreensCheckBox);
            this.GameTabPanel.Controls.Add(this.LauncherPathTextBox);
            this.GameTabPanel.Controls.Add(this.UseAllCoresCheckbox);
            this.GameTabPanel.Controls.Add(this.LauncherPathLabel);
            this.GameTabPanel.Controls.Add(this.DisableTextureStreamingCheckbox);
            this.GameTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameTabPanel.Location = new System.Drawing.Point(1, 1);
            this.GameTabPanel.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.GameTabPanel.Name = "GameTabPanel";
            this.GameTabPanel.Size = new System.Drawing.Size(341, 160);
            this.GameTabPanel.TabIndex = 7;
            // 
            // GameDirectoryPathTextBox
            // 
            this.GameDirectoryPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameDirectoryPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::BNSBoost.Properties.Settings.Default, "GameDirectoryPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.GameDirectoryPathTextBox.Location = new System.Drawing.Point(3, 117);
            this.GameDirectoryPathTextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.GameDirectoryPathTextBox.Name = "GameDirectoryPathTextBox";
            this.GameDirectoryPathTextBox.Size = new System.Drawing.Size(333, 20);
            this.GameDirectoryPathTextBox.TabIndex = 21;
            this.GameDirectoryPathTextBox.Text = global::BNSBoost.Properties.Settings.Default.GameDirectoryPath;
            // 
            // GameDirectoryPathLabel
            // 
            this.GameDirectoryPathLabel.AutoSize = true;
            this.GameDirectoryPathLabel.Location = new System.Drawing.Point(0, 102);
            this.GameDirectoryPathLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.GameDirectoryPathLabel.Name = "GameDirectoryPathLabel";
            this.GameDirectoryPathLabel.Size = new System.Drawing.Size(105, 13);
            this.GameDirectoryPathLabel.TabIndex = 20;
            this.GameDirectoryPathLabel.Text = "Game directory path:";
            // 
            // DisableLoadingScreensCheckBox
            // 
            this.DisableLoadingScreensCheckBox.AutoSize = true;
            this.DisableLoadingScreensCheckBox.Checked = global::BNSBoost.Properties.Settings.Default.NoLoadingScreens;
            this.DisableLoadingScreensCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "NoLoadingScreens", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DisableLoadingScreensCheckBox.Location = new System.Drawing.Point(3, 36);
            this.DisableLoadingScreensCheckBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.DisableLoadingScreensCheckBox.Name = "DisableLoadingScreensCheckBox";
            this.DisableLoadingScreensCheckBox.Size = new System.Drawing.Size(138, 17);
            this.DisableLoadingScreensCheckBox.TabIndex = 19;
            this.DisableLoadingScreensCheckBox.Text = "Disable loading screens";
            this.DisableLoadingScreensCheckBox.UseVisualStyleBackColor = true;
            this.DisableLoadingScreensCheckBox.CheckedChanged += new System.EventHandler(this.DisableLoadingScreensCheckBox_CheckedChanged);
            // 
            // LauncherPathTextBox
            // 
            this.LauncherPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LauncherPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::BNSBoost.Properties.Settings.Default, "NCLauncherRPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LauncherPathTextBox.Location = new System.Drawing.Point(3, 75);
            this.LauncherPathTextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.LauncherPathTextBox.Name = "LauncherPathTextBox";
            this.LauncherPathTextBox.Size = new System.Drawing.Size(332, 20);
            this.LauncherPathTextBox.TabIndex = 15;
            this.LauncherPathTextBox.Text = global::BNSBoost.Properties.Settings.Default.NCLauncherRPath;
            // 
            // UseAllCoresCheckbox
            // 
            this.UseAllCoresCheckbox.AutoSize = true;
            this.UseAllCoresCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.UseAllCores;
            this.UseAllCoresCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseAllCoresCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "UseAllCores", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.UseAllCoresCheckbox.Location = new System.Drawing.Point(3, 1);
            this.UseAllCoresCheckbox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.UseAllCoresCheckbox.Name = "UseAllCoresCheckbox";
            this.UseAllCoresCheckbox.Size = new System.Drawing.Size(87, 17);
            this.UseAllCoresCheckbox.TabIndex = 2;
            this.UseAllCoresCheckbox.Text = "Use all cores";
            this.UseAllCoresCheckbox.UseVisualStyleBackColor = true;
            this.UseAllCoresCheckbox.CheckedChanged += new System.EventHandler(this.UseAllCoresCheckbox_CheckedChanged);
            // 
            // LauncherPathLabel
            // 
            this.LauncherPathLabel.AutoSize = true;
            this.LauncherPathLabel.Location = new System.Drawing.Point(1, 61);
            this.LauncherPathLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.LauncherPathLabel.Name = "LauncherPathLabel";
            this.LauncherPathLabel.Size = new System.Drawing.Size(79, 13);
            this.LauncherPathLabel.TabIndex = 18;
            this.LauncherPathLabel.Text = "Launcher path:";
            this.LauncherPathLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // DisableTextureStreamingCheckbox
            // 
            this.DisableTextureStreamingCheckbox.AutoSize = true;
            this.DisableTextureStreamingCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.NoTextureStreaming;
            this.DisableTextureStreamingCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisableTextureStreamingCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "NoTextureStreaming", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DisableTextureStreamingCheckbox.Location = new System.Drawing.Point(3, 19);
            this.DisableTextureStreamingCheckbox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.DisableTextureStreamingCheckbox.Name = "DisableTextureStreamingCheckbox";
            this.DisableTextureStreamingCheckbox.Size = new System.Drawing.Size(144, 17);
            this.DisableTextureStreamingCheckbox.TabIndex = 2;
            this.DisableTextureStreamingCheckbox.Text = "Disable texture streaming";
            this.DisableTextureStreamingCheckbox.UseVisualStyleBackColor = true;
            this.DisableTextureStreamingCheckbox.CheckedChanged += new System.EventHandler(this.DisableTextureStreamingCheckbox_CheckedChanged);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.GameTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(4, 4);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(351, 188);
            this.MainTabControl.TabIndex = 7;
            // 
            // BNSBoostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(359, 225);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.LaunchButton);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "BNSBoostForm";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.TextBox GameDirectoryPathTextBox;
        private System.Windows.Forms.Label GameDirectoryPathLabel;
        private System.Windows.Forms.CheckBox DisableLoadingScreensCheckBox;
    }
}

