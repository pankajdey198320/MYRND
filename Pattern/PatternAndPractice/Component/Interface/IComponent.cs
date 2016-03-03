using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component.Interface;

namespace Component
{
    public interface IComponent<T> where T : IMessageContext
    {
        void AddNextCompExecutionPoint(IConnector connector);
        bool InvokeNextComponent(T obj);
        void SartComponent(T obj);
        IDictionary<string,string> Properties { get; set; }
        bool IsStart { get; set; }
        bool IsEnd { get; set; }
    }
   
}
