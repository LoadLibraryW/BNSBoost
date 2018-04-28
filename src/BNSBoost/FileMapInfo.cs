using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using BNSBoost.Properties;

namespace BNSBoost
{
    class FileMapInfo
    {
        public static readonly Dictionary<string, string> FILE_HASHES = new Dictionary<string, string>();

        public static void Initialize()
        {
            string fileMapInfo = Path.Combine(Settings.Default.GameDirectoryPath, "FileInfoMap_BnS.dat");
            foreach (string line in File.ReadAllLines(fileMapInfo))
            {
                var tokens = line.Split(':');
                var hash = tokens[2];

                string file = Path.Combine(Settings.Default.GameDirectoryPath, tokens[0]);

                FILE_HASHES.Add(file, hash);
            }
        }
    }
}
