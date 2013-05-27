using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityConfig
{
    public partial class AddMethod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            txtMethodName.Focus();
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        protected void btnAddMethod_Click(object sender, EventArgs e)
        {
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                
                var MethodName = txtMethodName.Text.Trim();
                long pkID = -1;
                var className = txtClassName.Text.Trim();
                if (btnAddMethod.Text == "Update Method")
                { 

                    var SelectedId= Convert.ToInt64(grdMethods.SelectedDataKey.Value);
                    var ObjMethod = (from vObj in l.L_SECU_ALL_METHODS where vObj.PK_ID == SelectedId select vObj).FirstOrDefault();

                  ///  var ObjMethod = getMethodObj(SelectedId);
                    if(ObjMethod != null)
                    {
                        pkID = ObjMethod.PK_ID;
                        ObjMethod.CLASS_NAME = className;
                        ObjMethod.METHOD_NAME = MethodName;
                    }
                    l.SaveChanges();
                }
                else
                {
                    var ObjMethod = (from vObj in l.L_SECU_ALL_METHODS where vObj.METHOD_NAME == MethodName  select vObj).FirstOrDefault();
                    if (ObjMethod == null)
                    {
                        var objNewMethod = new L_SECU_ALL_METHODS()
                        {
                            //  FK_CONFIG_ID = sectionId,
                            ROW_STATUS = 1,
                            METHOD_NAME = MethodName,
                            CLASS_NAME = className
                        };
                        l.L_SECU_ALL_METHODS.AddObject(objNewMethod);
                        l.SaveChanges();
                        pkID = objNewMethod.PK_ID;
                    }
                    else
                    {
                        lblErrorMessage.Text = "Method already exists";
                    }
                }
                txtMethodName.Text = "";
                txtClassName.Text = "";
                if (pkID > 0)
                {
                    ucMethodArgumentComparator1.SaveComparator(pkID);
                }
            }
            ucMethodArgumentComparator1.resetComparator();
            ucMethodArgumentComparator1.bindComparator(-1);
            BindGrid();
            grdMethods.SelectedIndex = -1;
        }
        private L_SECU_ALL_METHODS getMethodObj(long SelectedID)
        {
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {

                var ObjMethod = (from vObj in l.L_SECU_ALL_METHODS where vObj.PK_ID == SelectedID select vObj).FirstOrDefault();
                return ObjMethod;
            }
        }
        protected void method_selected(object sender, EventArgs e)
        {

            ucMethodArgumentComparator1.resetComparator();
            var SelectedId = Convert.ToInt64(grdMethods.SelectedDataKey.Value);
            var ObjMethod = getMethodObj(SelectedId);
            if (ObjMethod != null)
            {
                txtMethodName.Text = ObjMethod.METHOD_NAME;
                txtClassName.Text = ObjMethod.CLASS_NAME;
            }
            ucMethodArgumentComparator1.bindComparator(SelectedId);
            btnAddMethod.Text = "Update Method";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddMethod.Text = "Add Method";
            ucMethodArgumentComparator1.resetComparator();
            ucMethodArgumentComparator1.bindComparator(-1);
            txtClassName.Text = "";
            txtMethodName.Text = "";
            grdMethods.SelectedIndex = -1;
            BindGrid();
        }

        public void BindGrid()
        {
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {

                var ObjMethod = (from vObj in l.L_SECU_ALL_METHODS
                              //   join vIn in l.L_SECU_METHOD_ARG_COMPARATOR.DefaultIfEmpty() on vObj.PK_ID equals vIn.FK_METHOD_ID
                                
                                 orderby vObj.METHOD_NAME

                                 select new
                                 {
                                     vObj.PK_ID,
                                     vObj.METHOD_NAME,
                                     vObj.ROW_STATUS,
                                     vObj.CLASS_NAME,
                                     Comparator_Count = (from vIn in l.L_SECU_METHOD_ARG_COMPARATOR where vIn.FK_METHOD_ID == vObj.PK_ID select vIn.PK_ID).Count() 
                                 });
                grdMethods.DataSource = ObjMethod;
                grdMethods.DataBind();
            }
        }

        protected void grdMethods_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMethods.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}