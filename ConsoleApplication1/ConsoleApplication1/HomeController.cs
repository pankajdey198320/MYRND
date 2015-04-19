using System.Collections.Generic;
using System.Web.Http;

namespace ConsoleApplication1
{
    public class HomeController:ApiController
    {
        [HttpGet]
        public string Stop() {
            return "Successfully Stopped";
        }
    }
}
