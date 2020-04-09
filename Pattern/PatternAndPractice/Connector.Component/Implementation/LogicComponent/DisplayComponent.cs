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
        public DisplayComponent(List<IConnector> connectors) : base(connectors) { }
        public override void SartComponent(IMessageContext obj)
        {
            Console.WriteLine(obj.Message);
            base.SartComponent(obj);
        }
    }
    public class FormatatedDispayComponent : BaseComponent<IMessageContext>
    {
        public FormatatedDispayComponent(List<IConnector> connectors) : base(connectors) { }
        public override void SartComponent(IMessageContext obj)
        {
            obj.Message += "Modified at component ";
            Console.WriteLine(string.Format("This is formated Dispay of input {0}", obj.Message));
            base.SartComponent(obj);
        }
    }
}
