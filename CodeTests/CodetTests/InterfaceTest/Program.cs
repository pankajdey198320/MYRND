using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTest
{
    class Program
    {
        static void Main(string[] args)
        {
          

            string a = "The computer ate my source code.";
            string b = "The computer ate my source code.";
            if (String.ReferenceEquals(a, b))
                Console.WriteLine("a and b are interned.");
            else
                Console.WriteLine("a and b are not interned.");
            IP1 c = new Concreat();
            c.print();
            Console.ReadKey();
        }
    }
    interface IP1
    {
        void print();
    }
    interface IP2
    {
        void print();
    }

    class Concreat:IP1,IP2
    {
       public void print()
        {
            Console.WriteLine("Class level imlementation");
        }

       void IP2.print()
       {
           Console.WriteLine("print function 2");
       }

       void IP1.print()
       {
           Console.WriteLine("print function 1");
       }
    }
}
