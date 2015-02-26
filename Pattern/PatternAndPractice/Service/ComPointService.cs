using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComPoint.ComImplementation.Tcp;
using Component;
using Component.Implementation;
using Component.Implementation.LogicComponent;
using Component.Interface;
using Component.MessageContext;

namespace Service
{
    public class ComPointService : IService
    {

        TcpServerCompoint compBase;
        IComponent<IMessageContext> _display;


        public ComPointService()
        {
            _display = new DisplayComponent();
            var displayF = new FormatatedDispayComponent();
            compBase = new TcpServerCompoint();
            var connector = new ForwardConnector();
            connector.SetTarget(_display.SartComponent);

            var c2 = new ForwardConnector();
            c2.SetTarget(displayF.SartComponent);
            c2.AddConditionLogic("a", "b", Component.Implementation.Common.Operator.Equal);
            compBase.AddNextCompExecutionPoint(connector);
            compBase.AddNextCompExecutionPoint(c2);
        }
        public void Start()
        {
            compBase.SartComponent(null);
        }
    }
}
