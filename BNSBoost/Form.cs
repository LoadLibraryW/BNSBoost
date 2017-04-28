using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BNSBoost
{
    public partial class BNSBoostForm : Form
    {
        private static class NativeMethods
        {
            [DllImport("Injector.dll")]
            public static extern int Launch(
                [MarshalAs(UnmanagedType.LPWStr)] string lpLauncherBaseDir,
                [MarshalAs(UnmanagedType.LPWStr)] string lpExtraClientFlags
            );
        }

        public BNSBoostForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            string defaultLauncherPath = LauncherPathTextBox.Text;

            var reg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            if (defaultLauncherPath == "")
            {
                string regBaseDir;
                using (var key = reg.OpenSubKey("SOFTWARE\\NCWest\\NCLauncher"))
                {
                    regBaseDir = (string)key.GetValue("BaseDir");
                }

                string[] searchDirs = {
                    regBaseDir,
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
                using (var key = reg.OpenSubKey("SOFTWARE\\NCWest\\BnS"))
                {
                    defaultGamePath = (string)key.GetValue("BaseDir");
                }
                if (defaultGamePath != null)
                {
                    GameDirectoryPathTextBox.Text = defaultGamePath;
                }
            };
            reg.Dispose();
        }

        private async void LaunchButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();

            string extraClientFlags = "";
            if (DisableTextureStreamingCheckbox.Checked)
                extraClientFlags += " -NOTEXTURESTREAMING";
            if (UseAllCoresCheckbox.Checked)
                extraClientFlags += " -USEALLAVAILABLECORES";

            string cookedPCBase = Path.Combine(GameDirectoryPathTextBox.Text, "contents\\Local\\NCWEST\\ENGLISH\\CookedPC");

            string origLoadingPkgFile = Path.Combine(cookedPCBase, "Loading.pkg");
            string unpatchedDir = Path.Combine(cookedPCBase, "unpatched");
            string movedLoadingPkgFile = Path.Combine(unpatchedDir, "Loading.pkg");

            Debug.WriteLine(origLoadingPkgFile + " --> " + movedLoadingPkgFile);
            if (DisableLoadingScreensCheckBox.Checked)
            {
                if (File.Exists(origLoadingPkgFile))
                {
                    Debug.WriteLine(origLoadingPkgFile + " --> " + movedLoadingPkgFile);
                    Directory.CreateDirectory(unpatchedDir);
                    File.Move(origLoadingPkgFile, movedLoadingPkgFile);
                }
            }
            else if (File.Exists(movedLoadingPkgFile))
            {
                File.Move(movedLoadingPkgFile, origLoadingPkgFile);
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
