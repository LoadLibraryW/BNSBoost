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
    class ModManager
    {
        public class Mod
        {
            public string Name;
            public string Description;
            public string Path;
            public bool Enabled;
        }

        public static string MOD_LOCATION => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BNSBoost", "mods");

        public static string COOKEDPC_LOCATION => Path.Combine(Properties.Settings.Default.GameDirectoryPath, "contents", "Local", "NCWEST", "ENGLISH", "CookedPC");
        public static string MOD_COOKEDPC_LOCATION => Path.Combine(COOKEDPC_LOCATION, "mods");

        private static Dictionary<string, bool> enabledMods = new Dictionary<string, bool>();

        public static void Initialize()
        {
            Directory.CreateDirectory(MOD_LOCATION);
        }

        public static void EnableMod(string mod, bool on)
        {
            enabledMods[mod] = on;
        }

        public static void ApplyMods()
        {
            Directory.CreateDirectory(MOD_COOKEDPC_LOCATION);
            foreach (var mod in GetModList())
            {
                if (mod.Enabled)
                {
                    ApplyMod(mod);
                }
                else
                {
                    UnapplyMod(mod);
                }
            }
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        static extern bool CreateHardLink(
            string lpFileName,
            string lpExistingFileName,
            IntPtr lpSecurityAttributes
        );

        public static void ApplyMod(Mod mod)
        {
            string modDir = Path.Combine(MOD_COOKEDPC_LOCATION, mod.Name);
            Directory.CreateDirectory(modDir);

            foreach (string target in Directory.GetFiles(mod.Path))
            {
                CreateHardLink(Path.Combine(modDir, Path.GetFileName(target)), target, IntPtr.Zero);
            }
        }

        public static void UnapplyMod(Mod mod)
        {
            try
            {
                Directory.Delete(Path.Combine(MOD_COOKEDPC_LOCATION, mod.Name), true);
            }
            catch (DirectoryNotFoundException ignored)
            {
                // Do nothing
            }
        }

        public static List<Mod> GetModList()
        {
            enabledMods.Clear();
            if (Directory.Exists(MOD_COOKEDPC_LOCATION))
                foreach (var modPath in Directory.GetDirectories(MOD_COOKEDPC_LOCATION))
                {
                    string mod = Path.GetFileName(modPath);
                    enabledMods[mod] = true;
                }

            var mods = new List<Mod>();

            foreach (string dir in Directory.GetDirectories(MOD_LOCATION))
            {
                string descFile = Path.Combine(dir, "description.txt");
                string description = null;

                if (File.Exists(descFile))
                {
                    description = File.ReadAllLines(descFile)[0];
                }

                string name = Path.GetFileName(dir);
                mods.Add(new Mod
                {
                    Name = name,
                    Description = description,
                    Path = dir,
                    Enabled = enabledMods.ContainsKey(name) && enabledMods[name]
                });
            }

            return mods;
        }
    }
}
