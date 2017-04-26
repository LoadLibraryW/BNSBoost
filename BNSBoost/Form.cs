using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BNSBoost
{
    public partial class BNSBoostForm : Form
    {
        public BNSBoostForm()
        {
            InitializeComponent();
            CenterToScreen();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            string DefaultLauncherPath = (string) Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NCWest\\NCLauncher", "BaseDir", "???") + "\\ncLauncherR.exe";
            LauncherPathTextBox.Text = DefaultLauncherPath;
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            string ExtraClientFlags = "";
            if (UseAllCoresCheckbox.Checked)
                ExtraClientFlags += "-USEALLAVAILABLECORES ";
            if (DisableTextureStreamingCheckbox.Checked)
                ExtraClientFlags += "-USEALLAVAILABLECORES";
            ExtraClientFlags = ExtraClientFlags.Trim();

            string LauncherPath = LauncherPathTextBox.Text;
            new Thread(() => Program.Launch(LauncherPath, ExtraClientFlags)).Start();
        }
    }
}
