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
            string extraClientFlags = "";
            if (UseAllCoresCheckbox.Checked)
                extraClientFlags += " -USEALLAVAILABLECORES";
            if (DisableTextureStreamingCheckbox.Checked)
                extraClientFlags += " -USEALLAVAILABLECORES";

            string launcherPath = LauncherPathTextBox.Text;
            new Thread(() => {
                Invoke((MethodInvoker) delegate { Hide(); });
                int exitcode = Program.Launch(launcherPath, extraClientFlags);
                if (exitcode == 0)
                    Application.Exit();
                else
                    Invoke((MethodInvoker) delegate {
                        string message;
                        if (exitcode == 740)
                            message = "You must run BNSBoost with administrator rights.";
                        else
                            message = "Launcher exited with error: " + exitcode;
                        MessageBox.Show(message);
                        Show();
                        Focus();
                    });
            }).Start();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
