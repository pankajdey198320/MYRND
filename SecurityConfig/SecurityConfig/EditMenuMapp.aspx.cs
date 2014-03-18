using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityConfig
{
    public partial class EditMenuMapp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region Permission Menu Section
        
        
        protected void rLstParentMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMenu.Items.Clear();
            ddlMenu_1.Items.Clear();
            ddlMenu_2.Items.Clear();

            PopulateChiled(Convert.ToInt64(rLstParentMenu.SelectedValue), 1);
        }
        private void PopulateChiled(long parentID, int level)
        {
            var chld = hasChild(parentID);
            if (chld != null)
            {
                if (level == 1)
                {
                    ddlMenu.DataSource = chld;
                    ddlMenu.DataBind();
                }
                else if (level == 2)
                {
                    ddlMenu_1.DataSource = chld;
                    ddlMenu_1.DataBind();
                }
                else if (level == 3)
                {
                    ddlMenu_2.DataSource = chld;
                    ddlMenu_2.DataBind();
                }
                else if (level == 4)
                {
                    ddlMenu_3.DataSource = chld;
                    ddlMenu_3.DataBind();
                }
                hdnLevel.Value = level.ToString();
            }
        }
        private List<L_V_UTILITY_MENU> hasChild(long ParentID)
        {
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var Op = (from v in l.L_V_UTILITY_MENU where v.FK_PARENT_ID == ParentID select v).ToList();
                if (Op.Count == 0)
                    return null;
                else
                {
                    Op.Insert(0, new L_V_UTILITY_MENU() { PK_MENU_ID = -200, MENU_NAME = "---select----" });
                    return Op;
                }
            }

        }
        protected void Menu_selected(object sender, EventArgs e)
        {

            // hdnLevel.Value = "-100";
            var selectedValu = ((DropDownList)sender);
            //  var select = string.IsNullOrWhiteSpace(selectedValu) ? -1 : Convert.ToInt64(selectedValu);

            if (selectedValu.ID == "ddlMenu")
            {
                hdnMenuID.Value = ddlMenu.SelectedValue;
                ddlMenu_1.Items.Clear();

                PopulateChiled(Convert.ToInt64(ddlMenu.SelectedValue), 2);
            }
            else if (selectedValu.ID == "ddlMenu_1")
            {
                hdnMenuID.Value = ddlMenu_1.SelectedValue;
                ddlMenu_2.Items.Clear();
                PopulateChiled(Convert.ToInt64(ddlMenu_1.SelectedValue), 3);
            }
            else if (selectedValu.ID == "ddlMenu_2")
            {
                hdnMenuID.Value = ddlMenu_2.SelectedValue;
                // PopulateChiled(Convert.ToInt64(ddlMenu_2.SelectedValue), 4);
            }

            BindGrid();
            
        }
        #endregion
        private void BindGrid()
        {
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var selectMenu = Convert.ToInt64(hdnMenuID.Value);
                var Items = (from vMap in l.L_SECU_MNU_OP_MAP
                             join
                             vSec in l.L_SECU_SECTION_OPERATION_MAP
                             on vMap.FK_OPERATION_MAP_ID equals vSec.PK_ID
                             where vMap.REFERANCE == selectMenu
                             select vSec.FK_METHOD_ID).Distinct().ToList();
                DataList1.DataSource = Items;
                DataList1.DataBind();
            }
        }
    }
}