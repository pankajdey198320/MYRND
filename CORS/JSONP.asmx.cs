using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;

namespace CORS
{
    /// <summary>
    /// Summary description for JSONP
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
   
    public class JSONP : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod( UseHttpGet=true, ResponseFormat = ResponseFormat.Json,XmlSerializeString=false)]
        public void HelloWorld()
        {
            var json = new JavaScriptSerializer(null).Serialize(new
            {
                Prop1 = "some property panka",
            });
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            string jsoncallback = HttpContext.Current.Request["callback"];
            Context.Response.Write(string.Format("{0}({1})", jsoncallback, json));
           
        }
    }
}
