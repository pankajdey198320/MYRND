using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestMisc
{
    class Program
    {
        static void Main(string[] args)
        {



            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://127.0.0.1:8080/");
            listener.Start();
            while (true)
            {

                var rw =  listener.GetContextAsync();
                HttpListenerContext context = rw.Result;
                HttpListenerRequest request = context.Request;
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                // Construct a response.
                string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                using (System.IO.Stream output = response.OutputStream)
                {
                   // System.Threading.Thread.Sleep(5000);
                    output.Write(buffer, 0, buffer.Length);
                    // You must close the output stream.
                }
            }
            //IAsyncResult result = listener.BeginGetContext(fo, listener);
            // Applications can do some work here while waiting for the 
            // request. If no work can be done until you have processed a request,
            // use a wait handle to prevent this thread from terminating
            // while the asynchronous operation completes.
            Console.WriteLine("Waiting for request to be processed asyncronously.");
           /// result.AsyncWaitHandle.WaitOne();
            Console.WriteLine("Request processed asyncronously.");
            // listener.Close();
            Console.ReadKey();
        }

        private static void fo(IAsyncResult result)
        {
            //.IsBackground = false;
            HttpListener listener = (HttpListener)result.AsyncState;

            Task.Run(() =>
           {
               // Call EndGetContext to complete the asynchronous operation.
               HttpListenerContext context = listener.EndGetContext(result);
               HttpListenerRequest request = context.Request;
               // Obtain a response object.
               HttpListenerResponse response = context.Response;
               // Construct a response.
               string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
               byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
               // Get a response stream and write the response to it.
               response.ContentLength64 = buffer.Length;
               using (System.IO.Stream output = response.OutputStream)
               {
                   System.Threading.Thread.Sleep(5000);
                   output.Write(buffer, 0, buffer.Length);
                   // You must close the output stream.
               }
           });
            Console.WriteLine("test another");
           var x=  listener.GetContextAsync();//
           // x.Result.
           // new AsyncCallback(fo), listener);
        }
    }
}
