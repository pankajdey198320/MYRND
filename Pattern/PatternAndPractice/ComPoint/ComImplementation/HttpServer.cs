using Component.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Component.Interface;
using Component.MessageContext;

namespace ComPoint.ComImplementation
{
    public class HttpServer : CommunicationComponentBase
    {

        class HttpState
        {
            public HttpListener Listner { get; set; }
            public IMessageContext MessageContext { get; set; }
        }
       
        HttpListener listener = new HttpListener();
        public HttpServer()
        {
           
            listener.Prefixes.Add("http://127.0.0.1:8080/");
           // IAsyncResult result = listener.BeginGetContext(fo, state);
            // Applications can do some work here while waiting for the 
        }
        public HttpServer(List<IConnector> connectors) : base(connectors)
        {
           
            listener.Prefixes.Add("http://127.0.0.1:8080/");
            
        }
        public override void SartComponent(IMessageContext obj)
        {
            HttpState state = new HttpState()
            {
                Listner = listener
            };
            listener.Start();
            state.MessageContext = obj;
            IAsyncResult result = listener.BeginGetContext(fo, state);
            ///base.SartComponent(obj);
        }
        private void fo(IAsyncResult result)
        {
            //.IsBackground = false;
            HttpState state = (HttpState)result.AsyncState;

            Task.Run(() =>
            {
                // Call EndGetContext to complete the asynchronous operation.
                HttpListenerContext context = listener.EndGetContext(result);
                HttpListenerRequest request = context.Request;
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                // Construct a response.
                this.InvokeNextComponent(state.MessageContext);
                string responseString = state.MessageContext.Message;/// "<HTML><BODY> Hello world!</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                using (System.IO.Stream output = response.OutputStream)
                {
                    // System.Threading.Thread.Sleep(5000);
                    output.Write(buffer, 0, buffer.Length);
                    // You must close the output stream.
                }
            });
            Console.WriteLine("test another");
            state.Listner.BeginGetContext(new AsyncCallback(fo), new HttpState() { Listner = state.Listner
                , MessageContext = new BaseMessageContext()
            });
        }
    }
}
