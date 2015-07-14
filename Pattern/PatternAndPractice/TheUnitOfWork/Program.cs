using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUnitOfWork
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    #region Entity

    public class Entity
    {
        public Guid Key { get; set; }
        public bool IsChanged { get; set; }
        public bool IsDirty { get; set; }
    }

    public class Employee : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    #endregion

    #region Repository

    public class BaseRepository<T> : IList<T> where T : Entity
    {
        public T GetByKey(Guid key)
        {
            return this.FirstOrDefault(p => p.Key == key);
        }

        public IEnumerable<T> GetAll() {
            return this;
        }

        public void Add(T entity)
        {
            this.Add(entity);
        }

        public void Update(T entity)
        {
            var vObj = this.FirstOrDefault(p => p.Key == entity.Key);
            if (vObj != null)
            {
                vObj = entity;
                vObj.IsChanged = true;
            }
        }

        public void Delete(T entity) {
            var vObj = this.FirstOrDefault(p => p.Key == entity.Key);
            if (vObj != null)
            {
                this.Delete(vObj);
            }
        }
        public IQueryable<T> All {
            get {
                return this.AsQueryable();
            }
        }
    }

    #endregion
}
