using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.ServiceModel.Channels;

namespace CORS
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public string DoWork()
        {
            string jsoncallback = HttpContext.Current.Request["jsoncallback"];
            
            return  string.Format("{0}({1})", jsoncallback, "{ 'aa':'pankaj'}");
           // return "pankaj";
            // Add your operation implementation here
           
        }
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public List<Customer> GetCustomers()
        {
            return Customer.GetSampleData().ToList();
        }
        // Add more operations here and mark them with [OperationContract]
    }
}
