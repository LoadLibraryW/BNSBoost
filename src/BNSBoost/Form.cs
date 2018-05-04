using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using BNSBoost.BNSDat;

namespace BNSBoost
{
    public partial class BNSBoostForm : Form
    {
        private double? Ping;
        private int WorkerNumerator;
        private int WorkerDenominator;

        public BNSBoostForm()
        {
            InitializeComponent();

            // Form autogeneration doesn't handle this properly for some reason
            RegionComboBox.SelectedItem = Properties.Settings.Default.Region;
            SkillbookDelayUpDown.Enabled = Properties.Settings.Default.SkillbookDelayEnabled;
            LatencyDurationUpDown.Enabled = Properties.Settings.Default.ChangeLatencyDisplayTime;
            MultiClientCheckbox.Enabled = Properties.Settings.Default.DisableX3;
            LanguageComboBox.SelectedItem = "English";
        }

        private void CheckForUpdates()
        {
            if (!Properties.Settings.Default.CheckForUpdates) return;

            try
            {
                var release = Updater.GetLatestRelease();
                if (release.IsNewerVersion())
                {
                    var result = MessageBox.Show(this,
                        $"A newer version of BNSBoost is available: {release.Name}. Open release on Github?",
                        "Update available!",
                        MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start(release.URL);
                        Application.Exit();
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show($"Could not connect to GitHub: {ex.Message}", "Failed update check");
            }
        }

        private void InitializeMods()
        {
            var mods = ModManager.GetModList();
            ModListView.Items.Clear();
            foreach (var mod in mods)
            {
                var modCheckBox = new ListViewItem
                {
                    Text = mod.Name + (mod.Description != null ? " (" + mod.Description + ")" : ""),
                    ToolTipText = mod.Description,
                    Name = mod.Name,
                    Checked = mod.Enabled
                };

                ModListView.Items.Add(modCheckBox);
            }

            ModListView.ItemCheck += (who, evt) =>
            {
                ModManager.EnableMod(ModListView.Items[evt.Index].Name, evt.NewValue == CheckState.Checked);
            };
        }

        private void InitializeSplash()
        {
            var splashes = SplashManager.GetSplashList();
            SplashListView.LargeImageList = new ImageList
            {
                ImageSize = new Size(117, 90),
                ColorDepth = ColorDepth.Depth32Bit,
                TransparentColor = Color.Black
            };

            SplashListView.Items.Clear();

            foreach (var splash in splashes)
            {
                SplashListView.Items.Add(new ListViewItem
                {
                    Text = splash.Name,
                    Name = splash.Name,
                    Checked = splash.Enabled,
                    ImageIndex = SplashListView.LargeImageList.Images.Count,
                });

                SplashListView.LargeImageList.Images.Add(Image.FromFile(splash.Path));
            }

            SplashListView.ItemCheck += (who, evt) =>
            {
                SplashManager.EnableSplash(SplashListView.Items[evt.Index].Name, evt.NewValue == CheckState.Checked);
            };
        }

        private void InitializeGamePaths()
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

            try
            {
                IniFile ini = GetLauncherIni();

                bool is64 = ini.Read("Game_64bitEnable", "Settings") == "1";
                Bit64RadioButton.Checked = is64;
                Bit32RadioButton.Checked = !is64;

                string region = ini.Read("Game_Region", "Game_Language_BnS");
                string code;
                if (region == "North America") code = "NA";
                else if (region == "Europe") code = "EU";
                else code = "???";

                RegionComboBox.SelectedItem = code;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to determine client settings: {ex.Message}");
            }
        }

        private IniFile GetLauncherIni()
        {
            string launcherIni = Path.Combine(new FileInfo(LauncherPathTextBox.Text).DirectoryName, "NCLauncher.ini");
            return new IniFile(launcherIni);
        }

        private string GetServerIP()
        {
            // > netstat -atn | grep 10100
            //   TCP    192.168.20.103:64029   64.25.37.235:10100     ESTABLISHED InHost
            switch (Properties.Settings.Default.Region)
            {
                case "NA":
                    return "64.25.37.235";
                case "EU":
                    return "18.194.180.254";
            }

            throw new ArgumentException();
        }

        private void InitializePingThread()
        {
            var worker = new BackgroundWorker();
            worker.DoWork += (_, arg) =>
            {
                while (Visible)
                {
                    var time = new Stopwatch();
                    time.Start();
                    var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                    {
                        Blocking = true
                    };

                    bool failed = false;

                    try
                    {
                        socket.Connect(GetServerIP(), 10100);
                    }
                    catch (SocketException ex)
                    {
                        Debug.WriteLine(ex);
                        failed = true;
                    }

                    // Ping calculation is totally arbitrary based on TCP connection time,
                    // scaled to sort of match up the delay visible in the in-game overlay
                    if (failed) Ping = null;
                    else Ping = time.Elapsed.TotalMilliseconds * 3; // Round trip + server delay

                    socket.Close();

                    worker.ReportProgress(0, Ping);

                    Thread.Sleep(2000);
                }
            };

            worker.ProgressChanged += (_, arg) =>
            {
                PingLabel.Text = "Game delay: " + (Ping != null ? Ping?.ToString("0.00") + "ms" : "N/A");
            };

            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            InitializeGamePaths();
            InitializePingThread();
            InitializeMods();
            InitializeSplash();
            CheckForUpdates();
        }

        private void ToggleLauncherWarning()
        {
            // Let our wtsapi32.dll know our location
            GetLauncherIni().Write("LastKnownLocation", System.Reflection.Assembly.GetEntryAssembly().Location, "BNSBoost_Settings");

            if (Properties.Settings.Default.HijiackLauncher)
                GetLauncherIni().Write("AlwaysStartBNSBoost", "1", "BNSBoost_Settings");
            else
                GetLauncherIni().DeleteKey("AlwaysStartBNSBoost", "BNSBoost_Settings");

            string target = Path.Combine(Path.GetDirectoryName(Properties.Settings.Default.NCLauncherRPath), "wtsapi32.dll");
            string source = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "wtsapi32_nclauncher.dll");

            try
            {
                if (Properties.Settings.Default.HijiackLauncher || Properties.Settings.Default.PerformLauncherCheck)
                {
                    File.Copy(source, target, true);
                }
                else
                {
                    File.Delete(target);
                }
            }
            catch (IOException ex)
            {
                // This occurs if NC Launcher is already running, not much we can do
                MessageBox.Show("This can happen if NC Launcher is already running. ", "Could not update NC Launcher hook");
            }
        }

