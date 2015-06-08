using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstructOrInterface
{
    abstract class AbstractMessageHelper
    {
        public List<MessageItem> Items { get; set; }
        public abstract void Read();
        public void Print() {
            foreach (var item in Items) {
                Console.WriteLine(item.ToString());
            }
        }
        public virtual void WriteToConsole(){
            Console.WriteLine("written from abstract base");

        }
        
    }

    class MessageHelperConcrete : AbstractMessageHelper {

        public MessageHelperConcrete()
        {
            Items = new List<MessageItem>();
            Items.Add(new MessageItem());
        }
        public override void Read()
        {
            Console.WriteLine("Reading");
        }
        public override void WriteToConsole()
        {
            base.WriteToConsole();
            Console.WriteLine("childs play");
        }
        public new void Print()
        {
            base.Print();
            foreach (var item in Items)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }

    class MessageItem {
        public string Body { get; set; }
    }
}
