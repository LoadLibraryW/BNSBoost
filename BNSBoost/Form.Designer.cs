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
            this.DatEditorTabPage = new System.Windows.Forms.TabPage();
            this.FileDataTreeView = new BNSBoost.BufferedTreeView();
            this.DatEditorButtonTable = new System.Windows.Forms.TableLayoutPanel();
            this.OpenDatFileButton = new System.Windows.Forms.Button();
            this.RecompileDatButton = new System.Windows.Forms.Button();
            this.RestoreDatButton = new System.Windows.Forms.Button();
            this.SettingsTabPage = new System.Windows.Forms.TabPage();
            this.UpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.TextEditorComboBox = new System.Windows.Forms.ComboBox();
            this.TextEditorLabel = new System.Windows.Forms.Label();
            this.bNSBoostFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GameTabPage.SuspendLayout();
            this.GameTabPanel.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.DatEditorTabPage.SuspendLayout();
            this.DatEditorButtonTable.SuspendLayout();
            this.SettingsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bNSBoostFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LaunchButton
            // 
            this.LaunchButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LaunchButton.Location = new System.Drawing.Point(11, 521);
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
            this.GameTabPage.Size = new System.Drawing.Size(853, 453);
            this.GameTabPage.TabIndex = 0;
            this.GameTabPage.Text = "Game";
            this.GameTabPage.UseVisualStyleBackColor = true;
            // 
            // GameTabPanel
            // 
            this.GameTabPanel.BackColor = System.Drawing.Color.Transparent;
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
            this.GameTabPanel.Size = new System.Drawing.Size(847, 449);
            this.GameTabPanel.TabIndex = 7;
            // 
            // RegionComboBox
            // 
            this.RegionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RegionComboBox.FormattingEnabled = true;
            this.RegionComboBox.Items.AddRange(new object[] {
            "NA"});
            this.RegionComboBox.Location = new System.Drawing.Point(121, 362);
            this.RegionComboBox.Name = "RegionComboBox";
            this.RegionComboBox.Size = new System.Drawing.Size(133, 39);
            this.RegionComboBox.TabIndex = 23;
            this.RegionComboBox.Tag = "";
            // 
            // RegionLabel
            // 
            this.RegionLabel.AutoSize = true;
            this.RegionLabel.Location = new System.Drawing.Point(1, 369);
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
            this.GameDirectoryPathTextBox.Location = new System.Drawing.Point(8, 279);
            this.GameDirectoryPathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GameDirectoryPathTextBox.Name = "GameDirectoryPathTextBox";
            this.GameDirectoryPathTextBox.Size = new System.Drawing.Size(819, 38);
            this.GameDirectoryPathTextBox.TabIndex = 21;
            this.GameDirectoryPathTextBox.Text = global::BNSBoost.Properties.Settings.Default.GameDirectoryPath;
            // 
            // GameDirectoryPathLabel
            // 
            this.GameDirectoryPathLabel.AutoSize = true;
            this.GameDirectoryPathLabel.Location = new System.Drawing.Point(0, 243);
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
            this.DisableLoadingScreensCheckBox.Location = new System.Drawing.Point(8, 86);
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
            this.LauncherPathTextBox.Location = new System.Drawing.Point(8, 179);
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
            this.LauncherPathLabel.Location = new System.Drawing.Point(3, 145);
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
            this.MainTabControl.Controls.Add(this.DatEditorTabPage);
            this.MainTabControl.Controls.Add(this.SettingsTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(11, 10);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(873, 511);
            this.MainTabControl.TabIndex = 7;
            // 
            // DatEditorTabPage
            // 
            this.DatEditorTabPage.Controls.Add(this.FileDataTreeView);
            this.DatEditorTabPage.Controls.Add(this.DatEditorButtonTable);
            this.DatEditorTabPage.Location = new System.Drawing.Point(10, 48);
            this.DatEditorTabPage.Name = "DatEditorTabPage";
            this.DatEditorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DatEditorTabPage.Size = new System.Drawing.Size(853, 453);
            this.DatEditorTabPage.TabIndex = 1;
            this.DatEditorTabPage.Text = "DAT Editor";
            this.DatEditorTabPage.UseVisualStyleBackColor = true;
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
            treeNode2.Name = "Node0";
            treeNode2.Text = "config.dat";
            treeNode3.Name = "Node5";
            treeNode3.Text = "Decompiling...";
            treeNode4.Name = "Node1";
            treeNode4.Text = "config64.dat";
            treeNode5.Name = "Node6";
            treeNode5.Text = "Decompiling...";
            treeNode6.Name = "Node2";
            treeNode6.Text = "xml.dat";
            treeNode7.Name = "Node7";
            treeNode7.Text = "Decompiling...";
            treeNode8.Name = "Node3";
            treeNode8.Text = "xml64.dat";
            this.FileDataTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode6,
            treeNode8});
            this.FileDataTreeView.Size = new System.Drawing.Size(601, 441);
            this.FileDataTreeView.TabIndex = 2;
            this.FileDataTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.FileDataTreeView_AfterExpand);
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
            this.DatEditorButtonTable.Size = new System.Drawing.Size(234, 441);
            this.DatEditorButtonTable.TabIndex = 1;
            // 
            // OpenDatFileButton
            // 
            this.OpenDatFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenDatFileButton.Location = new System.Drawing.Point(3, 3);
            this.OpenDatFileButton.Name = "OpenDatFileButton";
            this.OpenDatFileButton.Size = new System.Drawing.Size(228, 214);
            this.OpenDatFileButton.TabIndex = 0;
            this.OpenDatFileButton.Text = "Open";
            this.OpenDatFileButton.UseVisualStyleBackColor = true;
            this.OpenDatFileButton.Click += new System.EventHandler(this.OpenDatFileButton_Click);
            // 
            // RecompileDatButton
            // 
            this.RecompileDatButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecompileDatButton.Location = new System.Drawing.Point(3, 223);
            this.RecompileDatButton.Name = "RecompileDatButton";
            this.RecompileDatButton.Size = new System.Drawing.Size(228, 104);
            this.RecompileDatButton.TabIndex = 1;
            this.RecompileDatButton.Text = "Recompile all";
            this.RecompileDatButton.UseVisualStyleBackColor = true;
            this.RecompileDatButton.Click += new System.EventHandler(this.RecompileDatButton_Click);
            // 
            // RestoreDatButton
            // 
            this.RestoreDatButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RestoreDatButton.Location = new System.Drawing.Point(3, 333);
            this.RestoreDatButton.Name = "RestoreDatButton";
            this.RestoreDatButton.Size = new System.Drawing.Size(228, 105);
            this.RestoreDatButton.TabIndex = 2;
            this.RestoreDatButton.Text = "Restore all";
            this.RestoreDatButton.UseVisualStyleBackColor = true;
            this.RestoreDatButton.Click += new System.EventHandler(this.RestoreDatButton_Click);
            // 
            // SettingsTabPage
            // 
            this.SettingsTabPage.Controls.Add(this.UpdateCheckBox);
            this.SettingsTabPage.Controls.Add(this.TextEditorComboBox);
            this.SettingsTabPage.Controls.Add(this.TextEditorLabel);
            this.SettingsTabPage.Location = new System.Drawing.Point(10, 48);
            this.SettingsTabPage.Name = "SettingsTabPage";
            this.SettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTabPage.Size = new System.Drawing.Size(853, 453);
            this.SettingsTabPage.TabIndex = 2;
            this.SettingsTabPage.Text = "Settings";
            this.SettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // UpdateCheckBox
            // 
            this.UpdateCheckBox.AutoSize = true;
            this.UpdateCheckBox.Enabled = false;
            this.UpdateCheckBox.Location = new System.Drawing.Point(15, 77);
            this.UpdateCheckBox.Name = "UpdateCheckBox";
            this.UpdateCheckBox.Size = new System.Drawing.Size(282, 36);
            this.UpdateCheckBox.TabIndex = 26;
            this.UpdateCheckBox.Text = "Check for updates";
            this.UpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // TextEditorComboBox
            // 
            this.TextEditorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextEditorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TextEditorComboBox.FormattingEnabled = true;
            this.TextEditorComboBox.Items.AddRange(new object[] {
            "System default",
            "wordpad.exe"});
            this.TextEditorComboBox.Location = new System.Drawing.Point(164, 18);
            this.TextEditorComboBox.Name = "TextEditorComboBox";
            this.TextEditorComboBox.Size = new System.Drawing.Size(263, 39);
            this.TextEditorComboBox.TabIndex = 25;
            this.TextEditorComboBox.Tag = "";
            // 
            // TextEditorLabel
            // 
            this.TextEditorLabel.AutoSize = true;
            this.TextEditorLabel.Location = new System.Drawing.Point(9, 25);
            this.TextEditorLabel.Name = "TextEditorLabel";
            this.TextEditorLabel.Size = new System.Drawing.Size(157, 32);
            this.TextEditorLabel.TabIndex = 24;
            this.TextEditorLabel.Text = "Text editor:";
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
            this.ClientSize = new System.Drawing.Size(895, 600);
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
        private System.Windows.Forms.ComboBox TextEditorComboBox;
        private System.Windows.Forms.Label TextEditorLabel;
        private System.Windows.Forms.CheckBox UpdateCheckBox;
    }
}

