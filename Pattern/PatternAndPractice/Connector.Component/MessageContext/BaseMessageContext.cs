using System;
using Component.Interface;

namespace Component.MessageContext
{
    public class BaseMessageContext:IMessageContext
    {
        private string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        public string ID { get; set ; }

        public BaseMessageContext()
        {
            _Message = string.Empty;
            ID = Guid.NewGuid().ToString();
        }
        public string GetPropertyvalye(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
