using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityConfig
{
    public partial class Screen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Config1.ConfigType = Convert.ToInt32(ConfigType.Screen); ;
                Config1.HeaderName = "Screen";
            }
        }

        protected void ddlApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlModule.DataBind();
            //Config1.ParentID = Convert.ToInt64(ddlApp.SelectedValue);
            //Config1.bindGrid();
        }

        protected void ddlApp_DataBound(object sender, EventArgs e)
        {
            
        }

        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config1.ParentID = string.IsNullOrWhiteSpace(ddlModule.SelectedValue) ? -100 : Convert.ToInt64(ddlModule.SelectedValue);
            Config1.bindGrid();
        }

        protected void ddlModule_DataBound(object sender, EventArgs e)
        {
            Config1.ParentID = string.IsNullOrWhiteSpace(ddlModule.SelectedValue) ? -100 : Convert.ToInt64(ddlModule.SelectedValue);
            Config1.bindGrid();
        }
    }
}