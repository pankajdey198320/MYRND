using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1
{
    public class HomeController : Controller
    {
        // GET: Home
        [Route("pappu/dance")]
        public ActionResult Index(int v)
        {
            
            return View();
        }
        // GET: Home
        [HttpPost]
        [Route("pappu/dance")]
        public ActionResult Index()
        {

            return View();
        }
        [Route("user/{name:map(pankaj)}")]
        public ActionResult GetUser(string name)
        {
            ViewBag.name = name;
            return View();
        }

    }
}