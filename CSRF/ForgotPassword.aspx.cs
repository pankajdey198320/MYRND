using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace CSRF
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["pass"] != null)
                {
                    var req = Request;
                    var isValid = req.UrlReferrer.Authority != HttpContext.Current.Request.ServerVariables["HTTP_HOST"];
                    SendMail(Request.QueryString[0], "test@gmail.com", string.Empty, "Forgot Password", "Your Password is:" + Session["pass"].ToString());
                }
            }
        }
        public  void SendMail(string MailTo, string MailFrom, string attachFiles, string Subject, String Content)
        {
            try
            {
                string from = MailFrom;
                MailAddress mailFrom = new MailAddress(from);
                string to = MailTo;
                MailAddress mailTo = new MailAddress(to);

                using (MailMessage message = new MailMessage(mailFrom, mailTo))
                {
                    message.Priority = MailPriority.Normal;
                    message.Subject = Subject;
                    message.Body = Content;
                    message.Priority = MailPriority.Normal;
                    if (!string.IsNullOrWhiteSpace(attachFiles))
                    {
                        Attachment fileToAttch = new Attachment(attachFiles);
                        message.Attachments.Add(fileToAttch);
                    }

                    SmtpClient client = new SmtpClient();

                    client.Send(message);
                }
            }
            catch (Exception ex)
            {
                //Log Exceptions
            }
        }
    }
}