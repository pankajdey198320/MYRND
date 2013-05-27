using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityConfig
{
    public partial class ConfigINS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Config1.ConfigType =  Convert.ToInt32(ConfigType.App);
                Config1.HeaderName = "Application";
                Config1.bindGrid();
            }
        }

       
    }
}