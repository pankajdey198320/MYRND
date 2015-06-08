using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //CodeStatic.WriteOne();
            //CodeStatic.WriteTwo();


            // NonStatic st = new NonStatic();

            Child c = new Child();
            Console.ReadKey();
        }
    }

    static class CodeStatic
    {
        static CodeStatic()
        {
            Console.WriteLine("Stile benifit");
        }

        public static void WriteOne()
        {
            Console.WriteLine("Write one");
        }

        public static void WriteTwo()
        {
            Console.WriteLine("Write two");
        }
    }

    class NonStatic
    {
        static NonStatic()
        {
            Console.WriteLine("static constructor");
        }
        public void WriteOne()
        {
            Console.WriteLine("Write one");
        }

        public void WriteTwo()
        {
            Console.WriteLine("Write two");
        }
    }

    class Parent
    {
        public Parent()
        {
            Console.WriteLine("Parent");
        }
    }

    class Child : Parent
    {
        public Child()
        {
            Console.WriteLine("child without param" );
        }

        public Child(int val)
        {
            Console.WriteLine("child with param" + val);
        }
    }
}
