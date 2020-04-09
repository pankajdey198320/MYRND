using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component.Interface;
using Component.MessageContext;
using Component.Implementation.BaseImplementation;

namespace Component.Implementation
{
    public class CommunicationComponentBase:BaseComponent<IMessageContext>
    {
        public CommunicationComponentBase()
        {
           // Properties = new CommunicationProperties();
        }

        public CommunicationComponentBase(List<IConnector> connectors):base(connectors)
        {
          //  Properties = new CommunicationProperties();
        }
        public CommunicationComponentType Type { get; set; }
        public MimeType MimeType { get; set; }
        public char EndChar { get; set; }
        public override void SartComponent(IMessageContext obj)
        {
            this.EndChar = '\n';
            base.SartComponent(obj);
        }
    }
    
    public enum CommunicationComponentType { 
        Input,Output,BiDiractional,InToOut,OutToIn
    }

    public class CommunicationProperties : BaseProperties
    {
        public CommunicationProperties():base()
        {
            Add("IpAddress", "127.0.0.1");
            Add("Port", "3838");
        }
    }

}
