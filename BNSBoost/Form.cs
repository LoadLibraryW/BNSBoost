using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            string defaultLauncherPath = LauncherPathTextBox.Text;

            if (defaultLauncherPath == "")
            {
                string[] searchDirs = {
                    (string) Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NCWest\\NCLauncher", "BaseDir", null),
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "NCWest\\NCLauncher"),
                    AppDomain.CurrentDomain.BaseDirectory,
                    Environment.CurrentDirectory
                };
                foreach (string dir in searchDirs)
                {
                    string path = Path.Combine(dir, "NCLauncherR.exe");
                    if (File.Exists(path))
                    {
                        defaultLauncherPath = path;
                        break;
                    }
                }

                LauncherPathTextBox.Text = defaultLauncherPath;
            }

            string defaultGamePath = GameDirectoryPathTextBox.Text;
            if (defaultGamePath == "")
            {
                defaultGamePath = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NCWest\\BnS", "BaseDir", null);
                if (defaultGamePath != null)
                {
                    GameDirectoryPathTextBox.Text = defaultGamePath;
                }
            };
        }

        private async void LaunchButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();

            string extraClientFlags = "";
            if (UseAllCoresCheckbox.Checked)
                extraClientFlags += " -USEALLAVAILABLECORES";
            if (DisableTextureStreamingCheckbox.Checked)
                extraClientFlags += " -USEALLAVAILABLECORES";

            string cookedPCBase = Path.Combine(Properties.Settings.Default.GameDirectoryPath, "contents", "Local", "NCWEST", "ENGLISH", "CookedPC");

            string origLoadingPkgFile = Path.Combine(cookedPCBase, "Loading.pkg");
            string unpatchedDir = Path.Combine(cookedPCBase, "unpatched");
            string movedLoadingPkgFile = Path.Combine(cookedPCBase, "Loading.pkg");

            Debug.WriteLine(origLoadingPkgFile + " --> " + movedLoadingPkgFile);
            if (Properties.Settings.Default.NoLoadingScreens)
            {
                System.Diagnostics.Debug.WriteLine(origLoadingPkgFile + " --> " + movedLoadingPkgFile);
                if (File.Exists(origLoadingPkgFile))
                {
                    Directory.CreateDirectory(unpatchedDir);
                    File.Move(origLoadingPkgFile, movedLoadingPkgFile);
                }
            } else
            {
                if (File.Exists(movedLoadingPkgFile))
                {
                    File.Move(movedLoadingPkgFile, origLoadingPkgFile);
                }
            }

            string launcherPath = LauncherPathTextBox.Text;

            this.Hide();
            int exitcode = await LaunchAsync(launcherPath, extraClientFlags);
            string message;
            switch (exitcode)
            {
                case 0:
                    Application.Exit();
                    return;
                case 740:
                    message = "You must run BNSBoost with administrator rights.";
                    break;
                default:
                    message = "Launcher exited with error: " + exitcode;
                    break;
            }
            this.Show();
            this.Focus();
            MessageBox.Show(message);
        }

        private async Task<int> LaunchAsync(string launcherPath, string extraClientFlags)
        {
            return await Task.Run(() => { return NativeMethods.Launch(launcherPath, extraClientFlags); });
        }

        }
    }
}
