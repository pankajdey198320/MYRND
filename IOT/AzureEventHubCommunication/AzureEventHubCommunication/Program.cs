using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace AzureEventHubCommunication
{
    class Program
    {
        static string eventHubName = "iot30062015";
        static string connectionString = "Endpoint=sb://iot30062015.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=QojYys90VvtENiCmwi4Muk6K559wxoLllgvIXteFT08=";


        static void Main(string[] args)
        {
            Console.WriteLine("Press Ctrl-C to stop the sender process");
            Console.WriteLine("Press Enter to start now");
            Console.ReadLine();
            SendingRandomMessages();
        }
        static void SendingRandomMessages()
        {
            var eventHubClient =
                EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
            
            while (true)
            {
                try
                {
                    var message = Guid.NewGuid().ToString();
                    Console.WriteLine("{0} > Sending message: {1}",
                        DateTime.Now, message);

                    EventData eventData = new EventData(
                        Encoding.UTF8.GetBytes(message));

                    //This is how you can include metadata
                    //eventData.Properties["someProp"] = "MyEvent"

                    //this is how you would set the partition key
                    //eventData.PartitionKey = 1.ToString();
                    eventHubClient.Send(eventData);
                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} > Exception: {1}",
                        DateTime.Now, exception.Message);
                    Console.ResetColor();
                }

                Thread.Sleep(5000);
            }
        }
    }
}
