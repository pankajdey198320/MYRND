using System;
using System.Web.Routing;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using WebApplication1.Utility.Constraint;
namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            var constResolver = new DefaultInlineConstraintResolver();
            constResolver.ConstraintMap.Add("map", typeof(ManuConstraint));
            routes.MapMvcAttributeRoutes(constResolver);
            //routes.MapRoute(
            //    "Default",                                              // Route name 
            //    "{controller}/{action}/{id}",                           // URL with parameters 
            //    new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            //);

        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Write("end of session");
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}