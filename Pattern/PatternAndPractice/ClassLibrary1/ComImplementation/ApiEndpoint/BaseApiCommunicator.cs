using Component.Implementation;
using Component.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComPoint.ComImplementation.ApiEndpoint
{
    public class BaseApiCommunicator : CommunicationComponentBase
    {
        SimpleHttpClient _client;
        public BaseApiCommunicator(List<IConnector> connectors, Dictionary<string, string> property) : base(connectors)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            _client = new SimpleHttpClient();
            Properties = property;
            if (string.IsNullOrWhiteSpace(Properties["BaseUrl"]))
                throw new InvalidOperationException("Not url provided");
            _client.BaseAddress = new Uri(Properties["BaseUrl"]);//("https://jsonplaceholder.typicode.com/");
            if (string.IsNullOrWhiteSpace(Properties["Url"]))
                throw new InvalidOperationException("Not url provided");
        }

        public override void SartComponent(IMessageContext obj)
        {

            var result = _client.GetStringAsync(Properties["Url"]);
            result.Wait();
            obj.Message = result.Result;
            base.SartComponent(obj);
        }
    }

    public class SimpleHttpClient : HttpClient
    {

    }
}
