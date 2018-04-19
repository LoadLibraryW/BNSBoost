using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Xml;
using BNSBoost.Properties;

namespace BNSBoost
{
    class Patcher
    {
        private static readonly List<Action<XmlDocument>> XML_DAT_PATCHES = new List<Action<XmlDocument>> {
            document => ApplyOption(document, "use-optimal-performance-mode-option", Settings.Default.EnableOptimizedMode ? "true" : "false"),
            document => ApplyOption(document, "train-complete-delay-time", Settings.Default.SkillbookDelayEnabled? Settings.Default.SwitchDelayValue : (decimal) 1.5),
            document =>
            {
                foreach (var opt in new[] {
                    "showtype-public-zone",
                    "showtype-party-6-dungeon-and-cave",
                    "showtype-field-zone",
                    "showtype-classic-field-zone",
                    "showtype-faction-battle-field-zone",
                    "showtype-jackpot-boss-zone"
                }) ApplyOption(document, opt, Settings.Default.ShowDPSMeter? 2 : 0);
            },
            document => ApplyOption(document, "use-team-average-score", Settings.Default.ShowAverageScore ? "true" : "false"),
            document => { /* See opposing team */ },
            document => ApplyOption(document, "exit-game-waiting-time", Settings.Default.ExitGameImmediately ? 1.0 : 10.0),
            document => ApplyOption(document, "show-duration", Settings.Default.ChangeLatencyDisplayTime? Settings.Default.LatencyShowTimeValue : (decimal)2.0)
        };

        private static readonly List<Action<XmlDocument>> CONFIG_DAT_PATCHES = new List<Action<XmlDocument>> {
            document => ApplyOption(document, "show-clause",  Settings.Default.DisableEULAPrompt ? "false" : "true"),
            document => ApplyOption(document, "limit-time-for-user-away-status", Settings.Default.DisableAFKDisconnect ?  0 : 3600)
        };

        private static readonly Dictionary<string, object> OriginalSettings = new Dictionary<string, object>();

        public static void Initialize()
        {
            foreach (string file in new[] {"xml.dat", "xml64.dat", "config.dat", "config64.dat"})
            {
                foreach (string setting in GetPatchSettingsFor(file))
                {
                    OriginalSettings[setting] = Settings.Default[setting];
                }
            }
        }

        public static string[] GetPatchSettingsFor(string what)
        {
            switch (what)
            {
                case "xml.dat":
                case "xml64.dat":
                    return new[] { "EnableOptimizedMode", "SkillbookDelayEnabled", "SwitchDelayValue", "ShowDPSMeter", "ShowAverageScore",
                                   "ExitGameImmediately", "ChangeLatencyDisplayTime", "LatencyShowTimeValue"};
                case "config.dat":
                case "config64.dat":
                    return new[] { "DisableEULAPrompt", "DisableAFKDisconnect" };
            }

            throw new ArgumentException();
        }

        public static bool HasPatchesEnabled(string what)
        {
            foreach (string setting in GetPatchSettingsFor(what))
            {
                if (Settings.Default[setting] as bool? == true) return true;
            }
            return false;
        }

        public static List<Action<XmlDocument>> GetPatchesFor(string what)
        {
            switch (what)
            {
                case "xml.dat":
                case "xml64.dat":
                    return XML_DAT_PATCHES;
                case "config.dat":
                case "config64.dat":
                    return CONFIG_DAT_PATCHES;
            }

            throw new ArgumentException();
        }

        public static string GetPatchFileFor(string what)
        {
            switch (what)
            {
                case "xml.dat":
                case "xml64.dat":
                    return "client.config2.xml";
                case "config.dat":
                case "config64.dat":
                    return "system.config2.xml";
            }

            throw new ArgumentException();
        }

        public static string GetDatfilePath(string what)
        {
            return Path.Combine(Settings.Default.GameDirectoryPath, "contents", "Local", "NCWEST", "data", what);
        }

        public static bool IsHashOutdatedAndUpdate(string what)
        {
            string newHash = GetSHA1Hash(GetDatfilePath(what));
            string oldHash = Settings.Default[$"Hash_{what.Replace('.', '_')}"] as string;
            bool outdated = oldHash != newHash;
            Debug.WriteLine($"Check if {what} patch is outdated: '{oldHash}' != '{newHash}': {outdated} ");
            return outdated;
        }

        public static void UpdateHash(string what)
        {
            Settings.Default[$"Hash_{what.Replace('.', '_')}"] = GetSHA1Hash(GetDatfilePath(what));
            Settings.Default.Save();
        }

        public static void PatchFile(BackgroundWorker worker, string what, bool is64)
        {
            string datPath = GetDatfilePath(what);

            BNSDat.BNSDat.Extract(datPath, (number, of) =>
            {
                worker.ReportProgress(0, $"Decompiling {what}... {number} / {of}");
            }, is64);

            worker.ReportProgress(0, $"Patching {what}...");

            string xmlPath = Path.Combine($"{datPath}.files", GetPatchFileFor(what));
            XmlDocument document = new XmlDocument();
            document.Load(xmlPath);
            ApplyPatchList(GetPatchesFor(what), document);
            document.Save(xmlPath);

            BNSDat.BNSDat.Compress($"{datPath}.files", (number, of) =>
            {
                worker.ReportProgress(0, $"Recompiling {what}... {number} / {of}");
            }, is64);
        }

        public static bool HasPatchChanges(string what)
        {
            foreach (string setting in GetPatchSettingsFor(what))
            {
                Debug.WriteLine($"{setting}: {OriginalSettings[setting]} == {Settings.Default[setting]}");
                if (OriginalSettings[setting] != Settings.Default[setting])
                {
                    Debug.WriteLine($"{what} settings changed! Must reapply.");
                    return true;
                }
            }

            return false;
        }

        public static string GetSHA1Hash(string filePath)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return Convert.ToBase64String(sha1.ComputeHash(fs)).TrimEnd('=');
            }
        }

        public static void ApplyPatchList(List<Action<XmlDocument>> patches, XmlDocument document)
        {
            foreach (var action in patches)
            {
                action(document);
            }
        }

        public static bool ApplyOption(XmlDocument document, string opt, object value)
        {
            XmlElement node = (XmlElement)document.SelectSingleNode($"//option[@name = '{opt}']");
            node?.SetAttribute("value", value.ToString());
            Debug.WriteLine(node?.OuterXml);
            return node != null;
        }

        public static void Patch(BackgroundWorker worker)
        {
            bool is64 = Settings.Default.Is64Bit;
            string bit = is64 ? "64" : "";

            foreach (string file in new[] { $"xml{bit}.dat", $"config{bit}.dat" })
                if (HasPatchChanges(file) || IsHashOutdatedAndUpdate(file) && HasPatchesEnabled(file))
                {
                    PatchFile(worker, file, is64);
                    UpdateHash(file);
                }

            worker.ReportProgress(100, "Launching...");
        }
    }
}
