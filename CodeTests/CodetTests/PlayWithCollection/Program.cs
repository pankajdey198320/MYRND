using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> emplist = new List<Employee>();
            
            Employee emp = new Employee() { Id=1};
            emplist.Add(emp);//Employee emp2 = emp.Clone();
            emplist.Add(new Employee() { Id = 3 });
            List<Employee> pList = emplist;
            pList[0].Id = 9;
            emp.Paint();
        }
    }

    public abstract class Person
    { 
         internal abstract void doPrint();
    }

    public class BaseEmployee : Person
    {
        public void Paint()
        {
            Console.WriteLine("base print");
        }

        internal override void doPrint()
        {
            Console.WriteLine("do print from basee");
        }
    }
    public class Employee:BaseEmployee
    {
        public int Id { get; set; }
        public new void Paint()
        {
            base.doPrint();
            Console.WriteLine("Child Paint");
        }
        public Employee Clone() {
            return base.MemberwiseClone() as Employee;
        }

    }
}
