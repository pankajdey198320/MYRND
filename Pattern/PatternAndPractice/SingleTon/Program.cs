using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTon
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Repository r = Repository.GetRepository();
            
            //Repository r2 = Repository.GetRepository();

            //Action ac = () =>
            //{
            //    for (long i = 0; i < 5000; i++)
            //    {
            //        r.Add(i.ToString());
            //    }
            //};
            //Action ac2 = () =>
            //{
            //    for (long i = 0; i < 5000; i++)
            //    {
            //        r2.Add(i.ToString());
            //    }
            //};
            //ac.BeginInvoke(null, null);
            //ac2.BeginInvoke(null, null);

            Console.WriteLine("start main");
            Repository.EchoAndReturn("echo");
            Console.WriteLine("after echo");
            string y = Repository.x;
            if (y != null)
            {
                Console.WriteLine("after field access");
            }
            Console.ReadKey();


        }

        
    }



    class Repository {
        private static Repository rep = null;
        public static string x = EchoAndReturn("In type initializer");

        public static string EchoAndReturn(string s)
        {
            Console.WriteLine(s);
            return s;
        }
        private List<string> _ls = new List<string>();
        //static Repository()
        //{
        //    Console.WriteLine("Static");
        //}
        private Repository()
        {
            Console.WriteLine("Private");
            //preventing instance
        }
        public void Add(string val)
        {
            _ls.Add(val);
        }

        public static Repository GetRepository()
        {
            if(rep == null)
            {
                rep = new Repository();
            }
            return rep;
        }
    }
}
