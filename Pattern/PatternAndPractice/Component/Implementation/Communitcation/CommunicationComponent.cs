using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component.Interface;
using Component.MessageContext;

namespace Component.Implementation
{
    public class CommunicationComponentBase:BaseComponent<IMessageContext>
    {
        public CommunicationComponentType Type { get; set; }
        public MimeType MimeType { get; set; }
        public char EndChar { get; set; }
        public override void SartComponent(IMessageContext obj)
        {
            this.EndChar = '\n';
            
        }
    }
    
    public enum CommunicationComponentType { 
        Input,Output,BiDiractional,InToOut,OutToIn
    }

  
}
