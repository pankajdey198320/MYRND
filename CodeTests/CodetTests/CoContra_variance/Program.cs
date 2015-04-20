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
            IPersonService<Person> service = sP; 
            var result = service.GetFirst();
            Console.WriteLine(result.Name);

            var x = new ZService<Person>();
            x.Add(new Person() { Name = "pankaj" });
            IContraService<Student> xS = x;
            xS.Add(new Student() {  Address="asda", Name="dasdas" });

            Repository<Person> _pRepo = new Repository<Person>();
            _pRepo.Add(new Student() { ID = 1, Address = "banipur", Name = "pankaj", RoleNo = 120 });
            _pRepo.Add(new Student() { ID = 1, Address = "c", Name = "Rh", RoleNo = 20 });
            _pRepo.Add(new Student() { ID = 1, Address = "a", Name = "Ah", RoleNo = 21 });
            _pRepo.Add(new Student() { ID = 1, Address = "b", Name = "BH", RoleNo = 202});

            var rep= _pRepo.Get(p => p.Address == "a").FirstOrDefault();
        }
    }
}
