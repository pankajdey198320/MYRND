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

        public Conditions ConnectLogic { get; private set; }

        public ForwardConnector()
        {
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
            if (this.ConnectLogic.IsTrue() || this.ConnectLogic.Count == 0)
                this._target.Invoke(context);
        }

        public void AddConditionLogic(string leftOperator, string rightOperator, Operator operat)
        {
            //this.ConnectLogic.Add(new Condition() { LeftOperant = leftOperator,RightOperant = rightOperator, Operate = operat });
        }
    }
}
