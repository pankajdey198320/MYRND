using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TetsApp.Domain_Classes;
namespace TetsApp.Effected_Pages
{
    public partial class StreamOutput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdMyMessageStream.DataSource = MessageController.GetAllMessage();
                grdMyMessageStream.DataBind();
            }
        }
    }
}