using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            string defaultLauncherPath = "unknown, please specify NCLauncherR.exe path";
            string[] searchDirs = {
                (string) Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NCWest\\NCLauncher", "BaseDir", null),
                "%ProgramFiles(x86)%\\NCWest\\NCLauncher",
                AppDomain.CurrentDomain.BaseDirectory
            };
            foreach(string dir in searchDirs)
            {
                string path = Environment.ExpandEnvironmentVariables(dir + "\\NCLauncherR.exe");
                if (File.Exists(path))
                {
                    defaultLauncherPath = path;
                    break;
                }
            }

            LauncherPathTextBox.Text = defaultLauncherPath;
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
    }
}
