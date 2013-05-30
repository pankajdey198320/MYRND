using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace TetsApp
{
    public partial class FileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["p"] = 90;
            if (Request.Headers["X-File-Name"] != null)
            {
                try
                {

                    var f = Request.Files;
                    var v = Request.InputStream;
                    var s = File.Create("D:\\temp\\ProfilePic\\Profile.jpg");
                    //  StreamWriter sw=new StreamWriter();
                    v.CopyTo(s);
                    s.Close();
                    v.Close();
                }
                catch (Exception ec)
                { 
                
                }
            }

            var x = Session["p"];
            Response.Write(x.ToString());
        }
    }
}