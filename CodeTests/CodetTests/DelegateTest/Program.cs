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
            MyCustom v = new MyCustom();
            Func<string, int> myDele = v.GetLength;
            Console.WriteLine(myDele("pankaj"));
            Action<string,Action> myAction = v.DoingTheAction;
            myAction.BeginInvoke("Hey buddy", () => {
                Console.WriteLine("Have done enough here buddy");
            },(x)=>{
                if(x.IsCompleted){
                    Console.WriteLine("bingo");
                }
            },null);
            Console.ReadKey();
        }
    }
}
