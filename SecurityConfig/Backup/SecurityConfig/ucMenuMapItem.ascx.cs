using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityConfig
{
    public partial class ucMenuMapItem : System.Web.UI.UserControl
    {
        private long methodId = 0;
        private string methodName = string.Empty;
        public long MethodID
        {
            set
            {
                methodId = value;
                using (Medappz2_LiveEntities context = new Medappz2_LiveEntities())
                {
                    methodName = (from vMethod in context.L_SECU_ALL_METHODS where vMethod.PK_ID == methodId select vMethod.METHOD_NAME).FirstOrDefault();
                    lblMethodNama.Text = methodName;
                }
            }            
        }
        public override void DataBind()
        {
            
        }
        public long MenuMapId { set; get; }
        public string MethodName {
            get {
                using (Medappz2_LiveEntities context = new Medappz2_LiveEntities())
                {
                    methodName = (from vMethod in context.L_SECU_ALL_METHODS where vMethod.PK_ID == methodId select vMethod.METHOD_NAME).FirstOrDefault();
                }
                return methodName;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region bind Comparator & value
        private void BindGrid()
        {
            using (Medappz2_LiveEntities context = new Medappz2_LiveEntities())
            {
                var Sections = (from 
                                    //vComt in context.L_SECU_MNU_OP_MAP join
                                    //vSecu in context.L_SECU_SECTION_OPERATION_MAP on vComt.FK_OPERATION_MAP_ID equals
                                    //vSecu.PK_ID join 
                                    vMethod in context.L_SECU_ALL_METHODS 
                                    join vComparator in context.L_SECU_METHOD_ARG_COMPARATOR  on vMethod.PK_ID equals
                                    vComparator.FK_METHOD_ID join vVal in context.L_SECU_COMPARATOR_VALUE on vComparator.PK_ID equals
                                    vVal.FK_COMPARATOR_ID
                                //join k in l.L_SECU_ALL_METHODS on v.PK_ID equals k.FK_CONFIG_ID 
                                where vMethod.PK_ID == this.methodId
                                && vVal.FK_MENU_MAP_ID == this.MenuMapId
                                select new
                                {
                                    vComparator.PARAM_KEY,
                                    vComparator.PARAM_INDEX,
                                    vVal.PARAM_VALUE
                                    
                                }).Distinct();
                //lstComparatorValue.DataSource = Sections;
                //lstComparatorValue.DataBind();
               
            }
        }
        #endregion
    }
}