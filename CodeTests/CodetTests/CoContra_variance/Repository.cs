using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoContra_variance
{
    internal class Repository<T>
    {
        private List<T> _entities = new List<T>();
        public bool Add(T obj) {
            _entities.Add(obj);
            return true;
        }

        public bool Remove(T obj) {
            _entities.Remove(obj);
            return true;
        }

        public IQueryable<T> Get(Func<T,bool> query) {
           return _entities.Where(query).AsQueryable();
        }
    }
}
