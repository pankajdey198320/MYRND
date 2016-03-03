using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component.Interface;

namespace Component.Implementation.LogicComponent
{
    public class StartComponent : BaseComponent<Interface.IMessageContext>
    {
        public StartComponent(List<IConnector> connectors):base(connectors)
        {

        }
        public override void SartComponent(IMessageContext obj)
        {
            base.InvokeNextComponent(obj);
        }


    }

    public class EndComponent : BaseComponent<Interface.IMessageContext>
    {
        public EndComponent()
        {

        }
        public EndComponent(List<IConnector> connectors):base(connectors)
        {

        }
        public override void SartComponent(IMessageContext obj)
        {
            Console.Write("end of route");
        }
    }
}
