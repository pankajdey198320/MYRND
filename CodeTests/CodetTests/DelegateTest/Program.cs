using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCustom v = new MyCustom(10);
            Func<string, int> myDele = (a) => { return Convert.ToInt32(a); };// v.GetLength;
            
            Console.WriteLine(myDele("2"));
            Action<string, Action> myAction = v.DoingTheAction;
            myAction.BeginInvoke("Hey buddy", () =>
            {
               
                Console.WriteLine("Have done enough here buddy");
            }, (x) =>
            {
                if (x.IsCompleted)
                {
                    Console.WriteLine("bingo");
                }
            }, null);
            myAction.BeginInvoke("Hey p", () =>
            {
                
                Console.WriteLine("Have done enough here buddy");
            }, (x) =>
            {
                if (x.IsCompleted)
                {
                    Console.WriteLine("to to");
                }
            }, null);
            Predicate<string> po = (val) =>
            {
                if (val == "pankaj") return true;
                return false;
            };

            MyCustomRepository rp = new MyCustomRepository();
            rp.Sort(rp.CompareBy);
            Console.WriteLine("cpool");
            //Console.ReadKey();
        }
    }
}
