using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest
{
    class MyCustom
    {
        public MyCustom(int id)
        {
            this.id = id;
        }
        public int id;
        public int GetLength(string value)
        {
            return id;
        }

        internal void DoingTheAction(string value, Action afterWork)
        {
            Console.WriteLine("have done ::" + value);
            System.Threading.Thread.CurrentThread.IsBackground = false;
            System.Threading.Thread.Sleep(5000);
            if (afterWork != null)
            {
                afterWork();
            }
        }
    }


    class MyCustomRepository : List<MyCustom>
    {
        public MyCustomRepository()
        {
            this.Add(new MyCustom(10));
            this.Add(new MyCustom(12));
            this.Add(new MyCustom(11));
            this.Add(new MyCustom(1));
            this.Add(new MyCustom(132));
            this.Add(new MyCustom(14));
            this.Add(new MyCustom(101));
            this.Add(new MyCustom(19));
            this.Add(new MyCustom(200));
        }
        internal int CompareBy(MyCustom t1, MyCustom t2)
        {
            return t1.id.CompareTo(t2.id);
        }
    }
}
