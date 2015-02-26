using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component.Interface;

namespace Component.Implementation.LogicComponent
{
    public class DisplayComponent:BaseComponent<IMessageContext>
    {
        public override void SartComponent(IMessageContext obj)
        {
            Console.WriteLine(obj.Message);
        }
    }
    public class FormatatedDispayComponent : BaseComponent<IMessageContext>
    {
        public override void SartComponent(IMessageContext obj)
        {
            Console.WriteLine(string.Format("This is formated Dispay of input {0}", obj.Message));
        }
    }
}