        private void ToggleBitness(bool is64)
        {
            GetLauncherIni().Write("Game_64bitEnable", is64 ? "1" : "0", "Settings");
        }

        private void ToggleRegion(string code)
        {
            string region = null;
            if (code == "NA") region = "North America";
            else if (code == "EU") region = "Europe";

            if (region != null) GetLauncherIni().Write("Game_Region", region, "Game_Language_BnS");

            RegionComboBox.SelectedItem = code;
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

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            LaunchButton.Enabled = false;

            // Need to save ourself since form doesn't do it automatically :/
            Properties.Settings.Default.Region = (string)RegionComboBox.SelectedItem;
            Properties.Settings.Default.Save();

            ToggleBitness(Properties.Settings.Default.Is64Bit);
            ToggleRegion(Properties.Settings.Default.Region);
            ToggleLoadingScreens(DisableLoadingScreensCheckBox.Checked);
            ToggleLauncherWarning();

            var worker = new BackgroundWorker();
            worker.DoWork += (_, arg) =>
            {
                Patcher.Patch(worker);
                ModManager.ApplyMods();
                SplashManager.ApplySplash();
            };

            worker.ProgressChanged += (_, arg) =>
            {
                string display = arg.UserState as string;
                Debug.WriteLine(display);
                LaunchButton.Text = display;
            };

            worker.RunWorkerCompleted += async (_, arg) =>
            {
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

                // Launch failed :(
                LaunchButton.Enabled = true;
                LaunchButton.Text = "Launch!";
            };

            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }

        private async Task<int> LaunchAsync(string launcherPath, string extraClientFlags)
        {
            return await Task.Run(() => { return ClientMethods.Launch(launcherPath, extraClientFlags); });
        }

