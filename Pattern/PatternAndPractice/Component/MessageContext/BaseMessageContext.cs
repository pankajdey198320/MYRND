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

        public BaseMessageContext()
        {
            _Message = string.Empty;
        }
        public string GetPropertyvalye(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
