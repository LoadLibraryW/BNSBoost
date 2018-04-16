using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            // Form autogeneration doesn't handle this properly for some reason
            RegionComboBox.SelectedItem = Properties.Settings.Default.Region;
            TextEditorComboBox.SelectedItem = Properties.Settings.Default.TextEditor;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            string defaultLauncherPath = LauncherPathTextBox.Text;

            var reg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            if (defaultLauncherPath == "")
            {
                string regBaseDir;
                using (var key = reg.OpenSubKey(@"SOFTWARE\NCWest\NCLauncher"))
                {
                    regBaseDir = (string)key.GetValue("BaseDir");
                }

                string[] searchDirs = {
                    regBaseDir,
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"NCWest\NCLauncher"),
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
                using (var key = reg.OpenSubKey(@"SOFTWARE\NCWest\BnS"))
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

        private void ToggleX3(bool shouldPatch)
        {
            Dictionary<string, string> patches = new Dictionary<string, string>
            {
                {@"bin\XignCode\x3.xem", @"X3\bin\x3.xem"},
                {@"bin64\XignCode\x3.xem", @"X3\bin64\x3.xem"}
            };

            foreach (KeyValuePair<string, string> patch in patches)
            {
                string gameX3 = Path.Combine(GameDirectoryPathTextBox.Text, patch.Key);
                string ourX3 = patch.Value;
                bool isPatched = File.ReadAllBytes(gameX3).SequenceEqual(File.ReadAllBytes(ourX3));

                Debug.WriteLine("checking " + gameX3 + " == " + ourX3 + " : " + isPatched);

                string unpatched = Path.Combine(Path.GetDirectoryName(gameX3), "unpatched");
                string unpatchedX3 = Path.Combine(unpatched, "x3.xem");

                if (shouldPatch && isPatched)
                {
                    Debug.WriteLine("X3 is already patched out");
                }
                else if (shouldPatch && !isPatched)
                {
                    Debug.WriteLine("Patching out X3");

                    if (Directory.Exists(unpatched)) Directory.Delete(unpatched, true);
                    Directory.CreateDirectory(unpatched);

                    File.Move(gameX3, unpatchedX3);
                    File.Copy(ourX3, gameX3, true);
                }
                else if (isPatched && !shouldPatch)
                {
                    Debug.WriteLine("Restoring original X3");
                    if (Directory.Exists(unpatched))
                    {
                        File.Delete(gameX3);
                        File.Move(unpatchedX3, gameX3);
                        Directory.Delete(unpatched, true);
                    }
                    else
                    {
                        Debug.WriteLine("X3 was not patched");
                    }
                }
            }
        }

        private void ToggleLoadingScreens(bool disabled)
        {
            string cookedPCBase = Path.Combine(GameDirectoryPathTextBox.Text, @"contents\Local\NCWEST\ENGLISH\CookedPC");

            string origLoadingPkgFile = Path.Combine(cookedPCBase, "Loading.pkg");
            string unpatchedDir = Path.Combine(cookedPCBase, "unpatched");
            string movedLoadingPkgFile = Path.Combine(unpatchedDir, "Loading.pkg");

            Debug.WriteLine(origLoadingPkgFile + " --> " + movedLoadingPkgFile);
            if (disabled)
            {
                if (File.Exists(origLoadingPkgFile))
                {
                    Debug.WriteLine(origLoadingPkgFile + " --> " + movedLoadingPkgFile);
                    Directory.CreateDirectory(unpatchedDir);
                    File.Delete(movedLoadingPkgFile);
                    File.Move(origLoadingPkgFile, movedLoadingPkgFile);
                }
            }
            else if (File.Exists(movedLoadingPkgFile))
            {
                File.Delete(origLoadingPkgFile);
                File.Move(movedLoadingPkgFile, origLoadingPkgFile);
            }
        }

        private async void LaunchButton_Click(object sender, EventArgs e)
        {
            // Need to save ourself since form doesn't do it automatically :/
            Properties.Settings.Default.Region = (string)RegionComboBox.SelectedItem;
            Properties.Settings.Default.TextEditor = (string)TextEditorComboBox.SelectedItem;
            Properties.Settings.Default.Save();

            ToggleX3(Properties.Settings.Default.DisableX3);

            string baseDatDir = Path.Combine(GameDirectoryPathTextBox.Text, @"contents\Local\NCWEST\data\");
            foreach (string decompFile in Directory.GetDirectories(baseDatDir))
            {
                if (!decompFile.EndsWith(".files")) continue;
                Directory.Delete(decompFile, true);
            }

            string extraClientFlags = " -UNATTENDED";
            if (DisableTextureStreamingCheckbox.Checked)
                extraClientFlags += " -NOTEXTURESTREAMING";
            if (UseAllCoresCheckbox.Checked)
                extraClientFlags += " -USEALLAVAILABLECORES";

            ToggleLoadingScreens(DisableLoadingScreensCheckBox.Checked);

            string launcherPath = LauncherPathTextBox.Text;

            Hide();

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

            Show();
            Focus();
            MessageBox.Show(message);
        }

        private async Task<int> LaunchAsync(string launcherPath, string extraClientFlags)
        {
            return await Task.Run(() => { return NativeMethods.Launch(launcherPath, extraClientFlags); });
        }

        private void FileDataTreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode dat = e.Node;
            if (dat.Parent != null) return;
            if (dat.Nodes[0].Text == "Decompiling...")
            {
                new Thread(() =>
                {
                    Debug.WriteLine(GameDirectoryPathTextBox);
                    Debug.WriteLine(GameDirectoryPathTextBox.Text);
                    string datFile = Path.Combine(GameDirectoryPathTextBox.Text, @"contents\Local\NCWEST\data\",
                        dat.Text);
                    try
                    {
                        new BNSDat().Extract(datFile, (number, of) =>
                        {
                            FileDataTreeView.Invoke((MethodInvoker)delegate
                           {
                               dat.Nodes[0].Text = "Decompiling... " + number + "/" + of;
                           });
                        }, datFile.Contains("64"));
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                        dat.Nodes.Clear();
                        return;
                    }

                    FileDataTreeView.Invoke((MethodInvoker)delegate
                    {
                        dat.Nodes.Clear();
                        foreach (string decompFile in Directory.GetFiles(datFile + ".files"))
                        {
                            TreeNode n = new TreeNode();
                            n.Text = Path.GetFileName(decompFile);
                            dat.Nodes.Add(n);
                        }
                    });
                }).Start();
            }
        }

        private void OpenDatFileButton_Click(object sender, EventArgs e)
        {
            TreeNode dat = FileDataTreeView.SelectedNode;
            if (dat.Parent == null) dat.Expand();
            else
            {
                if (dat.Text != "Decompiling...")
                {
                    string datFile = Path.Combine(GameDirectoryPathTextBox.Text, @"contents\Local\NCWEST\data\", dat.Parent.Text + @".files\", dat.Text);
                    Debug.WriteLine(datFile);
                    if ("System preferred".Equals(TextEditorComboBox.SelectedItem))
                        System.Diagnostics.Process.Start(datFile);
                    else
                        System.Diagnostics.Process.Start("wordpad.exe", "\"" + datFile + "\"");
                }
            }
        }

        private void RecompileDatButton_Click(object sender, EventArgs e)
        {
            string baseDatDir = Path.Combine(GameDirectoryPathTextBox.Text, @"contents\Local\NCWEST\data\");
            string unpatchedDir = Path.Combine(baseDatDir, @"unpatched\");
            Debug.WriteLine("Unpatched base dir: " + unpatchedDir);
            Directory.CreateDirectory(unpatchedDir);
            foreach (string decompFile in Directory.GetDirectories(baseDatDir))
            {
                if (!decompFile.EndsWith(".files")) continue;
                Debug.WriteLine(decompFile);
                string datName = Path.GetFileName(decompFile).Replace(".files", "");
                Debug.WriteLine("DAT file name: " + datName);

                string backupFile = Path.Combine(unpatchedDir, datName);
                string patchedFile = Path.Combine(baseDatDir, datName);


                Debug.WriteLine("Does backup " + backupFile + " exist?");
                if (!File.Exists(backupFile))
                {
                    Debug.WriteLine("Backed up file!");
                    File.Copy(patchedFile, backupFile);
                }
                new BNSDat().Compress(decompFile, datName.Contains("64"));
                //Directory.Delete(decompFile, true);
            }
        }

        private void RestoreDatButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to reset your patches?\nThis action cannot be reverted.",
                                                "Delete patches?",
                                                 MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                string baseDatDir = Path.Combine(GameDirectoryPathTextBox.Text, @"contents\Local\NCWEST\data\");
                string unpatchedDir = Path.Combine(baseDatDir, @"unpatched\");
                if (Directory.Exists(unpatchedDir))
                {
                    foreach (string unpatchedFile in Directory.GetFiles(unpatchedDir))
                    {
                        string origLocation = Path.Combine(baseDatDir, Path.GetFileName(unpatchedFile));
                        File.Delete(origLocation);
                        File.Move(unpatchedFile, origLocation);
                    }
                    Directory.Delete(unpatchedDir);
                }
            }
        }
    }

    class BufferedTreeView : TreeView
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            SendMessage(this.Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)TVS_EX_DOUBLEBUFFER);
            base.OnHandleCreated(e);
        }
        // Pinvoke:
        private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
        private const int TVM_GETEXTENDEDSTYLE = 0x1100 + 45;
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}
