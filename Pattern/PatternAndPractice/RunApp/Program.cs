using System;
using Component.Interface;
using Service;

namespace RunApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IService service = new ExecutionService(new JsonFileConfigurationService(), new BasicComponentFactory(), new BasicConnectorFactory());
            service.Start((m) =>
            {
                Console.Write(m.Message);
            }, (m) => { Console.Write(m.Message); });
            Console.ReadKey();
        }
    }
}
