using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component.Interface;

namespace Component.Implementation.Common
{

    public enum Operator
    {
        GreterThen, LessThen, Equal, GreterThenEqual, LessThenEqual, NotEqual
    }

    public enum OperantType{
        Property,GlobalValue,FieldValue
    }
    public class Operant<T> {
        public Operant()
        {

        }
        private IOperantValueResolver<T> _resolver;
        private OperantType _type;
        public string Name { get; set; }
        public OperantType Type { get { return _type; } set {
            _type = value;
            if (_type == OperantType.Property)
            {
                _resolver = new MessagePropertyValueResolver<T>();
            }
        } }
        public T Value { get {
            return _resolver.GetValue(Name);
        } }
    }

    public interface IOperantValueResolver<T>
    {
        T GetValue( string name);
    }

    public class MessagePropertyValueResolver<T> : IOperantValueResolver<T> {
        public IMessageContext Context { get; set; }
        
        public T GetValue(string name)
        {
            return (T)Convert.ChangeType(Context.GetPropertyvalye(name), typeof(T));
        }
    }

    public class Condition
    {

        public Operant<string> LeftOperant { get; set; }
        public string RightOperant { get; set; }
        public Operator Operate { get; set; }
        public bool Check()
        {
            switch (this.Operate)
            {
                case Operator.Equal:
                    {
                        return LeftOperant.Equals(RightOperant);
                    }
                case Operator.NotEqual:
                    {
                        break;
                    }
                case Operator.GreterThen:
                    {
                        break;
                    }
                case Operator.GreterThenEqual:
                    {
                        break;
                    }
                case Operator.LessThen:
                    {
                        break;
                    }
                case Operator.LessThenEqual:
                    {
                        break;
                    }
            }
            return false;
        }

    }

    public class Conditions : List<Condition>
    {

        public bool IsTrue()
        {
            foreach (var c in this)
            {
                if (!c.Check())
                    return false;
            }
            return true;
        }
    }
}
