using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component.Implementation.Common;

namespace Component.Interface
{
    public interface IConnector
    {
        void SetTarget(Action<IMessageContext> target);
        void InvokeTarget(IMessageContext context);
        void AddConditionLogic(string leftOperator, string rightOperator, Operator operat);
        ComponentConfiguration ComponentConfig { get; set; }
        IList<IComponent<IMessageContext>> NextComponents { get;  set; }

    }
}
