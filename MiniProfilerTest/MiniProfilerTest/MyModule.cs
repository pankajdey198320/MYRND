using System;
using System.Diagnostics;
using System.Web;

namespace MiniProfilerTest
{
    public class MyModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            context.AuthenticateRequest += context_AuthenticateRequest;
            context.LogRequest += new EventHandler(OnLogRequest);
            //   context.BeginRequest += context_BeginRequest;
        }
        public void context_BeginRequest(object sender, EventArgs e)
        {
            var s = sender as HttpApplication;

            s.Response.SuppressFormsAuthenticationRedirect = true;


        }
        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            var s = sender as HttpApplication;
         //   Debug.WriteLine("Somethign " + s.User.Identity.Name);
        }

        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //custom logging logic can go here
        }
    }
}
