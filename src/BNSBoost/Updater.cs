using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BNSBoost
{
    class Updater
    {
        private const string RELEASE_API_ENDPOINT = "https://api.github.com/repos/LoadLibraryW/BNSBoost/releases";

        public class BNSBoostRelease
        {
            public DateTime ReleaseDate;
            public string URL;
            public string Name;

            public bool IsNewerVersion()
            {
                return ReleaseDate > LastUpdateTime();
            }
        }

        public static DateTime LastUpdateTime()
        {
            return File.GetLastWriteTime(System.Reflection.Assembly.GetEntryAssembly().Location);
        }

        public static BNSBoostRelease GetLatestRelease()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            using (var client = new WebClient())
            {
                // Otherwise we get some random "Server committed protocol violation" error
                client.Headers.Add("User-Agent", "BNSBoost");

                var response = client.DownloadString(RELEASE_API_ENDPOINT);

                var releases = JArray.Parse(response);
                var recent = releases[0];

                return new BNSBoostRelease
                {
                    ReleaseDate = DateTime.Parse((string)recent["published_at"]).ToLocalTime(),
                    URL = (string)recent["html_url"],
                    Name = (string) recent["name"]
                };
            }
        }
    }
}