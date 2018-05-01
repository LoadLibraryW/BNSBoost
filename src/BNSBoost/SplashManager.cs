using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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
        public static string MOD_SPLASH_LOCATION => Path.Combine(Properties.Settings.Default.GameDirectoryPath, "contents", "Local", "NCWEST", "ENGLISH", "Splash");
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
            var splashes = GetSplashList().Where(s => s.Enabled).Select(p => p.Path);
            var unpatchedDir = Path.Combine(MOD_SPLASH_LOCATION, "unpatched");
            var unpatchedSplash = Path.Combine(unpatchedDir, "Splash.bmp");
            var origSplash = Path.Combine(MOD_SPLASH_LOCATION, "Splash.bmp");
              
            if (splashes.Any())
            {
                if (!File.Exists(unpatchedSplash))
                {
                    Directory.CreateDirectory(unpatchedDir);
                    File.Copy(origSplash, unpatchedSplash);
                }

                string randomSplash = splashes.ElementAt(new Random().Next(0, splashes.Count()));
                using (Image conv = Image.FromFile(randomSplash))
                {
                    conv.Save(origSplash, ImageFormat.Bmp);
                }
            }
            else
            {
                if (File.Exists(unpatchedSplash))
                {
                    File.Copy(unpatchedSplash, origSplash, true);
                    Directory.Delete(unpatchedDir, true);
                }
            }
        }

        public static List<Splash> GetSplashList()
        {
            var splashes = new List<Splash>();
            var ext = new List<string> { ".jpg", ".gif", ".png", ".bmp" };
            foreach (string file in Directory.GetFiles(SPLASH_LOCATION).Where(f => ext.Contains(Path.GetExtension(f))))
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
