using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    abstract class Product
    {
        public virtual void Display()
        {
            Console.WriteLine("Displaying Base Product");
        }
        public abstract void Print();
    }

    class SalableProduct : Product
    {
        public override void Print()
        {
            Console.WriteLine("This is saleable product");
        }
        public override void Display()
        {
            Console.WriteLine("This is salable product display");
        }
    }

    abstract class ProductFactory
    {
        public abstract Product GetProduct();
    }

    class SalableProductFactory : ProductFactory
    {
        public override Product GetProduct()
        {
            return new SalableProduct();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProductFactory factory = new SalableProductFactory();
            var prod = factory.GetProduct();
            AppDomain dom = AppDomain.CreateDomain("test");
            
            
            prod.Display();
            Console.ReadKey();
        }
            

    }
}
