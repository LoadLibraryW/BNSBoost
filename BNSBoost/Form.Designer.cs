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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LauncherPathLabel = new System.Windows.Forms.Label();
            this.LauncherPathTextBox = new System.Windows.Forms.TextBox();
            this.DisableTextureStreamingCheckbox = new System.Windows.Forms.CheckBox();
            this.UseAllCoresCheckbox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.GameTabPage.SuspendLayout();
            this.GameTabPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // LaunchButton
            // 
            this.LaunchButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LaunchButton.Location = new System.Drawing.Point(10, 264);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(866, 70);
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
            this.GameTabPage.Size = new System.Drawing.Size(846, 196);
            this.GameTabPage.TabIndex = 0;
            this.GameTabPage.Text = "Game";
            this.GameTabPage.UseVisualStyleBackColor = true;
            // 
            // GameTabPanel
            // 
            this.GameTabPanel.BackColor = System.Drawing.Color.Transparent;
            this.GameTabPanel.Controls.Add(this.tableLayoutPanel1);
            this.GameTabPanel.Controls.Add(this.flowLayoutPanel2);
            this.GameTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameTabPanel.Location = new System.Drawing.Point(3, 3);
            this.GameTabPanel.Name = "GameTabPanel";
            this.GameTabPanel.Size = new System.Drawing.Size(840, 190);
            this.GameTabPanel.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.LauncherPathLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.LauncherPathTextBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.DisableTextureStreamingCheckbox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.UseAllCoresCheckbox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(840, 190);
            this.tableLayoutPanel1.TabIndex = 9;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // LauncherPathLabel
            // 
            this.LauncherPathLabel.AutoSize = true;
            this.LauncherPathLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LauncherPathLabel.Location = new System.Drawing.Point(3, 84);
            this.LauncherPathLabel.Name = "LauncherPathLabel";
            this.LauncherPathLabel.Size = new System.Drawing.Size(205, 32);
            this.LauncherPathLabel.TabIndex = 14;
            this.LauncherPathLabel.Text = "Launcher path:";
            this.LauncherPathLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // LauncherPathTextBox
            // 
            this.LauncherPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LauncherPathTextBox.Location = new System.Drawing.Point(3, 119);
            this.LauncherPathTextBox.Name = "LauncherPathTextBox";
            this.LauncherPathTextBox.Size = new System.Drawing.Size(834, 38);
            this.LauncherPathTextBox.TabIndex = 15;
            // 
            // DisableTextureStreamingCheckbox
            // 
            this.DisableTextureStreamingCheckbox.AutoSize = true;
            this.DisableTextureStreamingCheckbox.Checked = true;
            this.DisableTextureStreamingCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisableTextureStreamingCheckbox.Location = new System.Drawing.Point(3, 45);
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
            this.UseAllCoresCheckbox.Location = new System.Drawing.Point(3, 3);
            this.UseAllCoresCheckbox.Name = "UseAllCoresCheckbox";
            this.UseAllCoresCheckbox.Size = new System.Drawing.Size(216, 36);
            this.UseAllCoresCheckbox.TabIndex = 2;
            this.UseAllCoresCheckbox.Text = "Use all cores";
            this.UseAllCoresCheckbox.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(840, 0);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.GameTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(10, 10);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(866, 254);
            this.MainTabControl.TabIndex = 7;
            // 
            // BNSBoostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(886, 344);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.LaunchButton);
            this.Name = "BNSBoostForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "BNSBoost";
            this.Load += new System.EventHandler(this.Form_Load);
            this.GameTabPage.ResumeLayout(false);
            this.GameTabPanel.ResumeLayout(false);
            this.GameTabPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.TabPage GameTabPage;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.Panel GameTabPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LauncherPathLabel;
        private System.Windows.Forms.TextBox LauncherPathTextBox;
        private System.Windows.Forms.CheckBox DisableTextureStreamingCheckbox;
        private System.Windows.Forms.CheckBox UseAllCoresCheckbox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}

