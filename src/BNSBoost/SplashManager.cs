using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BNSBoost
{
    class SplashManager
    {
        public class Splash
        {
            public string Name;
            public string Path;
            public bool Enabled;
        }

        public static string SPLASH_LOCATION = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BNSBoost", "splash");
        private static IniFile splashConfig;

        public static void Initialize()
        {
            Directory.CreateDirectory(SPLASH_LOCATION);
            splashConfig = new IniFile(Path.Combine(SPLASH_LOCATION, "splash.ini"));
        }

        public static void EnableSplash(string splash, bool on)
        {
            splashConfig.Write(splash, on ? "1" : "0");
        }

        public static void ApplySplash()
        {
            // TODO
        }

        public static List<Splash> GetSplashList()
        {
            var splashes = new List<Splash>();

            foreach (string file in Directory.GetFiles(SPLASH_LOCATION))
            {
                string name = Path.GetFileName(file);
                splashes.Add(new Splash
                {
                    Name = name,
                    Path = file,
                    Enabled = splashConfig.KeyExists(name) && splashConfig.Read(name) == "1"
                });
            }

            return splashes;
        }
    }
}
