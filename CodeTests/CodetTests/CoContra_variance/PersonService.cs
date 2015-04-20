using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoContra_variance
{
    interface IPersonService<out T> {
        T GetFirst();
       // void Fill(IEnumerable<T> values);
    }
    class PersonService<T> : IPersonService<T>
    {
        
        List<T> _listT = new List<T>();
        public T GetFirst()
        {
            return _listT.FirstOrDefault();
        }

        public void Fill(IEnumerable<T> values)
        {
            _listT.AddRange(values);
        }

        
    }

    interface IContraService<in T> {
        void Add(T obj);
    }


    class ZService<T> : IContraService<T> {
        List<T> _sv = new List<T>();
        public void Add(T obj)
        {
            _sv.Add(obj);
            Console.WriteLine("Bingo");
        }
    }
}
