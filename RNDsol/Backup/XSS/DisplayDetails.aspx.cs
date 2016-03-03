using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XSS
{
    public partial class DisplayDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDisplay.Text = Session["textValue"].ToString();

           Response.Cookies.Add(new HttpCookie("test", "this is secrate data"));
        }
    }
}