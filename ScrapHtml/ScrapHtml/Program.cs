using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapHtml
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Parse("https://google.co.in");
        }

        private static void Parse(string url)
        {
            List<string> srTgs = new List<string>();
            System.Net.WebClient cl = new System.Net.WebClient();
           // cl.BaseAddress = url;
            var siteData = cl.DownloadString(url);

            bool tagKick = false;
            string tagBuild = string.Empty;
            foreach (var c in siteData)
            {
                Console.WriteLine(c);
                if (c == '<')
                {
                    tagKick = true;

                }
                else if (tagKick == true && c == '>')
                {
                    tagBuild += c;
                    tagKick = false;
                }
                if (tagKick)
                {
                    tagBuild += c;
                }
                if (!string.IsNullOrWhiteSpace(tagBuild) && !tagKick)
                {
                    srTgs.Add(tagBuild);
                    tagBuild = string.Empty;
                }
            }
        }

    }
}
