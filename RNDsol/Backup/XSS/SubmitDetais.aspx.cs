using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XSS
{
    public partial class SubmitDetais : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Session["textValue"] = txtDetails.Text;
            Response.Redirect("DisplayDetails.aspx");
            //Response.Headers.Set("X-XSS-Protection", "none");
            //Response.Write(txtDetails.Text);
        }
    }
}