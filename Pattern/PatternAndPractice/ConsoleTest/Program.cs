using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component.Interface;
using Service;

namespace ConsoleTest
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
