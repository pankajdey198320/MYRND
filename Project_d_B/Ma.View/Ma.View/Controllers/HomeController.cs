using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ma.View.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Execute(string sql)
        {
            var sqq = $"select top 1 * from ({sql}) temp";
            var x = this.Executor.Execute(sqq);
            var clmns = new List<string>();
            List< dynamic> _temp = new List<dynamic>();
            foreach( var clm  in x.Tables[0].Columns)
            {
                
                var c = clm as DataColumn;
                clmns.Add(c.ColumnName);
                
            }

            foreach( DataRow t in x.Tables[0].Rows)
            {
                dynamic obj = new ExpandoObject();
                foreach (var clm in clmns)
                {
                   ( (IDictionary<string, object> )obj).Add(clm, t[clm]);
                   // obj[clm] = ;

                }
                _temp.Add(obj);
            }
            return Json(_temp);
        }

        public ActionResult GetProperties(string sql)
        {
            var sqq = $"select top 1 * from ({sql}) temp";
            var x = this.Executor.Execute(sqq);
            var clmns = new List<string>();
            List<dynamic> _temp = new List<dynamic>();
            foreach (var clm in x.Tables[0].Columns)
            {

                var c = clm as DataColumn;
                _temp.Add(new
                {
                    Name = c.ColumnName, Type = c.DataType.Name
                });

            }
            return Json(_temp);

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