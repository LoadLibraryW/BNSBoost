using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace BNSBoost
{
    class Patcher
    {
        public static string GetSHA1Hash(string filePath)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return Convert.ToBase64String(sha1.ComputeHash(fs)).TrimEnd('=');
            }
        }



        public static bool ApplyOption(XmlDocument document, string opt, object value)
        {
            XmlElement node = (XmlElement)document.SelectSingleNode($"//option[@name = '{opt}']");
            node?.SetAttribute("value", value.ToString());
            Debug.WriteLine(node);
            return node != null;
        }

        public static bool ApplyOptimizedGraphicsMode(XmlDocument document)
        {
            return ApplyOption(document, "use-optimal-performance-mode-option", true);
        }

        public static bool ApplyDPSMeter(XmlDocument document)
        {
            string[] options =
            {
                "showtype-public-zone",
                "showtype-party-6-dungeon-and-cave",
                "showtype-field-zone",
                "showtype-classic-field-zone",
                "showtype-faction-battle-field-zone",
                "showtype-jackpot-boss-zone"
            };

            bool success = true;

            foreach (string opt in options)
            {
                success &= ApplyOption(document, opt, 2);
            }

            return success;
        }

        public static bool ApplySkillbookDelay(XmlDocument document)
        {
            double cd = 0.5;
            return ApplyOption(document, "command-action-ready-time", cd);
        }

        public static bool ApplyAverageRating(XmlDocument document)
        {
            return ApplyOption(document, "use-team-average-score", "true");
        }

        public static bool ApplySeeOpposingTeam(XmlDocument document)
        {
            // TODO
            return true;
        }

        public static bool ApplyToggleEULA(XmlDocument document)
        {
            // TODO
            return true;
        }

        public static bool ApplyExitImmediately(XmlDocument document)
        {
            return ApplyOption(document, "exit-game-waiting-time", 1.0);
        }

        public static bool ApplyLatencyDisplay(XmlDocument document)
        {
            // TODO
            return true;
        }

        public static bool ApplyAFKDisconnect(XmlDocument document)
        {
            return ApplyOption(document, "limit-time-for-user-away-status", 0);
        }

        public static void Patch()
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"C:\Program Files (x86)\NCSOFT\BnS\contents\Local\NCWEST\data\xml64.dat.files\client.config2.xml");

            Debug.WriteLine("----");

            ApplyOptimizedGraphicsMode(document);
            ApplyDPSMeter(document);
            ApplySkillbookDelay(document);
            ApplyAverageRating(document);
            ApplySeeOpposingTeam(document);
            ApplyToggleEULA(document);
            ApplyExitImmediately(document);
            ApplyLatencyDisplay(document);
            ApplyAFKDisconnect(document);

            document.Save(@"C:\Program Files (x86)\NCSOFT\BnS\contents\Local\NCWEST\data\xml64.dat.files\client.config2.xml.new");

            Debug.WriteLine("----");
        }
    }
}
