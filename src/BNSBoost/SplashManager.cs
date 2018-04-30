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

        public static string SPLASH_LOCATION => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BNSBoost", "splash");

        private static Dictionary<string, bool> enabledSplashes = new Dictionary<string, bool>();

        public static void Initialize()
        {
            Directory.CreateDirectory(SPLASH_LOCATION);

            foreach (var splash in Directory.GetFiles(SPLASH_LOCATION))
            {
                enabledSplashes[Path.GetFileName(splash)] = true;
            }

            GetSplashList();
        }

        public static void EnableSplash(string splash, bool on)
        {
            enabledSplashes[splash] = on;
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
                    Enabled = enabledSplashes.ContainsKey(name) && enabledSplashes[name]
                });
            }

            return splashes;
        }
    }
}
