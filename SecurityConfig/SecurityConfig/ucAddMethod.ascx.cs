using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityConfig
{
    public partial class ucAddMethod : System.Web.UI.UserControl
    {
        public delegate void  MehodAddedEventHandller(object Sender, EventArgs e);
        public event MehodAddedEventHandller methodAdded;
        public string Section
        {
            set;
            get;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAddMethod_Click(object sender, EventArgs e)
        {
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var sectionId = Convert.ToInt64(this.Section);
                var MethodName = txtMethodName.Text;
                l.L_SECU_ALL_METHODS.AddObject(new L_SECU_ALL_METHODS()
                {
                   // FK_CONFIG_ID = sectionId,
                    ROW_STATUS = 1,
                    METHOD_NAME = MethodName
                });
                l.SaveChanges();
                txtMethodName.Text = "";
                if (methodAdded != null)
                {
                    methodAdded(this, new EventArgs());
                }
            }
        }
    }
}