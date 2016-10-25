using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GetHeader();
            //return Content(GetHeader());
            return View();
        }

        public string GetHeader()
        {
            string content;
            String MyURI = "http://localhost:81/";
            WebRequest WReq = WebRequest.Create(MyURI);
            WReq.Credentials = new NetworkCredential("foo", "foopass");
            using (var resp = WReq.GetResponse())
            {
                var reader = new StreamReader(resp.GetResponseStream());
                content = reader.ReadToEnd();
            }
            return                 WReq.Headers["authorization"];
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}