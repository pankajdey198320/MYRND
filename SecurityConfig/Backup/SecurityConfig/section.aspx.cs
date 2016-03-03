using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityConfig
{
    public partial class section : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Config1.ConfigType = Convert.ToInt32(ConfigType.Section);
                Config1.HeaderName = "Section";
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
            ddlScreen.DataBind();
        }

        protected void ddlModule_DataBound(object sender, EventArgs e)
        {
            ddlScreen.DataBind();
        }

        protected void ddlScreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config1.ParentID = string.IsNullOrWhiteSpace(ddlScreen.SelectedValue) ? -100 : Convert.ToInt64(ddlScreen.SelectedValue);
            Config1.bindGrid();
        }

        protected void ddlScreen_DataBound(object sender, EventArgs e)
        {
            Config1.ParentID = string.IsNullOrWhiteSpace(ddlScreen.SelectedValue) ? -100 : Convert.ToInt64(ddlScreen.SelectedValue);
            Config1.bindGrid();
        }
    }
}