using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyWorks.Controllers
{
    public class HomeController : Controller
    {
        public string path { get; private set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
      
            ViewData["Message"] = "Your application description page.";
           
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }

    public class DirFile
    {
        public string Name { get; set; }
        public FileType Type { get; set; }
        public string FileId { get; set; }
        public enum FileType
        {
            file,folder
        }
    }
}
