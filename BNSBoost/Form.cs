using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

            if (defaultLauncherPath == "")
            {
                string regBaseDir;
                using (var reg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                using (var key = reg.OpenSubKey("HKEY_LOCAL_MACHINE\\SOFTWARE\\NCWest\\NCLauncher") {
                    regBaseDir = (string)reg.GetValue("BaseDir");
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
            if (Properties.Settings.Default.NoTextureStreaming)
                extraClientFlags += " -NOTEXTURESTREAMING";
            if (Properties.Settings.Default.UseAllCores)
                extraClientFlags += " -USEALLAVAILABLECORES";

            string cookedPCBase = Path.Combine(Properties.Settings.Default.GameDirectoryPath, "contents", "Local", "NCWEST", "ENGLISH", "CookedPC");

            string origLoadingPkgFile = Path.Combine(cookedPCBase, "Loading.pkg");
            string unpatchedDir = Path.Combine(cookedPCBase, "unpatched");
            string movedLoadingPkgFile = Path.Combine(unpatchedDir, "Loading.pkg");

            Debug.WriteLine(origLoadingPkgFile + " --> " + movedLoadingPkgFile);
            if (Properties.Settings.Default.NoLoadingScreens)
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

        private void UseAllCoresCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UseAllCores = UseAllCoresCheckbox.Checked;
        }

        private void DisableTextureStreamingCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NoTextureStreaming = DisableTextureStreamingCheckbox.Checked;
        }

        private void DisableLoadingScreensCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NoLoadingScreens = DisableLoadingScreensCheckBox.Checked;
        }
    }
}
