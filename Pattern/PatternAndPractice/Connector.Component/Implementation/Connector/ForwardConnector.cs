using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component.Implementation.Common;
using Component.Interface;

namespace Component.Implementation
{
    public class ForwardConnector : IConnector
    {
        private Action<IMessageContext> _target;
        private static string obj = "dsa";

        public Conditions ConnectLogic { get; private set; }
        public ComponentConfiguration ComponentConfig { get; set; }
        public IList<IComponent<IMessageContext>> NextComponents { get; set; }


        public ForwardConnector()
        {
            NextComponents = new List<IComponent<IMessageContext>>();
            this.ConnectLogic = new Conditions();
        }
        public ForwardConnector(IComponent<IMessageContext> obj)
        {
            _target = obj.SartComponent;
            this.ConnectLogic = new Conditions();
        }

        public void SetTarget(Action<IMessageContext> target)
        {
            _target = target;
        }

        public void InvokeTarget(IMessageContext context)
        {
            lock (obj)
            {
                if (NextComponents.Count() <= 0)
                {

                    NextComponents.Add(new BasicComponentFactory().CreateComponent(ComponentConfig, new BasicConnectorFactory()));
                }


                int count = 0;
                foreach (var comp in NextComponents)
                {
                    comp.SartComponent(context);
                    //Task.Run(() => {
                    //    System.Threading.Thread.CurrentThread.IsBackground = true;
                    //    context.Message += count++;
                    //    comp.SartComponent(context);
                    //});
                }
            }
            //if (this.ConnectLogic.IsTrue() || this.ConnectLogic.Count == 0)
            //    this._target.Invoke(context);
        }

        public void AddConditionLogic(string leftOperator, string rightOperator, Operator operat)
        {
            //this.ConnectLogic.Add(new Condition() { LeftOperant = leftOperator,RightOperant = rightOperator, Operate = operat });
        }
    }
}
