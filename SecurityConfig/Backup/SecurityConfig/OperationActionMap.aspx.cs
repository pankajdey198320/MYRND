using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityConfig
{
    public partial class OperationActionMap : System.Web.UI.Page
    {
        List<Comparator> _tempObj = new List<Comparator>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
                Session["TempComparator"] = _tempObj;
            }
        }
        /// <summary>
        /// event handler fired while ddl screen dropdown  selected index changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlScreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindSections();
        }
        /// <summary>
        /// event handler fired while ddl section dropdown dat bounded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSection_DataBound(object sender, EventArgs e)
        {
            bindMethods();
            bindGrid();
        }
        /// <summary>
        /// event handler fired while ddl screen dropdown dat bounded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlScreen_DataBound(object sender, EventArgs e)
        {
            bindSections();
        }

        
        /// <summary>
        /// event handllr for section ddl change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnSave.Text != "Update")
            {
                bindMethods();
                bindGrid();
                grdOpAcMap.SelectedIndex = -1;
            }
            //resetComparator();
            //bindComparator();
        }
        /// <summary>
        /// Binds Sections from database
        /// </summary>
        private void bindSections()
        { var selecteScreenn =string.IsNullOrWhiteSpace(ddlScreen.SelectedValue)?-1: Convert.ToInt64(ddlScreen.SelectedValue);

            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var Sections = (from v in l.L_SECU_CONFIG 
                                //join k in l.L_SECU_ALL_METHODS on v.PK_ID equals k.FK_CONFIG_ID 
                               where v.ROW_STATUS == 1 &&
                                    v.FK_SCE_CONFIG_TYPE == 4 &&
                                    //(from x in l.L_SECU_SECTION_OPERATION_MAP  
                                    // where x.FK_SCE_CONFIG_ID == v.PK_ID && x.OPERATION_NAME == k.METHOD_NAME select x).Count() <1 &&
                                   v.FK_PK_PARENT_ID == selecteScreenn
                               select new
                               {
                                   v.PK_ID,v.NAME
                               }).Distinct();
                ddlSection.DataTextField = "NAME";
                ddlSection.DataValueField = "PK_ID";
                ddlSection.DataSource = Sections;
                ddlSection.DataBind();
                btnSave.Text = "Save";
            }
        }
        /// <summary>
        /// Bind Methods to ddl from database
        /// </summary>
        private void bindMethods()
        {
            var selecteScreenn = string.IsNullOrWhiteSpace(ddlSection.SelectedValue) ? -1 : Convert.ToInt64(ddlSection.SelectedValue);

            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var Sections = (from v in l.L_SECU_ALL_METHODS 
                                where v.ROW_STATUS == 1 
                                orderby v.METHOD_NAME
                                //&&
                                    
                                  //   (from x in l.L_SECU_SECTION_OPERATION_MAP
                                    //  where  x.OPERATION_NAME == v.METHOD_NAME
                                      //select x).Count() < 1 
                                      ///&&  v.FK_CONFIG_ID == selecteScreenn
                                select new
                                {
                                   NAME= v.METHOD_NAME,
                                   PK_ID= v.PK_ID
                                }).Distinct();
                ddlMethods.DataTextField = "NAME";
                ddlMethods.DataValueField = "PK_ID";
                ddlMethods.DataSource = Sections;
                ddlMethods.DataBind();
            }
        }


        private void DeleteMapping(long ID)
        {
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                try
                {
                    var DependentPermission = from vPer in l.l_SECU_MP_OPERATION_PERMISSION
                                              where vPer.FK_OPERATION_MAP_ID == ID
                                              select vPer;
                    foreach (l_SECU_MP_OPERATION_PERMISSION c in DependentPermission)
                    {
                        l.DeleteObject(c);
                    }
                    var DependendOp = from vOp in l.L_SECU_MNU_OP_MAP where vOp.FK_OPERATION_MAP_ID == ID select vOp;

                    foreach (L_SECU_MNU_OP_MAP c in DependendOp)
                    {
                        l.DeleteObject(c);
                    }

                    l.DeleteObject((from vObj in l.L_SECU_SECTION_OPERATION_MAP where vObj.PK_ID == ID select vObj).FirstOrDefault());
                    l.SaveChanges();
                }
                catch (Exception Eobj)
                {
                    System.Diagnostics.Debug.WriteLine(Eobj.Message);
                }
            }
        }
        /// <summary>
        /// method to bind opAction mapping grid
        /// </summary>
        private void bindGrid()
        {
            var selecteScreenn = string.IsNullOrWhiteSpace(ddlSection.SelectedValue) ? -1 : Convert.ToInt64(ddlSection.SelectedValue);

            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var Operations = from x in l.L_SECU_SECTION_OPERATION_MAP
                                 join y in l.L_SECU_CONFIG on x.FK_SCE_CONFIG_ID equals y.PK_ID
                                  join z in l.l_SECU_OPERATION_ACTION on x.FK_ACTION_ID  equals z.PK_ID
                                  join vMethod in l.L_SECU_ALL_METHODS on x.FK_METHOD_ID equals vMethod.PK_ID
                                 where x.ROW_STATUS == 1 && y.ROW_STATUS == 1 && x.FK_SCE_CONFIG_ID == selecteScreenn
                                 select new {
                                     x.PK_ID,
                                   SectionName = y.NAME,
                                     OperationName = vMethod.METHOD_NAME,
                                   ActionAssociated = z.ACTION_NAME
                                 
                                 };
                                 //   where  x.OPERATION_NAME == v.METHOD_NAME
                grdOpAcMap.DataSource = Operations;
                grdOpAcMap.DataBind(); 
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdOpAcMap.PageIndex = e.NewPageIndex;
            bindGrid();
        }



        protected void GrdOpMap_RowDeleting(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GrdOpMap_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var pkID = grdOpAcMap.DataKeys[e.RowIndex].Value == null ? -1 : Convert.ToInt64(grdOpAcMap.DataKeys[e.RowIndex].Value);
            if(pkID >0)
            {
                DeleteMapping(pkID);
            }
            bindGrid();
        }
        /// <summary>
        /// event handller to save OpAction mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OpMapSave(object sender, EventArgs e)
        {
            
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var selectedAction = Convert.ToInt64(RadioButtonList1.SelectedValue);
                var selectedSection = Convert.ToInt64(ddlSection.SelectedValue);
                var selectedMethod = Convert.ToInt64(ddlMethods.SelectedValue);
               
                

                    if (btnSave.Text == "Update")
                    {
                        var selectPk = Convert.ToInt64(grdOpAcMap.SelectedDataKey.Value);
                        var IsExistMap = (from vMap in l.L_SECU_SECTION_OPERATION_MAP
                                          where vMap.FK_ACTION_ID == selectedAction
                                          && vMap.FK_METHOD_ID == selectedMethod
                                          && vMap.FK_SCE_CONFIG_ID == selectedSection && vMap.PK_ID != selectPk
                                          select vMap).Count() > 0;
                        if (!IsExistMap)
                        {
                            var objSecuMap = (from vMap in l.L_SECU_SECTION_OPERATION_MAP where vMap.PK_ID == selectPk select vMap).FirstOrDefault();
                            objSecuMap.FK_ACTION_ID = selectedAction;
                            objSecuMap.FK_METHOD_ID = selectedMethod;
                            objSecuMap.OPERATION_NAME = ddlMethods.SelectedItem.Text;
                            objSecuMap.FK_SCE_CONFIG_ID = selectedSection;
                        }

                    }
                    else
                    {
                        var IsExistMap = (from vMap in l.L_SECU_SECTION_OPERATION_MAP
                                          where vMap.FK_ACTION_ID == selectedAction
                                          && vMap.FK_METHOD_ID == selectedMethod
                                          && vMap.FK_SCE_CONFIG_ID == selectedSection
                                          select vMap).Count() > 0;
                        if (!IsExistMap)
                        {
                            var objSectionActionMap = new L_SECU_SECTION_OPERATION_MAP()
                            {
                                CREATION_DATE = DateTime.Now,
                                FK_ACTION_ID = selectedAction,
                                ROW_STATUS = 1,
                                OPERATION_NAME = ddlMethods.SelectedItem.Text,
                                FK_METHOD_ID = selectedMethod,
                                FK_SCE_CONFIG_ID = selectedSection

                            };


                            l.L_SECU_SECTION_OPERATION_MAP.AddObject(objSectionActionMap);
                        }
                    }
                
                l.SaveChanges();
                
                
                bindSections();
                bindGrid();
                grdOpAcMap.SelectedIndex = -1;
            }
        }

        protected void grdOpMap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void OpActionMapSelected(object sender, EventArgs e)
        {
            var selectPk = Convert.ToInt64(grdOpAcMap.SelectedDataKey.Value);
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var objMethodMap = (from vMap in l.L_SECU_SECTION_OPERATION_MAP
                                 where vMap.PK_ID == selectPk
                                 select
                                     new
                                     {
                                         vMap.FK_METHOD_ID,
                                         vMap.FK_ACTION_ID
                                     }).FirstOrDefault();
                if (objMethodMap != null)
                {
                    btnSave.Text = "Update";
                    ddlMethods.SelectedValue = objMethodMap.FK_METHOD_ID.ToString();
                    RadioButtonList1.SelectedValue = objMethodMap.FK_ACTION_ID.ToString();
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            ddlMethods.SelectedIndex = 0;
            RadioButtonList1.SelectedIndex = -1;
            grdOpAcMap.SelectedIndex = -1;
        }



        
    }
}