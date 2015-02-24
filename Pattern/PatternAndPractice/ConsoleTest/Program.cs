using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IService service = new ComPointService();
            service.Start();
            Console.ReadKey();
        }
    }
}
