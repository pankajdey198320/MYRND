using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TetsApp
{
    public partial class ShowImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                Response.ContentType = "Application/Jpeg";
                Response.WriteFile("D:\\temp\\ProfilePic\\Profile.jpg");
            }
            catch (Exception ex)
            { 
            }
        }
    }
}