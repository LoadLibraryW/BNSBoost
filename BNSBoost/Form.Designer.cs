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
            this.GameDirectoryPathTextBox = new System.Windows.Forms.TextBox();
            this.GameDirectoryPathLabel = new System.Windows.Forms.Label();
            this.DisableLoadingScreensCheckBox = new System.Windows.Forms.CheckBox();
            this.LauncherPathTextBox = new System.Windows.Forms.TextBox();
            this.UseAllCoresCheckbox = new System.Windows.Forms.CheckBox();
            this.LauncherPathLabel = new System.Windows.Forms.Label();
            this.DisableTextureStreamingCheckbox = new System.Windows.Forms.CheckBox();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.DatEditorTabPage = new System.Windows.Forms.TabPage();
            this.FileDataTreeView = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.GameTabPage.SuspendLayout();
            this.GameTabPanel.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.DatEditorTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LaunchButton
            // 
            this.LaunchButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LaunchButton.Location = new System.Drawing.Point(11, 421);
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
            this.GameTabPage.Size = new System.Drawing.Size(853, 353);
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
            this.GameTabPanel.Location = new System.Drawing.Point(3, 2);
            this.GameTabPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GameTabPanel.Name = "GameTabPanel";
            this.GameTabPanel.Size = new System.Drawing.Size(847, 349);
            this.GameTabPanel.TabIndex = 7;
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
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(11, 10);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(873, 411);
            this.MainTabControl.TabIndex = 7;
            // 
            // DatEditorTabPage
            // 
            this.DatEditorTabPage.Controls.Add(this.tableLayoutPanel1);
            this.DatEditorTabPage.Controls.Add(this.FileDataTreeView);
            this.DatEditorTabPage.Location = new System.Drawing.Point(10, 48);
            this.DatEditorTabPage.Name = "DatEditorTabPage";
            this.DatEditorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DatEditorTabPage.Size = new System.Drawing.Size(853, 353);
            this.DatEditorTabPage.TabIndex = 1;
            this.DatEditorTabPage.Text = "DAT Editor";
            this.DatEditorTabPage.UseVisualStyleBackColor = true;
            // 
            // FileDataTreeView
            // 
            this.FileDataTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FileDataTreeView.Location = new System.Drawing.Point(4, 4);
            this.FileDataTreeView.Name = "FileDataTreeView";
            treeNode1.Name = "Node4";
            treeNode1.Text = "Decompiling...";
            treeNode2.Name = "config";
            treeNode2.Text = "config.dat";
            treeNode3.Name = "Node5";
            treeNode3.Text = "Decompiling...";
            treeNode4.Name = "config64";
            treeNode4.Text = "config64.dat";
            treeNode5.Name = "Node6";
            treeNode5.Text = "Decompiling...";
            treeNode6.Name = "xml";
            treeNode6.Text = "xml.dat";
            treeNode7.Name = "Node7";
            treeNode7.Text = "Decompiling...";
            treeNode8.Name = "xml64";
            treeNode8.Text = "xml64.dat";
            this.FileDataTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode6,
            treeNode8});
            this.FileDataTreeView.Size = new System.Drawing.Size(603, 343);
            this.FileDataTreeView.TabIndex = 0;
            this.FileDataTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.FileDataTreeView_AfterExpand);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button3, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(613, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(234, 341);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 164);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(3, 173);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(228, 79);
            this.button2.TabIndex = 1;
            this.button2.Text = "Recompile all";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(3, 258);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(228, 80);
            this.button3.TabIndex = 2;
            this.button3.Text = "Restore all";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // BNSBoostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(895, 500);
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
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TreeView FileDataTreeView;
    }
}

