using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoContra_variance
{
    class Person
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    class Student:Person
    {
        public int RoleNo { get; set; }
    }
}
