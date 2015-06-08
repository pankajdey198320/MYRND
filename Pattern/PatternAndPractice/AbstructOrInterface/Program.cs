using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstructOrInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageHelperConcrete vs = new MessageHelperConcrete();
            vs.WriteToConsole();
            vs.Print();
            Console.ReadKey();

        }
    }
}
