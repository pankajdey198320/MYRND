using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace AiNetSnif
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient cl = new WebClient();
           // cl.BaseAddress = ;
            string s = cl.DownloadString("http://dictionary.reference.com/browse/apple");
        }
    }
}
