using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component.Interface;

namespace Component
{
    public abstract class BaseComponent<T> : IComponent<T> where T : IMessageContext
    {
        public BaseComponent()
        {
            this.Connectors = new List<IConnector>();
        }

        public virtual T MesageContext { get; set; }
        public List<IConnector> Connectors { get; set; }

        public virtual void AddNextCompExecutionPoint(IConnector connector)
        {
            this.Connectors.Add(connector);
            //_nextExecutionPoint = entryPoint;
        }

        public bool InvokeNextComponent(T obj)
        {
            foreach (var connector in this.Connectors)
            {
                connector.InvokeTarget(obj);
            }
            return true;
        }

        public abstract void SartComponent(T obj);
    }
}
