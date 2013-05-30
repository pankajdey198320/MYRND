using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSRF
{
    public partial class _1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var x = Session["p"];
            Response.Write(x.ToString());
        }
    }
}