using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityConfig
{
    public partial class Config : System.Web.UI.UserControl
    {

        public long ConfigType { set {
            hdnType.Value = value.ToString();
           
        }
            private get {
                return Convert.ToInt64(hdnType.Value);
            }
        }

        public long ParentID
        {
            set
            {
                hdnParentId.Value = value.ToString();
               
            }
            private get
            {
                return Convert.ToInt64(hdnParentId.Value);
            }
        }

        public string HeaderName {
            set {
                lblname.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            txtName.Focus();
            if (!IsPostBack)
            {
               // bindGrid();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                if (btnSave.Text == "Save")
                {
                    var objName = txtName.Text.Trim();
                    var objType = Convert.ToInt64(hdnType.Value);
                    var objParentId = Convert.ToInt64(hdnParentId.Value);
                    var isExists = (from vConfig in l.L_SECU_CONFIG where vConfig.FK_SCE_CONFIG_TYPE == objType
                                    && vConfig.NAME == objName && vConfig.FK_PK_PARENT_ID == objParentId select vConfig).Count() > 0 ;
                    if (!isExists)
                    {
                        
                        l.L_SECU_CONFIG.AddObject(new L_SECU_CONFIG()
                        {
                            CREATION_DATE = DateTime.Now,
                            DESCRIPTION = txtName.Text,
                            FK_PERMISSION_LEVEL_ID = Convert.ToInt64(ddlPermLevel.SelectedValue),
                            FK_PK_PARENT_ID = objParentId,
                            NAME = objName,
                            REFERANCE = "",
                            FK_SCE_CONFIG_TYPE = objType,
                            ROW_STATUS = 1


                        });
                    }
                    else
                    {
                        lblErrorMsg.Text = "Already exists";
                    }
                }
                else if (btnSave.Text == "Update")
                {
                    var PkID = Convert.ToInt64(GridView1.SelectedDataKey.Value);
                    var obj = (from verSec in l.L_SECU_CONFIG
                               where verSec.PK_ID == PkID
                               select verSec).FirstOrDefault();

                    if (obj != null)
                    {
                        obj.NAME = txtName.Text.Trim();
                        obj.FK_PERMISSION_LEVEL_ID = Convert.ToInt64(ddlPermLevel.SelectedValue);
                    }
                    GridView1.SelectedIndex = -1;
                }
                l.SaveChanges();
                bindGrid();
                txtName.Text = "";
                btnSave.Text = "Save";
            }
        }
        public void bindGrid()
        {
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var ConParentID = Convert.ToInt64(hdnParentId.Value);
                var gridSrc = from vcnf in l.L_SECU_CONFIG
                              join vcnTp in l.L_SECU_CONFIG_TYPE
                              on vcnf.FK_SCE_CONFIG_TYPE equals vcnTp.PK_ID
                              join vplvl in l.L_SECU_PERMISSION_LEVEL on
                              vcnf.FK_PERMISSION_LEVEL_ID equals vplvl.PK_ID
                              where vcnf.FK_PK_PARENT_ID == ConParentID
                              select new { 
                                  vcnf.PK_ID,
                               Name=vcnf.NAME,
                               ConfigType = vcnTp.NAME,
                               PerMissionLevel=vplvl.NAME
                              };

                GridView1.DataSource = gridSrc;
                GridView1.DataBind();

            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var PkID = Convert.ToInt64(e.Keys[0]);
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var obj = (from verSec in l.L_SECU_CONFIG
                           where verSec.PK_ID == PkID
                           select verSec).FirstOrDefault();
                l.L_SECU_CONFIG.DeleteObject(obj);
                l.SaveChanges();
                bindGrid();
                txtName.Text = "";
            }
        }

        protected void configSelected(object sender, EventArgs e)
        {
            var PkID = Convert.ToInt64(GridView1.SelectedDataKey.Value);
            
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var obj = (from verSec in l.L_SECU_CONFIG
                           where verSec.PK_ID == PkID
                           select verSec).FirstOrDefault();

                txtName.Text = obj.NAME;
                ddlPermLevel.SelectedValue = obj.FK_PERMISSION_LEVEL_ID.ToString();
                btnSave.Text = "Update";
            }
        }

        protected void CcancelSave(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            txtName.Text = "";
            GridView1.SelectedIndex = -1;
        }
    }
}