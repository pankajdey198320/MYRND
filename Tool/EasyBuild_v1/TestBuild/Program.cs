using System;
using System.Threading;
using System.Xml.Linq;
using System.Linq;
using Engine.ScheduleEngine;
using Ninject;
using Infrastructure.Configuration;
using System.Reflection;
using Infrastructure.Interface;
using BuildTask;
using System.Web.Http.SelfHost;
using System.Web.Http;

namespace TestBuild
{
    class Program
    {
        static void Main(string[] args)
        {
            ScheduleTaskEngine eng = new ScheduleTaskEngine(new BasicSchedulingProvider.BaseSchedulingProvider(), new TaskScheduleConfigurationResolver.TaskScheduleConfigurationResolver());
            //eng.start();

            var config = new HttpSelfHostConfiguration("http://localhost:8080");
            config.Routes.MapHttpRoute("API Default", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }

        }
    }

}
