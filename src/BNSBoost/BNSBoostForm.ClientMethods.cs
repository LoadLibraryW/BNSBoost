using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BNSBoost
{
    class ClientMethods
    {
        public static int Launch(
            string lpLauncher,
            string lpExtraClientFlags
        )
        {
            NativeMethods.STARTUPINFO si = new NativeMethods.STARTUPINFO();
            NativeMethods.PROCESS_INFORMATION pi = new NativeMethods.PROCESS_INFORMATION();

            string baseDir = new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).DirectoryName;
            Environment.SetEnvironmentVariable("__BNSBOOST_CLIENTFLAGS", lpExtraClientFlags);
            Environment.SetEnvironmentVariable("__BNSBOOST_BASEDIR", baseDir);

            if (Properties.Settings.Default.Is64Bit)
                Environment.SetEnvironmentVariable("__BNSBOOST_IS64", "1");

            if (Properties.Settings.Default.DisableX3)
            {
                Environment.SetEnvironmentVariable("__BNSBOOST_NOX3", "1");
                if (Properties.Settings.Default.MultiClientEnabled)
                    Environment.SetEnvironmentVariable("__BNSBOOST_MULTICLIENT", "1");
            }

            if (!NativeMethods.CreateProcess(null,
                $"\"{lpLauncher}\" /LauncherID:\"NCWest\" /CompanyID:\"12\" /GameID:\"BnS\" /LUpdateAddr:\"updater.nclauncher.ncsoft.com\"",
                IntPtr.Zero,
                IntPtr.Zero,
                false,
                NativeMethods.ProcessCreationFlags.CREATE_SUSPENDED,
                IntPtr.Zero,
                null,
                ref si,
                out pi))
            {
                MessageBox.Show($"Failed to spawn launcher: {Marshal.GetLastWin32Error()} :-(");
                return -1;
            }

            Process process = new Process
            {
                StartInfo =
                    {
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        FileName = "inject32.exe",
                        Arguments = $"\"{Path.Combine(baseDir, "agent_launcher.dll")}\" {pi.dwProcessId}"
                    }
            };
            process.Start();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                MessageBox.Show($"Injector failed: {process.ExitCode} :-(");
            }

            NativeMethods.ResumeThread(pi.hThread);
            NativeMethods.WaitForSingleObject(pi.hProcess, UInt32.MaxValue);

            uint exitcode;
            NativeMethods.GetExitCodeProcess(pi.hProcess, out exitcode);

            // // 0xB00573D is regular agent exit code
            return exitcode == 0xB00573D ? 0 : (int)exitcode;
        }
    }
}