        private void FileDataTreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode dat = e.Node;
            if (dat.Parent != null) return;
            if (dat.Nodes[0].Text == "Decompiling...")
            {
                // Prevent races
                RecompileDatButton.Enabled = false;
                RestoreDatButton.Enabled = false;

                string datFile = Path.Combine(GameDirectoryPathTextBox.Text, @"contents\Local\NCWEST\data\", dat.Text);

                Debug.WriteLine(GameDirectoryPathTextBox);
                Debug.WriteLine(GameDirectoryPathTextBox.Text);

                var worker = new BackgroundWorker();
                worker.DoWork += (_, arg) =>
                {
                    BNSDat.BNSDat.Extract(datFile, (number, of) => worker.ReportProgress(0, new DATState
                    {
                        node = dat,
                        number = number,
                        of = of
                    }), datFile.Contains("64"));
                };

                worker.RunWorkerCompleted += (_, arg) =>
                {
                    if (arg.Error != null)
                    {
                        MessageBox.Show(arg.Error.Message);
                        dat.Collapse();
                        dat.Nodes.Clear();
                        dat.Nodes.Add("Decompiling...");
                    }
                    else
                    {
                        dat.Nodes.Clear();
                        var Q = new LinkedList<KeyValuePair<TreeNode, string>>();
                        Q.AddFirst(new KeyValuePair<TreeNode, string>(dat, datFile + ".files"));


                        while (Q.Count > 0)
                        {
                            var kv = Q.First();
                            Q.RemoveFirst();

                            var node = kv.Key;
                            var path = kv.Value;

                            foreach (string decompFile in Directory.GetFiles(path))
                            {
                                node.Nodes.Add(new TreeNode { Text = Path.GetFileName(decompFile), Name = decompFile });
                            }

                            foreach (string decompDir in Directory.GetDirectories(path))
                            {
                                var newNode = new TreeNode { Text = Path.GetFileName(decompDir), Name = decompDir };
                                node.Nodes.Add(newNode);
                                Q.AddFirst(new KeyValuePair<TreeNode, string>(newNode, decompDir));
                            }
                        }

                        if (WorkerDenominator == 0)
                        {
                            // Allow restoration and recompilation now
                            RecompileDatButton.Enabled = true;
                            RestoreDatButton.Enabled = true;
                            LaunchButton.Enabled = true;
                        }
                    }
                };

                worker.ProgressChanged += Editor_ProgressChanged;
                worker.WorkerReportsProgress = true;
                worker.RunWorkerAsync();
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
                    string datFile = Path.Combine(GameDirectoryPathTextBox.Text, @"contents\Local\NCWEST\data\", dat.Name);
                    Debug.WriteLine(datFile);
                    Process.Start(datFile);
                }
            }
        }

        private void RecompileDatButton_Click(object sender, EventArgs e)
        {
            LaunchButton.Enabled = false;

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

                var dat = FileDataTreeView.Nodes.Find(datName, true)[0];

                var worker = new BackgroundWorker();
                worker.DoWork += (_, arg) =>
                {
                    string backupFile = Path.Combine(unpatchedDir, datName);
                    string patchedFile = Path.Combine(baseDatDir, datName);

                    Debug.WriteLine("Does backup " + backupFile + " exist?");
                    if (!File.Exists(backupFile))
                    {
                        Debug.WriteLine("Backed up file!");
                        File.Copy(patchedFile, backupFile);
                    }

                    BNSDat.BNSDat.Compress(decompFile, (number, of) =>
                    {
                        Debug.WriteLine("????" + number +
                           " ... " + of);
                        worker.ReportProgress(0, new DATState
                        {
                            node = dat,
                            number = number,
                            of = of
                        });
                    }, datName.Contains("64"));
                };

                worker.RunWorkerCompleted += (_, arg) =>
                {
                    LaunchButton.Enabled = WorkerDenominator == 0;

                    if (arg.Error == null)
                    {
                        dat.Collapse();
                        dat.Nodes.Clear();
                        dat.Nodes.Add("Decompiling...");

                        Directory.Delete(decompFile, true);
                    }
                    else
                    {
                        MessageBox.Show(arg.Error.Message);
                    }
                };

                worker.ProgressChanged += Editor_ProgressChanged;
                worker.WorkerReportsProgress = true;

                worker.RunWorkerAsync();
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

        class DATState
        {
            public TreeNode node;
            public int number, of;
        }

        private void Editor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DATState state = (DATState)e.UserState;

            WorkerNumerator++;

            if (state.number == 1) WorkerDenominator += state.of;
            else if (state.number == state.of)
            {
                WorkerDenominator -= state.of;
                WorkerNumerator -= state.of;
            }

            if (state.node.Nodes.Count == 1)
                state.node.Nodes[0].Text = "Decompiling... " + state.number + "/" + state.of;

            DATProgressBar.Value = WorkerDenominator == 0 ? 100 : (int)Math.Round(100.0 * WorkerNumerator / WorkerDenominator);
        }

        private void LatencyDisplayCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            LatencyDurationUpDown.Enabled = LatencyDisplayCheckbox.CheckState == CheckState.Checked;
        }

        private void EnableSkillbookDelayCheckbox_CheckStateChanged(object sender, EventArgs e)
        {
            SkillbookDelayUpDown.Enabled = EnableSkillbookDelayCheckbox.CheckState == CheckState.Checked;
        }

        private void RegionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Region = RegionComboBox.SelectedItem as string;
        }

        private void DisableX3Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            MultiClientCheckbox.Enabled = DisableX3Checkbox.Checked;
        }

        private void RefreshModListButton_Click(object sender, EventArgs e)
        {
            InitializeMods();
        }

        private void OpenModFolderButton_Click(object sender, EventArgs e)
        {
            Process.Start(ModManager.MOD_LOCATION);
        }

        private void RefreshSplashListButton_Click(object sender, EventArgs e)
        {
            InitializeSplash();
        }

        private void OpenSplashFolderButton_Click(object sender, EventArgs e)
        {
            Process.Start(SplashManager.SPLASH_LOCATION);
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
