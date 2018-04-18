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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Decompiling...");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("config.dat", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Decompiling...");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("config64.dat", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Decompiling...");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("xml.dat", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Decompiling...");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("xml64.dat", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BNSBoostForm));
            this.LaunchButton = new System.Windows.Forms.Button();
            this.GameTabPage = new System.Windows.Forms.TabPage();
            this.GameTabPanel = new System.Windows.Forms.Panel();
            this.BitnessLabel = new System.Windows.Forms.Label();
            this.Bit64RadioButton = new System.Windows.Forms.RadioButton();
            this.Bit32RadioButton = new System.Windows.Forms.RadioButton();
            this.PingLabel = new System.Windows.Forms.Label();
            this.DisableX3Checkbox = new System.Windows.Forms.CheckBox();
            this.RegionComboBox = new System.Windows.Forms.ComboBox();
            this.RegionLabel = new System.Windows.Forms.Label();
            this.GameDirectoryPathTextBox = new System.Windows.Forms.TextBox();
            this.GameDirectoryPathLabel = new System.Windows.Forms.Label();
            this.DisableLoadingScreensCheckBox = new System.Windows.Forms.CheckBox();
            this.LauncherPathTextBox = new System.Windows.Forms.TextBox();
            this.UseAllCoresCheckbox = new System.Windows.Forms.CheckBox();
            this.LauncherPathLabel = new System.Windows.Forms.Label();
            this.DisableTextureStreamingCheckbox = new System.Windows.Forms.CheckBox();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.PatchSelectTabPage = new System.Windows.Forms.TabPage();
            this.PatchTabPanel = new System.Windows.Forms.Panel();
            this.DisableAFKDisconnectCheckbox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LatencyDurationUpDown = new System.Windows.Forms.NumericUpDown();
            this.LatencyDisplayCheckbox = new System.Windows.Forms.CheckBox();
            this.FastExitCheckbox = new System.Windows.Forms.CheckBox();
            this.DisableEULACheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowOpposingTeamCheckbox = new System.Windows.Forms.CheckBox();
            this.ShowAverageScoreCheckbox = new System.Windows.Forms.CheckBox();
            this.SkillbookDelayUpDown = new System.Windows.Forms.NumericUpDown();
            this.EnableSkillbookDelayCheckbox = new System.Windows.Forms.CheckBox();
            this.EnableOptimizedModeCheckbox = new System.Windows.Forms.CheckBox();
            this.ShowDPSMeterCheckbox = new System.Windows.Forms.CheckBox();
            this.DatEditorTabPage = new System.Windows.Forms.TabPage();
            this.DATProgressBar = new System.Windows.Forms.ProgressBar();
            this.DatEditorButtonTable = new System.Windows.Forms.TableLayoutPanel();
            this.OpenDatFileButton = new System.Windows.Forms.Button();
            this.RecompileDatButton = new System.Windows.Forms.Button();
            this.RestoreDatButton = new System.Windows.Forms.Button();
            this.SettingsTabPage = new System.Windows.Forms.TabPage();
            this.UpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.FileDataTreeView = new BNSBoost.BufferedTreeView();
            this.bNSBoostFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GameTabPage.SuspendLayout();
            this.GameTabPanel.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.PatchSelectTabPage.SuspendLayout();
            this.PatchTabPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LatencyDurationUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkillbookDelayUpDown)).BeginInit();
            this.DatEditorTabPage.SuspendLayout();
            this.DatEditorButtonTable.SuspendLayout();
            this.SettingsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bNSBoostFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LaunchButton
            // 
            this.LaunchButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LaunchButton.Location = new System.Drawing.Point(11, 579);
            this.LaunchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(873, 69);
            this.LaunchButton.TabIndex = 0;
            this.LaunchButton.Text = "Launch!";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // GameTabPage
            // 
            this.GameTabPage.Controls.Add(this.GameTabPanel);
            this.GameTabPage.Location = new System.Drawing.Point(10, 48);
            this.GameTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GameTabPage.Name = "GameTabPage";
            this.GameTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GameTabPage.Size = new System.Drawing.Size(853, 511);
            this.GameTabPage.TabIndex = 0;
            this.GameTabPage.Text = "Game";
            this.GameTabPage.UseVisualStyleBackColor = true;
            // 
            // GameTabPanel
            // 
            this.GameTabPanel.BackColor = System.Drawing.Color.Transparent;
            this.GameTabPanel.Controls.Add(this.BitnessLabel);
            this.GameTabPanel.Controls.Add(this.Bit64RadioButton);
            this.GameTabPanel.Controls.Add(this.Bit32RadioButton);
            this.GameTabPanel.Controls.Add(this.PingLabel);
            this.GameTabPanel.Controls.Add(this.DisableX3Checkbox);
            this.GameTabPanel.Controls.Add(this.RegionComboBox);
            this.GameTabPanel.Controls.Add(this.RegionLabel);
            this.GameTabPanel.Controls.Add(this.GameDirectoryPathTextBox);
            this.GameTabPanel.Controls.Add(this.GameDirectoryPathLabel);
            this.GameTabPanel.Controls.Add(this.DisableLoadingScreensCheckBox);
            this.GameTabPanel.Controls.Add(this.LauncherPathTextBox);
            this.GameTabPanel.Controls.Add(this.UseAllCoresCheckbox);
            this.GameTabPanel.Controls.Add(this.LauncherPathLabel);
            this.GameTabPanel.Controls.Add(this.DisableTextureStreamingCheckbox);
            this.GameTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameTabPanel.Location = new System.Drawing.Point(3, 2);
            this.GameTabPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GameTabPanel.Name = "GameTabPanel";
            this.GameTabPanel.Size = new System.Drawing.Size(847, 507);
            this.GameTabPanel.TabIndex = 7;
            // 
            // BitnessLabel
            // 
            this.BitnessLabel.AutoSize = true;
            this.BitnessLabel.Location = new System.Drawing.Point(7, 381);
            this.BitnessLabel.Name = "BitnessLabel";
            this.BitnessLabel.Size = new System.Drawing.Size(195, 32);
            this.BitnessLabel.TabIndex = 28;
            this.BitnessLabel.Text = "Client bitness:";
            // 
            // Bit64RadioButton
            // 
            this.Bit64RadioButton.AutoSize = true;
            this.Bit64RadioButton.Checked = global::BNSBoost.Properties.Settings.Default.Is64Bit;
            this.Bit64RadioButton.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "Is64Bit", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Bit64RadioButton.Location = new System.Drawing.Point(332, 379);
            this.Bit64RadioButton.Name = "Bit64RadioButton";
            this.Bit64RadioButton.Size = new System.Drawing.Size(122, 36);
            this.Bit64RadioButton.TabIndex = 27;
            this.Bit64RadioButton.TabStop = true;
            this.Bit64RadioButton.Text = "64 bit";
            this.Bit64RadioButton.UseVisualStyleBackColor = true;
            // 
            // Bit32RadioButton
            // 
            this.Bit32RadioButton.AutoSize = true;
            this.Bit32RadioButton.Location = new System.Drawing.Point(204, 379);
            this.Bit32RadioButton.Name = "Bit32RadioButton";
            this.Bit32RadioButton.Size = new System.Drawing.Size(122, 36);
            this.Bit32RadioButton.TabIndex = 26;
            this.Bit32RadioButton.Text = "32 bit";
            this.Bit32RadioButton.UseVisualStyleBackColor = true;
            // 
            // PingLabel
            // 
            this.PingLabel.AutoSize = true;
            this.PingLabel.Location = new System.Drawing.Point(271, 445);
            this.PingLabel.Name = "PingLabel";
            this.PingLabel.Size = new System.Drawing.Size(230, 32);
            this.PingLabel.TabIndex = 25;
            this.PingLabel.Text = "Game delay: N/A";
            // 
            // DisableX3Checkbox
            // 
            this.DisableX3Checkbox.AutoSize = true;
            this.DisableX3Checkbox.Checked = global::BNSBoost.Properties.Settings.Default.DisableX3;
            this.DisableX3Checkbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "DisableX3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DisableX3Checkbox.Location = new System.Drawing.Point(8, 127);
            this.DisableX3Checkbox.Name = "DisableX3Checkbox";
            this.DisableX3Checkbox.Size = new System.Drawing.Size(321, 36);
            this.DisableX3Checkbox.TabIndex = 24;
            this.DisableX3Checkbox.Text = "Disable XIGNCODE3";
            this.DisableX3Checkbox.UseVisualStyleBackColor = true;
            // 
            // RegionComboBox
            // 
            this.RegionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RegionComboBox.FormattingEnabled = true;
            this.RegionComboBox.Items.AddRange(new object[] {
            "NA",
            "EU"});
            this.RegionComboBox.Location = new System.Drawing.Point(128, 440);
            this.RegionComboBox.Name = "RegionComboBox";
            this.RegionComboBox.Size = new System.Drawing.Size(133, 39);
            this.RegionComboBox.TabIndex = 23;
            this.RegionComboBox.Tag = "";
            // 
            // RegionLabel
            // 
            this.RegionLabel.AutoSize = true;
            this.RegionLabel.Location = new System.Drawing.Point(8, 447);
            this.RegionLabel.Name = "RegionLabel";
            this.RegionLabel.Size = new System.Drawing.Size(114, 32);
            this.RegionLabel.TabIndex = 22;
            this.RegionLabel.Text = "Region:";
            // 
            // GameDirectoryPathTextBox
            // 
            this.GameDirectoryPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameDirectoryPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::BNSBoost.Properties.Settings.Default, "GameDirectoryPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.GameDirectoryPathTextBox.Location = new System.Drawing.Point(8, 311);
            this.GameDirectoryPathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GameDirectoryPathTextBox.Name = "GameDirectoryPathTextBox";
            this.GameDirectoryPathTextBox.Size = new System.Drawing.Size(819, 38);
            this.GameDirectoryPathTextBox.TabIndex = 21;
            this.GameDirectoryPathTextBox.Text = global::BNSBoost.Properties.Settings.Default.GameDirectoryPath;
            // 
            // GameDirectoryPathLabel
            // 
            this.GameDirectoryPathLabel.AutoSize = true;
            this.GameDirectoryPathLabel.Location = new System.Drawing.Point(0, 275);
            this.GameDirectoryPathLabel.Name = "GameDirectoryPathLabel";
            this.GameDirectoryPathLabel.Size = new System.Drawing.Size(279, 32);
            this.GameDirectoryPathLabel.TabIndex = 20;
            this.GameDirectoryPathLabel.Text = "Game directory path:";
            // 
            // DisableLoadingScreensCheckBox
            // 
            this.DisableLoadingScreensCheckBox.AutoSize = true;
            this.DisableLoadingScreensCheckBox.Checked = global::BNSBoost.Properties.Settings.Default.NoLoadingScreens;
            this.DisableLoadingScreensCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "NoLoadingScreens", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DisableLoadingScreensCheckBox.Location = new System.Drawing.Point(8, 87);
            this.DisableLoadingScreensCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DisableLoadingScreensCheckBox.Name = "DisableLoadingScreensCheckBox";
            this.DisableLoadingScreensCheckBox.Size = new System.Drawing.Size(356, 36);
            this.DisableLoadingScreensCheckBox.TabIndex = 19;
            this.DisableLoadingScreensCheckBox.Text = "Disable loading screens";
            this.DisableLoadingScreensCheckBox.UseVisualStyleBackColor = true;
            // 
            // LauncherPathTextBox
            // 
            this.LauncherPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LauncherPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::BNSBoost.Properties.Settings.Default, "NCLauncherRPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LauncherPathTextBox.Location = new System.Drawing.Point(8, 211);
            this.LauncherPathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LauncherPathTextBox.Name = "LauncherPathTextBox";
            this.LauncherPathTextBox.Size = new System.Drawing.Size(817, 38);
            this.LauncherPathTextBox.TabIndex = 15;
            this.LauncherPathTextBox.Text = global::BNSBoost.Properties.Settings.Default.NCLauncherRPath;
            // 
            // UseAllCoresCheckbox
            // 
            this.UseAllCoresCheckbox.AutoSize = true;
            this.UseAllCoresCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.UseAllCores;
            this.UseAllCoresCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseAllCoresCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "UseAllCores", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.UseAllCoresCheckbox.Location = new System.Drawing.Point(8, 2);
            this.UseAllCoresCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UseAllCoresCheckbox.Name = "UseAllCoresCheckbox";
            this.UseAllCoresCheckbox.Size = new System.Drawing.Size(216, 36);
            this.UseAllCoresCheckbox.TabIndex = 2;
            this.UseAllCoresCheckbox.Text = "Use all cores";
            this.UseAllCoresCheckbox.UseVisualStyleBackColor = true;
            // 
            // LauncherPathLabel
            // 
            this.LauncherPathLabel.AutoSize = true;
            this.LauncherPathLabel.Location = new System.Drawing.Point(3, 177);
            this.LauncherPathLabel.Name = "LauncherPathLabel";
            this.LauncherPathLabel.Size = new System.Drawing.Size(205, 32);
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
            this.DisableTextureStreamingCheckbox.Location = new System.Drawing.Point(8, 45);
            this.DisableTextureStreamingCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DisableTextureStreamingCheckbox.Name = "DisableTextureStreamingCheckbox";
            this.DisableTextureStreamingCheckbox.Size = new System.Drawing.Size(375, 36);
            this.DisableTextureStreamingCheckbox.TabIndex = 2;
            this.DisableTextureStreamingCheckbox.Text = "Disable texture streaming";
            this.DisableTextureStreamingCheckbox.UseVisualStyleBackColor = true;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.GameTabPage);
            this.MainTabControl.Controls.Add(this.PatchSelectTabPage);
            this.MainTabControl.Controls.Add(this.DatEditorTabPage);
            this.MainTabControl.Controls.Add(this.SettingsTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(11, 10);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(873, 569);
            this.MainTabControl.TabIndex = 7;
            // 
            // PatchSelectTabPage
            // 
            this.PatchSelectTabPage.Controls.Add(this.PatchTabPanel);
            this.PatchSelectTabPage.Location = new System.Drawing.Point(10, 48);
            this.PatchSelectTabPage.Name = "PatchSelectTabPage";
            this.PatchSelectTabPage.Size = new System.Drawing.Size(853, 511);
            this.PatchSelectTabPage.TabIndex = 3;
            this.PatchSelectTabPage.Text = "Patches";
            this.PatchSelectTabPage.UseVisualStyleBackColor = true;
            // 
            // PatchTabPanel
            // 
            this.PatchTabPanel.Controls.Add(this.DisableAFKDisconnectCheckbox);
            this.PatchTabPanel.Controls.Add(this.label3);
            this.PatchTabPanel.Controls.Add(this.label2);
            this.PatchTabPanel.Controls.Add(this.LatencyDurationUpDown);
            this.PatchTabPanel.Controls.Add(this.LatencyDisplayCheckbox);
            this.PatchTabPanel.Controls.Add(this.FastExitCheckbox);
            this.PatchTabPanel.Controls.Add(this.DisableEULACheckbox);
            this.PatchTabPanel.Controls.Add(this.label1);
            this.PatchTabPanel.Controls.Add(this.ShowOpposingTeamCheckbox);
            this.PatchTabPanel.Controls.Add(this.ShowAverageScoreCheckbox);
            this.PatchTabPanel.Controls.Add(this.SkillbookDelayUpDown);
            this.PatchTabPanel.Controls.Add(this.EnableSkillbookDelayCheckbox);
            this.PatchTabPanel.Controls.Add(this.EnableOptimizedModeCheckbox);
            this.PatchTabPanel.Controls.Add(this.ShowDPSMeterCheckbox);
            this.PatchTabPanel.Location = new System.Drawing.Point(4, 4);
            this.PatchTabPanel.Name = "PatchTabPanel";
            this.PatchTabPanel.Size = new System.Drawing.Size(846, 504);
            this.PatchTabPanel.TabIndex = 0;
            // 
            // DisableAFKDisconnectCheckbox
            // 
            this.DisableAFKDisconnectCheckbox.AutoSize = true;
            this.DisableAFKDisconnectCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.DisableAFKDisconnect;
            this.DisableAFKDisconnectCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "DisableAFKDisconnect", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DisableAFKDisconnectCheckbox.Location = new System.Drawing.Point(10, 401);
            this.DisableAFKDisconnectCheckbox.Name = "DisableAFKDisconnectCheckbox";
            this.DisableAFKDisconnectCheckbox.Size = new System.Drawing.Size(394, 36);
            this.DisableAFKDisconnectCheckbox.TabIndex = 13;
            this.DisableAFKDisconnectCheckbox.Text = "Disable AFK disconnecting";
            this.DisableAFKDisconnectCheckbox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(672, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "seconds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(581, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 32);
            this.label2.TabIndex = 11;
            this.label2.Text = "seconds";
            // 
            // LatencyDurationUpDown
            // 
            this.LatencyDurationUpDown.Enabled = false;
            this.LatencyDurationUpDown.Location = new System.Drawing.Point(546, 358);
            this.LatencyDurationUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LatencyDurationUpDown.Name = "LatencyDurationUpDown";
            this.LatencyDurationUpDown.Size = new System.Drawing.Size(120, 38);
            this.LatencyDurationUpDown.TabIndex = 10;
            this.LatencyDurationUpDown.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // LatencyDisplayCheckbox
            // 
            this.LatencyDisplayCheckbox.AutoSize = true;
            this.LatencyDisplayCheckbox.Location = new System.Drawing.Point(9, 358);
            this.LatencyDisplayCheckbox.Name = "LatencyDisplayCheckbox";
            this.LatencyDisplayCheckbox.Size = new System.Drawing.Size(531, 36);
            this.LatencyDisplayCheckbox.TabIndex = 9;
            this.LatencyDisplayCheckbox.Text = "Show latency display after combat for:";
            this.LatencyDisplayCheckbox.UseVisualStyleBackColor = true;
            // 
            // FastExitCheckbox
            // 
            this.FastExitCheckbox.AutoSize = true;
            this.FastExitCheckbox.Location = new System.Drawing.Point(10, 315);
            this.FastExitCheckbox.Name = "FastExitCheckbox";
            this.FastExitCheckbox.Size = new System.Drawing.Size(610, 36);
            this.FastExitCheckbox.TabIndex = 8;
            this.FastExitCheckbox.Text = "Exit game process immediately after quitting";
            this.FastExitCheckbox.UseVisualStyleBackColor = true;
            // 
            // DisableEULACheckbox
            // 
            this.DisableEULACheckbox.AutoSize = true;
            this.DisableEULACheckbox.Location = new System.Drawing.Point(10, 272);
            this.DisableEULACheckbox.Name = "DisableEULACheckbox";
            this.DisableEULACheckbox.Size = new System.Drawing.Size(433, 36);
            this.DisableEULACheckbox.TabIndex = 7;
            this.DisableEULACheckbox.Text = "Disable EULA prompt on login";
            this.DisableEULACheckbox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(693, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "These XML patches will be applied automagically.";
            // 
            // ShowOpposingTeamCheckbox
            // 
            this.ShowOpposingTeamCheckbox.AutoSize = true;
            this.ShowOpposingTeamCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.ShowOpposingTeam;
            this.ShowOpposingTeamCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "ShowOpposingTeam", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ShowOpposingTeamCheckbox.Location = new System.Drawing.Point(9, 229);
            this.ShowOpposingTeamCheckbox.Name = "ShowOpposingTeamCheckbox";
            this.ShowOpposingTeamCheckbox.Size = new System.Drawing.Size(428, 36);
            this.ShowOpposingTeamCheckbox.TabIndex = 5;
            this.ShowOpposingTeamCheckbox.Text = "Show opposing team in arena";
            this.ShowOpposingTeamCheckbox.UseVisualStyleBackColor = true;
            // 
            // ShowAverageScoreCheckbox
            // 
            this.ShowAverageScoreCheckbox.AutoSize = true;
            this.ShowAverageScoreCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.ShowAverageScore;
            this.ShowAverageScoreCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "ShowAverageScore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ShowAverageScoreCheckbox.Location = new System.Drawing.Point(10, 186);
            this.ShowAverageScoreCheckbox.Name = "ShowAverageScoreCheckbox";
            this.ShowAverageScoreCheckbox.Size = new System.Drawing.Size(520, 36);
            this.ShowAverageScoreCheckbox.TabIndex = 4;
            this.ShowAverageScoreCheckbox.Text = "Show average team rating in 3v3/6v6";
            this.ShowAverageScoreCheckbox.UseVisualStyleBackColor = true;
            // 
            // SkillbookDelayUpDown
            // 
            this.SkillbookDelayUpDown.DecimalPlaces = 2;
            this.SkillbookDelayUpDown.Enabled = false;
            this.SkillbookDelayUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.SkillbookDelayUpDown.Location = new System.Drawing.Point(455, 143);
            this.SkillbookDelayUpDown.Name = "SkillbookDelayUpDown";
            this.SkillbookDelayUpDown.Size = new System.Drawing.Size(120, 38);
            this.SkillbookDelayUpDown.TabIndex = 3;
            this.SkillbookDelayUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // EnableSkillbookDelayCheckbox
            // 
            this.EnableSkillbookDelayCheckbox.AutoSize = true;
            this.EnableSkillbookDelayCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.SkillbookDelayEnabled;
            this.EnableSkillbookDelayCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "SkillbookDelayEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.EnableSkillbookDelayCheckbox.Location = new System.Drawing.Point(10, 143);
            this.EnableSkillbookDelayCheckbox.Name = "EnableSkillbookDelayCheckbox";
            this.EnableSkillbookDelayCheckbox.Size = new System.Drawing.Size(438, 36);
            this.EnableSkillbookDelayCheckbox.TabIndex = 2;
            this.EnableSkillbookDelayCheckbox.Text = "Custom skillbook switch delay:";
            this.EnableSkillbookDelayCheckbox.UseVisualStyleBackColor = true;
            this.EnableSkillbookDelayCheckbox.CheckStateChanged += new System.EventHandler(this.EnableSkillbookDelayCheckbox_CheckStateChanged);
            // 
            // EnableOptimizedModeCheckbox
            // 
            this.EnableOptimizedModeCheckbox.AutoSize = true;
            this.EnableOptimizedModeCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.EnableOptimizedMode;
            this.EnableOptimizedModeCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "EnableOptimizedMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.EnableOptimizedModeCheckbox.Location = new System.Drawing.Point(10, 100);
            this.EnableOptimizedModeCheckbox.Name = "EnableOptimizedModeCheckbox";
            this.EnableOptimizedModeCheckbox.Size = new System.Drawing.Size(602, 36);
            this.EnableOptimizedModeCheckbox.TabIndex = 1;
            this.EnableOptimizedModeCheckbox.Text = "Enable optimized mode in graphics settings";
            this.EnableOptimizedModeCheckbox.UseVisualStyleBackColor = true;
            // 
            // ShowDPSMeterCheckbox
            // 
            this.ShowDPSMeterCheckbox.AutoSize = true;
            this.ShowDPSMeterCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.ShowDPSMeter;
            this.ShowDPSMeterCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "ShowDPSMeter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ShowDPSMeterCheckbox.Location = new System.Drawing.Point(10, 57);
            this.ShowDPSMeterCheckbox.Name = "ShowDPSMeterCheckbox";
            this.ShowDPSMeterCheckbox.Size = new System.Drawing.Size(268, 36);
            this.ShowDPSMeterCheckbox.TabIndex = 0;
            this.ShowDPSMeterCheckbox.Text = "Show DPS meter";
            this.ShowDPSMeterCheckbox.UseVisualStyleBackColor = true;
            // 
            // DatEditorTabPage
            // 
            this.DatEditorTabPage.Controls.Add(this.DATProgressBar);
            this.DatEditorTabPage.Controls.Add(this.DatEditorButtonTable);
            this.DatEditorTabPage.Controls.Add(this.FileDataTreeView);
            this.DatEditorTabPage.Location = new System.Drawing.Point(10, 48);
            this.DatEditorTabPage.Name = "DatEditorTabPage";
            this.DatEditorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DatEditorTabPage.Size = new System.Drawing.Size(853, 511);
            this.DatEditorTabPage.TabIndex = 1;
            this.DatEditorTabPage.Text = "DAT Editor";
            this.DatEditorTabPage.UseVisualStyleBackColor = true;
            // 
            // DATProgressBar
            // 
            this.DATProgressBar.Location = new System.Drawing.Point(7, 442);
            this.DATProgressBar.Name = "DATProgressBar";
            this.DATProgressBar.Size = new System.Drawing.Size(600, 59);
            this.DATProgressBar.TabIndex = 3;
            // 
            // DatEditorButtonTable
            // 
            this.DatEditorButtonTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatEditorButtonTable.ColumnCount = 1;
            this.DatEditorButtonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DatEditorButtonTable.Controls.Add(this.OpenDatFileButton, 0, 0);
            this.DatEditorButtonTable.Controls.Add(this.RecompileDatButton, 0, 1);
            this.DatEditorButtonTable.Controls.Add(this.RestoreDatButton, 0, 2);
            this.DatEditorButtonTable.Location = new System.Drawing.Point(613, 6);
            this.DatEditorButtonTable.Name = "DatEditorButtonTable";
            this.DatEditorButtonTable.RowCount = 3;
            this.DatEditorButtonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DatEditorButtonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DatEditorButtonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DatEditorButtonTable.Size = new System.Drawing.Size(234, 499);
            this.DatEditorButtonTable.TabIndex = 1;
            // 
            // OpenDatFileButton
            // 
            this.OpenDatFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenDatFileButton.Location = new System.Drawing.Point(3, 3);
            this.OpenDatFileButton.Name = "OpenDatFileButton";
            this.OpenDatFileButton.Size = new System.Drawing.Size(228, 243);
            this.OpenDatFileButton.TabIndex = 0;
            this.OpenDatFileButton.Text = "Open";
            this.OpenDatFileButton.UseVisualStyleBackColor = true;
            this.OpenDatFileButton.Click += new System.EventHandler(this.OpenDatFileButton_Click);
            // 
            // RecompileDatButton
            // 
            this.RecompileDatButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecompileDatButton.Location = new System.Drawing.Point(3, 252);
            this.RecompileDatButton.Name = "RecompileDatButton";
            this.RecompileDatButton.Size = new System.Drawing.Size(228, 118);
            this.RecompileDatButton.TabIndex = 1;
            this.RecompileDatButton.Text = "Recompile all";
            this.RecompileDatButton.UseVisualStyleBackColor = true;
            this.RecompileDatButton.Click += new System.EventHandler(this.RecompileDatButton_Click);
            // 
            // RestoreDatButton
            // 
            this.RestoreDatButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RestoreDatButton.Location = new System.Drawing.Point(3, 376);
            this.RestoreDatButton.Name = "RestoreDatButton";
            this.RestoreDatButton.Size = new System.Drawing.Size(228, 120);
            this.RestoreDatButton.TabIndex = 2;
            this.RestoreDatButton.Text = "Restore all";
            this.RestoreDatButton.UseVisualStyleBackColor = true;
            this.RestoreDatButton.Click += new System.EventHandler(this.RestoreDatButton_Click);
            // 
            // SettingsTabPage
            // 
            this.SettingsTabPage.Controls.Add(this.UpdateCheckBox);
            this.SettingsTabPage.Location = new System.Drawing.Point(10, 48);
            this.SettingsTabPage.Name = "SettingsTabPage";
            this.SettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTabPage.Size = new System.Drawing.Size(853, 511);
            this.SettingsTabPage.TabIndex = 2;
            this.SettingsTabPage.Text = "Settings";
            this.SettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // UpdateCheckBox
            // 
            this.UpdateCheckBox.AutoSize = true;
            this.UpdateCheckBox.Enabled = false;
            this.UpdateCheckBox.Location = new System.Drawing.Point(11, 5);
            this.UpdateCheckBox.Name = "UpdateCheckBox";
            this.UpdateCheckBox.Size = new System.Drawing.Size(282, 36);
            this.UpdateCheckBox.TabIndex = 26;
            this.UpdateCheckBox.Text = "Check for updates";
            this.UpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // FileDataTreeView
            // 
            this.FileDataTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileDataTreeView.HideSelection = false;
            this.FileDataTreeView.Location = new System.Drawing.Point(6, 6);
            this.FileDataTreeView.Name = "FileDataTreeView";
            treeNode1.Name = "Node4";
            treeNode1.Text = "Decompiling...";
            treeNode2.Name = "config.dat";
            treeNode2.Text = "config.dat";
            treeNode3.Name = "Node5";
            treeNode3.Text = "Decompiling...";
            treeNode4.Name = "config64.dat";
            treeNode4.Text = "config64.dat";
            treeNode5.Name = "Node6";
            treeNode5.Text = "Decompiling...";
            treeNode6.Name = "xml.dat";
            treeNode6.Text = "xml.dat";
            treeNode7.Name = "Node7";
            treeNode7.Text = "Decompiling...";
            treeNode8.Name = "xml64.dat";
            treeNode8.Text = "xml64.dat";
            this.FileDataTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode6,
            treeNode8});
            this.FileDataTreeView.Size = new System.Drawing.Size(601, 430);
            this.FileDataTreeView.TabIndex = 2;
            this.FileDataTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.FileDataTreeView_AfterExpand);
            // 
            // bNSBoostFormBindingSource
            // 
            this.bNSBoostFormBindingSource.DataSource = typeof(BNSBoost.BNSBoostForm);
            // 
            // BNSBoostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(895, 658);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.LaunchButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BNSBoostForm";
            this.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BNSBoost";
            this.Load += new System.EventHandler(this.Form_Load);
            this.GameTabPage.ResumeLayout(false);
            this.GameTabPanel.ResumeLayout(false);
            this.GameTabPanel.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.PatchSelectTabPage.ResumeLayout(false);
            this.PatchTabPanel.ResumeLayout(false);
            this.PatchTabPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LatencyDurationUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkillbookDelayUpDown)).EndInit();
            this.DatEditorTabPage.ResumeLayout(false);
            this.DatEditorButtonTable.ResumeLayout(false);
            this.SettingsTabPage.ResumeLayout(false);
            this.SettingsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bNSBoostFormBindingSource)).EndInit();
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
        private System.Windows.Forms.TabPage DatEditorTabPage;
        private BufferedTreeView FileDataTreeView;
        private System.Windows.Forms.TableLayoutPanel DatEditorButtonTable;
        private System.Windows.Forms.Button OpenDatFileButton;
        private System.Windows.Forms.Button RecompileDatButton;
        private System.Windows.Forms.Button RestoreDatButton;
        private System.Windows.Forms.Label RegionLabel;
        private System.Windows.Forms.BindingSource bNSBoostFormBindingSource;
        private System.Windows.Forms.ComboBox RegionComboBox;
        private System.Windows.Forms.TabPage SettingsTabPage;
        private System.Windows.Forms.CheckBox UpdateCheckBox;
        private System.Windows.Forms.CheckBox DisableX3Checkbox;
        private System.Windows.Forms.TabPage PatchSelectTabPage;
        private System.Windows.Forms.Panel PatchTabPanel;
        private System.Windows.Forms.CheckBox ShowOpposingTeamCheckbox;
        private System.Windows.Forms.CheckBox ShowAverageScoreCheckbox;
        private System.Windows.Forms.NumericUpDown SkillbookDelayUpDown;
        private System.Windows.Forms.CheckBox EnableSkillbookDelayCheckbox;
        private System.Windows.Forms.CheckBox EnableOptimizedModeCheckbox;
        private System.Windows.Forms.CheckBox ShowDPSMeterCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PingLabel;
        private System.Windows.Forms.CheckBox DisableEULACheckbox;
        private System.Windows.Forms.NumericUpDown LatencyDurationUpDown;
        private System.Windows.Forms.CheckBox LatencyDisplayCheckbox;
        private System.Windows.Forms.CheckBox FastExitCheckbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox DisableAFKDisconnectCheckbox;
        private System.Windows.Forms.ProgressBar DATProgressBar;
        private System.Windows.Forms.Label BitnessLabel;
        private System.Windows.Forms.RadioButton Bit64RadioButton;
        private System.Windows.Forms.RadioButton Bit32RadioButton;
    }
}

