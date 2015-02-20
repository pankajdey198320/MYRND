using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest
{
    class MyCustom
    {
        public int GetLength(string value)
        {
            return value.Length;
        }

        internal void DoingTheAction(string value,Action afterWork) {
            Console.WriteLine("have done ::" + value);
            System.Threading.Thread.Sleep(50000);
            if (afterWork != null) {
                afterWork();
            }
        }
    }
}
