using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace BNSBoost
{
    static class Program
    {
        [DllImport("Injector.dll")]
        public static extern int Launch([MarshalAs(UnmanagedType.LPWStr)] string lpLauncherBaseDir,
                                        [MarshalAs(UnmanagedType.LPWStr)] string lpExtraClientFlags);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BNSBoostForm());
        }
    }
}
