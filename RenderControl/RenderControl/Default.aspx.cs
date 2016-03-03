using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RenderControl
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["try"] = new MailModel()
            {
                FirstName = "Pankaj",
                LastName = "dey"

            };
            Page page = new Page();
            var control = page.LoadControl("~/WebUserControl1.ascx");
            //create the runat="server" from that must host asp.net controls
            HtmlForm form = new HtmlForm();
            form.Name = "form1";

            page.Controls.Add(form);
            form.Controls.Add(control);
            //call RenderControl method to get the generated HTML
            string html = RenderControl(control);
            var renderControl = RenderControl(control);
        }
        private string RenderControl(Control control)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter writer = new HtmlTextWriter(sw);

            control.RenderControl(writer);
            return sb.ToString();
        }
    }
}