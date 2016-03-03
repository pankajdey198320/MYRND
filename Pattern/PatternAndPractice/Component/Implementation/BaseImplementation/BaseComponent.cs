using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component.Interface;
using Component.Implementation.BaseImplementation;

namespace Component
{
    public abstract class BaseComponent<T> : IComponent<T> where T : IMessageContext
    {
        public BaseComponent( )
        {
            this.Connectors = new List<IConnector>();
            this.Properties = new Dictionary<string, string>();
            this.IsStart = this.IsEnd = false;
        }
        public BaseComponent(List<IConnector> connectors)
        {
            this.Connectors = connectors;
            this.Properties = new Dictionary<string, string>();
            this.IsStart = this.IsEnd = false;
        }

        public BaseComponent(IDictionary<string, string> properties, List<IConnector> connectors) : this(connectors)
        {
            Properties = properties;
        }

        public virtual T MesageContext { get; set; }
        public List<IConnector> Connectors { get; set; }


        public IDictionary<string, string> Properties
        {
            get; set;
        }

        public virtual bool IsStart
        {
            get; set;
        }

        public virtual bool IsEnd
        {
            get; set;
        }

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

        public virtual void SartComponent(T obj) {

            this.InvokeNextComponent(obj);
        }
    }
}
