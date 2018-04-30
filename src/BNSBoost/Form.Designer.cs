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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BNSBoostForm));
            this.LaunchButton = new System.Windows.Forms.Button();
            this.GameTabPage = new System.Windows.Forms.TabPage();
            this.GameTabPanel = new System.Windows.Forms.Panel();
            this.MultiClientCheckbox = new System.Windows.Forms.CheckBox();
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
            this.FileDataTreeView = new BNSBoost.BufferedTreeView();
            this.ModTabPage = new System.Windows.Forms.TabPage();
            this.ModListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OpenModFolderButton = new System.Windows.Forms.Button();
            this.RefreshModListButton = new System.Windows.Forms.Button();
            this.SpashTabPage = new System.Windows.Forms.TabPage();
            this.SplashListView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.OpenSplashFolderButton = new System.Windows.Forms.Button();
            this.RefreshSplashListButton = new System.Windows.Forms.Button();
            this.SettingsTabPage = new System.Windows.Forms.TabPage();
            this.AlwaysRunBNSBoostCheckbox = new System.Windows.Forms.CheckBox();
            this.PerformLauncherCheckbox = new System.Windows.Forms.CheckBox();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.UpdateCheckBox = new System.Windows.Forms.CheckBox();
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
            this.ModTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SpashTabPage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SettingsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bNSBoostFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LaunchButton
            // 
            resources.ApplyResources(this.LaunchButton, "LaunchButton");
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // GameTabPage
            // 
            this.GameTabPage.Controls.Add(this.GameTabPanel);
            resources.ApplyResources(this.GameTabPage, "GameTabPage");
            this.GameTabPage.Name = "GameTabPage";
            this.GameTabPage.UseVisualStyleBackColor = true;
            // 
            // GameTabPanel
            // 
            this.GameTabPanel.BackColor = System.Drawing.Color.Transparent;
            this.GameTabPanel.Controls.Add(this.MultiClientCheckbox);
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
            resources.ApplyResources(this.GameTabPanel, "GameTabPanel");
            this.GameTabPanel.Name = "GameTabPanel";
            // 
            // MultiClientCheckbox
            // 
            resources.ApplyResources(this.MultiClientCheckbox, "MultiClientCheckbox");
            this.MultiClientCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.MultiClientEnabled;
            this.MultiClientCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "MultiClientEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MultiClientCheckbox.Name = "MultiClientCheckbox";
            this.MultiClientCheckbox.UseVisualStyleBackColor = true;
            // 
            // BitnessLabel
            // 
            resources.ApplyResources(this.BitnessLabel, "BitnessLabel");
            this.BitnessLabel.Name = "BitnessLabel";
            // 
            // Bit64RadioButton
            // 
            resources.ApplyResources(this.Bit64RadioButton, "Bit64RadioButton");
            this.Bit64RadioButton.Checked = global::BNSBoost.Properties.Settings.Default.Is64Bit;
            this.Bit64RadioButton.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "Is64Bit", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Bit64RadioButton.Name = "Bit64RadioButton";
            this.Bit64RadioButton.TabStop = true;
            this.Bit64RadioButton.UseVisualStyleBackColor = true;
            // 
            // Bit32RadioButton
            // 
            resources.ApplyResources(this.Bit32RadioButton, "Bit32RadioButton");
            this.Bit32RadioButton.Name = "Bit32RadioButton";
            this.Bit32RadioButton.UseVisualStyleBackColor = true;
            // 
            // PingLabel
            // 
            resources.ApplyResources(this.PingLabel, "PingLabel");
            this.PingLabel.Name = "PingLabel";
            // 
            // DisableX3Checkbox
            // 
            resources.ApplyResources(this.DisableX3Checkbox, "DisableX3Checkbox");
            this.DisableX3Checkbox.Checked = global::BNSBoost.Properties.Settings.Default.DisableX3;
            this.DisableX3Checkbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "DisableX3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DisableX3Checkbox.Name = "DisableX3Checkbox";
            this.DisableX3Checkbox.UseVisualStyleBackColor = true;
            this.DisableX3Checkbox.CheckedChanged += new System.EventHandler(this.DisableX3Checkbox_CheckedChanged);
            // 
            // RegionComboBox
            // 
            resources.ApplyResources(this.RegionComboBox, "RegionComboBox");
            this.RegionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RegionComboBox.FormattingEnabled = true;
            this.RegionComboBox.Items.AddRange(new object[] {
            resources.GetString("RegionComboBox.Items"),
            resources.GetString("RegionComboBox.Items1")});
            this.RegionComboBox.Name = "RegionComboBox";
            this.RegionComboBox.Tag = "";
            this.RegionComboBox.SelectedIndexChanged += new System.EventHandler(this.RegionComboBox_SelectedIndexChanged);
            // 
            // RegionLabel
            // 
            resources.ApplyResources(this.RegionLabel, "RegionLabel");
            this.RegionLabel.Name = "RegionLabel";
            // 
            // GameDirectoryPathTextBox
            // 
            resources.ApplyResources(this.GameDirectoryPathTextBox, "GameDirectoryPathTextBox");
            this.GameDirectoryPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::BNSBoost.Properties.Settings.Default, "GameDirectoryPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.GameDirectoryPathTextBox.Name = "GameDirectoryPathTextBox";
            this.GameDirectoryPathTextBox.Text = global::BNSBoost.Properties.Settings.Default.GameDirectoryPath;
            // 
            // GameDirectoryPathLabel
            // 
            resources.ApplyResources(this.GameDirectoryPathLabel, "GameDirectoryPathLabel");
            this.GameDirectoryPathLabel.Name = "GameDirectoryPathLabel";
            // 
            // DisableLoadingScreensCheckBox
            // 
            resources.ApplyResources(this.DisableLoadingScreensCheckBox, "DisableLoadingScreensCheckBox");
            this.DisableLoadingScreensCheckBox.Checked = global::BNSBoost.Properties.Settings.Default.NoLoadingScreens;
            this.DisableLoadingScreensCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "NoLoadingScreens", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DisableLoadingScreensCheckBox.Name = "DisableLoadingScreensCheckBox";
            this.DisableLoadingScreensCheckBox.UseVisualStyleBackColor = true;
            // 
            // LauncherPathTextBox
            // 
            resources.ApplyResources(this.LauncherPathTextBox, "LauncherPathTextBox");
            this.LauncherPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::BNSBoost.Properties.Settings.Default, "NCLauncherRPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LauncherPathTextBox.Name = "LauncherPathTextBox";
            this.LauncherPathTextBox.Text = global::BNSBoost.Properties.Settings.Default.NCLauncherRPath;
            // 
            // UseAllCoresCheckbox
            // 
            resources.ApplyResources(this.UseAllCoresCheckbox, "UseAllCoresCheckbox");
            this.UseAllCoresCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.UseAllCores;
            this.UseAllCoresCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseAllCoresCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "UseAllCores", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.UseAllCoresCheckbox.Name = "UseAllCoresCheckbox";
            this.UseAllCoresCheckbox.UseVisualStyleBackColor = true;
            // 
            // LauncherPathLabel
            // 
            resources.ApplyResources(this.LauncherPathLabel, "LauncherPathLabel");
            this.LauncherPathLabel.Name = "LauncherPathLabel";
            // 
            // DisableTextureStreamingCheckbox
            // 
            resources.ApplyResources(this.DisableTextureStreamingCheckbox, "DisableTextureStreamingCheckbox");
            this.DisableTextureStreamingCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.NoTextureStreaming;
            this.DisableTextureStreamingCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisableTextureStreamingCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "NoTextureStreaming", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DisableTextureStreamingCheckbox.Name = "DisableTextureStreamingCheckbox";
            this.DisableTextureStreamingCheckbox.UseVisualStyleBackColor = true;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.GameTabPage);
            this.MainTabControl.Controls.Add(this.PatchSelectTabPage);
            this.MainTabControl.Controls.Add(this.DatEditorTabPage);
            this.MainTabControl.Controls.Add(this.ModTabPage);
            this.MainTabControl.Controls.Add(this.SpashTabPage);
            this.MainTabControl.Controls.Add(this.SettingsTabPage);
            resources.ApplyResources(this.MainTabControl, "MainTabControl");
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            // 
            // PatchSelectTabPage
            // 
            this.PatchSelectTabPage.Controls.Add(this.PatchTabPanel);
            resources.ApplyResources(this.PatchSelectTabPage, "PatchSelectTabPage");
            this.PatchSelectTabPage.Name = "PatchSelectTabPage";
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
            resources.ApplyResources(this.PatchTabPanel, "PatchTabPanel");
            this.PatchTabPanel.Name = "PatchTabPanel";
            // 
            // DisableAFKDisconnectCheckbox
            // 
            resources.ApplyResources(this.DisableAFKDisconnectCheckbox, "DisableAFKDisconnectCheckbox");
            this.DisableAFKDisconnectCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.DisableAFKDisconnect;
            this.DisableAFKDisconnectCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "DisableAFKDisconnect", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DisableAFKDisconnectCheckbox.Name = "DisableAFKDisconnectCheckbox";
            this.DisableAFKDisconnectCheckbox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // LatencyDurationUpDown
            // 
            this.LatencyDurationUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::BNSBoost.Properties.Settings.Default, "LatencyShowTimeValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.LatencyDurationUpDown, "LatencyDurationUpDown");
            this.LatencyDurationUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LatencyDurationUpDown.Name = "LatencyDurationUpDown";
            this.LatencyDurationUpDown.Value = global::BNSBoost.Properties.Settings.Default.LatencyShowTimeValue;
            // 
            // LatencyDisplayCheckbox
            // 
            resources.ApplyResources(this.LatencyDisplayCheckbox, "LatencyDisplayCheckbox");
            this.LatencyDisplayCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.ChangeLatencyDisplayTime;
            this.LatencyDisplayCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "ChangeLatencyDisplayTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LatencyDisplayCheckbox.Name = "LatencyDisplayCheckbox";
            this.LatencyDisplayCheckbox.UseVisualStyleBackColor = true;
            this.LatencyDisplayCheckbox.CheckedChanged += new System.EventHandler(this.LatencyDisplayCheckbox_CheckedChanged);
            // 
            // FastExitCheckbox
            // 
            resources.ApplyResources(this.FastExitCheckbox, "FastExitCheckbox");
            this.FastExitCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.ExitGameImmediately;
            this.FastExitCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "ExitGameImmediately", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FastExitCheckbox.Name = "FastExitCheckbox";
            this.FastExitCheckbox.UseVisualStyleBackColor = true;
            // 
            // DisableEULACheckbox
            // 
            resources.ApplyResources(this.DisableEULACheckbox, "DisableEULACheckbox");
            this.DisableEULACheckbox.Checked = global::BNSBoost.Properties.Settings.Default.DisableEULAPrompt;
            this.DisableEULACheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "DisableEULAPrompt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DisableEULACheckbox.Name = "DisableEULACheckbox";
            this.DisableEULACheckbox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ShowOpposingTeamCheckbox
            // 
            resources.ApplyResources(this.ShowOpposingTeamCheckbox, "ShowOpposingTeamCheckbox");
            this.ShowOpposingTeamCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.ShowOpposingTeam;
            this.ShowOpposingTeamCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "ShowOpposingTeam", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ShowOpposingTeamCheckbox.Name = "ShowOpposingTeamCheckbox";
            this.ShowOpposingTeamCheckbox.UseVisualStyleBackColor = true;
            // 
            // ShowAverageScoreCheckbox
            // 
            resources.ApplyResources(this.ShowAverageScoreCheckbox, "ShowAverageScoreCheckbox");
            this.ShowAverageScoreCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.ShowAverageScore;
            this.ShowAverageScoreCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "ShowAverageScore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ShowAverageScoreCheckbox.Name = "ShowAverageScoreCheckbox";
            this.ShowAverageScoreCheckbox.UseVisualStyleBackColor = true;
            // 
            // SkillbookDelayUpDown
            // 
            this.SkillbookDelayUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::BNSBoost.Properties.Settings.Default, "SwitchDelayValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SkillbookDelayUpDown.DecimalPlaces = 2;
            resources.ApplyResources(this.SkillbookDelayUpDown, "SkillbookDelayUpDown");
            this.SkillbookDelayUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.SkillbookDelayUpDown.Name = "SkillbookDelayUpDown";
            this.SkillbookDelayUpDown.Value = global::BNSBoost.Properties.Settings.Default.SwitchDelayValue;
            // 
            // EnableSkillbookDelayCheckbox
            // 
            resources.ApplyResources(this.EnableSkillbookDelayCheckbox, "EnableSkillbookDelayCheckbox");
            this.EnableSkillbookDelayCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.SkillbookDelayEnabled;
            this.EnableSkillbookDelayCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "SkillbookDelayEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.EnableSkillbookDelayCheckbox.Name = "EnableSkillbookDelayCheckbox";
            this.EnableSkillbookDelayCheckbox.UseVisualStyleBackColor = true;
            this.EnableSkillbookDelayCheckbox.CheckStateChanged += new System.EventHandler(this.EnableSkillbookDelayCheckbox_CheckStateChanged);
            // 
            // EnableOptimizedModeCheckbox
            // 
            resources.ApplyResources(this.EnableOptimizedModeCheckbox, "EnableOptimizedModeCheckbox");
            this.EnableOptimizedModeCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.EnableOptimizedMode;
            this.EnableOptimizedModeCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "EnableOptimizedMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.EnableOptimizedModeCheckbox.Name = "EnableOptimizedModeCheckbox";
            this.EnableOptimizedModeCheckbox.UseVisualStyleBackColor = true;
            // 
            // ShowDPSMeterCheckbox
            // 
            resources.ApplyResources(this.ShowDPSMeterCheckbox, "ShowDPSMeterCheckbox");
            this.ShowDPSMeterCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.ShowDPSMeter;
            this.ShowDPSMeterCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "ShowDPSMeter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ShowDPSMeterCheckbox.Name = "ShowDPSMeterCheckbox";
            this.ShowDPSMeterCheckbox.UseVisualStyleBackColor = true;
            // 
            // DatEditorTabPage
            // 
            this.DatEditorTabPage.Controls.Add(this.DATProgressBar);
            this.DatEditorTabPage.Controls.Add(this.DatEditorButtonTable);
            this.DatEditorTabPage.Controls.Add(this.FileDataTreeView);
            resources.ApplyResources(this.DatEditorTabPage, "DatEditorTabPage");
            this.DatEditorTabPage.Name = "DatEditorTabPage";
            this.DatEditorTabPage.UseVisualStyleBackColor = true;
            // 
            // DATProgressBar
            // 
            resources.ApplyResources(this.DATProgressBar, "DATProgressBar");
            this.DATProgressBar.Name = "DATProgressBar";
            // 
            // DatEditorButtonTable
            // 
            resources.ApplyResources(this.DatEditorButtonTable, "DatEditorButtonTable");
            this.DatEditorButtonTable.Controls.Add(this.OpenDatFileButton, 0, 0);
            this.DatEditorButtonTable.Controls.Add(this.RecompileDatButton, 0, 1);
            this.DatEditorButtonTable.Controls.Add(this.RestoreDatButton, 0, 2);
            this.DatEditorButtonTable.Name = "DatEditorButtonTable";
            // 
            // OpenDatFileButton
            // 
            resources.ApplyResources(this.OpenDatFileButton, "OpenDatFileButton");
            this.OpenDatFileButton.Name = "OpenDatFileButton";
            this.OpenDatFileButton.UseVisualStyleBackColor = true;
            this.OpenDatFileButton.Click += new System.EventHandler(this.OpenDatFileButton_Click);
            // 
            // RecompileDatButton
            // 
            resources.ApplyResources(this.RecompileDatButton, "RecompileDatButton");
            this.RecompileDatButton.Name = "RecompileDatButton";
            this.RecompileDatButton.UseVisualStyleBackColor = true;
            this.RecompileDatButton.Click += new System.EventHandler(this.RecompileDatButton_Click);
            // 
            // RestoreDatButton
            // 
            resources.ApplyResources(this.RestoreDatButton, "RestoreDatButton");
            this.RestoreDatButton.Name = "RestoreDatButton";
            this.RestoreDatButton.UseVisualStyleBackColor = true;
            this.RestoreDatButton.Click += new System.EventHandler(this.RestoreDatButton_Click);
            // 
            // FileDataTreeView
            // 
            resources.ApplyResources(this.FileDataTreeView, "FileDataTreeView");
            this.FileDataTreeView.HideSelection = false;
            this.FileDataTreeView.Name = "FileDataTreeView";
            this.FileDataTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("FileDataTreeView.Nodes"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("FileDataTreeView.Nodes1"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("FileDataTreeView.Nodes2"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("FileDataTreeView.Nodes3")))});
            this.FileDataTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.FileDataTreeView_AfterExpand);
            // 
            // ModTabPage
            // 
            this.ModTabPage.Controls.Add(this.ModListView);
            this.ModTabPage.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.ModTabPage, "ModTabPage");
            this.ModTabPage.Name = "ModTabPage";
            this.ModTabPage.UseVisualStyleBackColor = true;
            // 
            // ModListView
            // 
            this.ModListView.CheckBoxes = true;
            this.ModListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            resources.ApplyResources(this.ModListView, "ModListView");
            this.ModListView.MultiSelect = false;
            this.ModListView.Name = "ModListView";
            this.ModListView.UseCompatibleStateImageBehavior = false;
            this.ModListView.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.OpenModFolderButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RefreshModListButton, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // OpenModFolderButton
            // 
            resources.ApplyResources(this.OpenModFolderButton, "OpenModFolderButton");
            this.OpenModFolderButton.Name = "OpenModFolderButton";
            this.OpenModFolderButton.UseVisualStyleBackColor = true;
            this.OpenModFolderButton.Click += new System.EventHandler(this.OpenModFolderButton_Click);
            // 
            // RefreshModListButton
            // 
            resources.ApplyResources(this.RefreshModListButton, "RefreshModListButton");
            this.RefreshModListButton.Name = "RefreshModListButton";
            this.RefreshModListButton.UseVisualStyleBackColor = true;
            this.RefreshModListButton.Click += new System.EventHandler(this.RefreshModListButton_Click);
            // 
            // SpashTabPage
            // 
            this.SpashTabPage.Controls.Add(this.SplashListView);
            this.SpashTabPage.Controls.Add(this.tableLayoutPanel2);
            resources.ApplyResources(this.SpashTabPage, "SpashTabPage");
            this.SpashTabPage.Name = "SpashTabPage";
            this.SpashTabPage.UseVisualStyleBackColor = true;
            // 
            // SplashListView
            // 
            this.SplashListView.CheckBoxes = true;
            this.SplashListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            resources.ApplyResources(this.SplashListView, "SplashListView");
            this.SplashListView.MultiSelect = false;
            this.SplashListView.Name = "SplashListView";
            this.SplashListView.TileSize = new System.Drawing.Size(64, 64);
            this.SplashListView.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.OpenSplashFolderButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.RefreshSplashListButton, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // OpenSplashFolderButton
            // 
            resources.ApplyResources(this.OpenSplashFolderButton, "OpenSplashFolderButton");
            this.OpenSplashFolderButton.Name = "OpenSplashFolderButton";
            this.OpenSplashFolderButton.UseVisualStyleBackColor = true;
            this.OpenSplashFolderButton.Click += new System.EventHandler(this.OpenSplashFolderButton_Click);
            // 
            // RefreshSplashListButton
            // 
            resources.ApplyResources(this.RefreshSplashListButton, "RefreshSplashListButton");
            this.RefreshSplashListButton.Name = "RefreshSplashListButton";
            this.RefreshSplashListButton.UseVisualStyleBackColor = true;
            this.RefreshSplashListButton.Click += new System.EventHandler(this.RefreshSplashListButton_Click);
            // 
            // SettingsTabPage
            // 
            this.SettingsTabPage.Controls.Add(this.AlwaysRunBNSBoostCheckbox);
            this.SettingsTabPage.Controls.Add(this.PerformLauncherCheckbox);
            this.SettingsTabPage.Controls.Add(this.LanguageComboBox);
            this.SettingsTabPage.Controls.Add(this.LanguageLabel);
            this.SettingsTabPage.Controls.Add(this.UpdateCheckBox);
            resources.ApplyResources(this.SettingsTabPage, "SettingsTabPage");
            this.SettingsTabPage.Name = "SettingsTabPage";
            this.SettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // AlwaysRunBNSBoostCheckbox
            // 
            resources.ApplyResources(this.AlwaysRunBNSBoostCheckbox, "AlwaysRunBNSBoostCheckbox");
            this.AlwaysRunBNSBoostCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.HijiackLauncher;
            this.AlwaysRunBNSBoostCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AlwaysRunBNSBoostCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "HijiackLauncher", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.AlwaysRunBNSBoostCheckbox.Name = "AlwaysRunBNSBoostCheckbox";
            this.AlwaysRunBNSBoostCheckbox.UseVisualStyleBackColor = true;
            // 
            // PerformLauncherCheckbox
            // 
            resources.ApplyResources(this.PerformLauncherCheckbox, "PerformLauncherCheckbox");
            this.PerformLauncherCheckbox.Checked = global::BNSBoost.Properties.Settings.Default.PerformLauncherCheck;
            this.PerformLauncherCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PerformLauncherCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "PerformLauncherCheck", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PerformLauncherCheckbox.Name = "PerformLauncherCheckbox";
            this.PerformLauncherCheckbox.UseVisualStyleBackColor = true;
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Items.AddRange(new object[] {
            resources.GetString("LanguageComboBox.Items")});
            resources.ApplyResources(this.LanguageComboBox, "LanguageComboBox");
            this.LanguageComboBox.Name = "LanguageComboBox";
            // 
            // LanguageLabel
            // 
            resources.ApplyResources(this.LanguageLabel, "LanguageLabel");
            this.LanguageLabel.Name = "LanguageLabel";
            // 
            // UpdateCheckBox
            // 
            resources.ApplyResources(this.UpdateCheckBox, "UpdateCheckBox");
            this.UpdateCheckBox.Checked = global::BNSBoost.Properties.Settings.Default.CheckForUpdates;
            this.UpdateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UpdateCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BNSBoost.Properties.Settings.Default, "CheckForUpdates", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.UpdateCheckBox.Name = "UpdateCheckBox";
            this.UpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // bNSBoostFormBindingSource
            // 
            this.bNSBoostFormBindingSource.DataSource = typeof(BNSBoost.BNSBoostForm);
            // 
            // BNSBoostForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.LaunchButton);
            this.Name = "BNSBoostForm";
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
            this.ModTabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.SpashTabPage.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox MultiClientCheckbox;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.TabPage ModTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button OpenModFolderButton;
        private System.Windows.Forms.Button RefreshModListButton;
        private System.Windows.Forms.ListView ModListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox PerformLauncherCheckbox;
        private System.Windows.Forms.CheckBox AlwaysRunBNSBoostCheckbox;
        private System.Windows.Forms.TabPage SpashTabPage;
        private System.Windows.Forms.ListView SplashListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button OpenSplashFolderButton;
        private System.Windows.Forms.Button RefreshSplashListButton;
    }
}

