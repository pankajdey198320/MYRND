using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoContra_variance
{
    class Program
    {
        static void Main(string[] args)
        {
          //  IEnumerable<Person> people = new List<Student>() { new Student(){ ID=1, Address="banipur", Name="pankaj", RoleNo =20 },
            //new Student(){ ID=2, Address="Ashoknagar", Name="Rahul", RoleNo =21 }};

            var sP=new PersonService<Student>();
            sP.Fill(new List<Student>() { new Student(){ ID=1, Address="banipur", Name="pankaj", RoleNo =20 },
            new Student(){ ID=2, Address="Ashoknagar", Name="Rahul", RoleNo =21 }});
            IPersonService<Person> service = sP; ;
            var result = service.GetFirst();
            Console.WriteLine(result.Name);
        }
    }
}
