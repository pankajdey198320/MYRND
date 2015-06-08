using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoadAssambly
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFile(@"Z:\MyProjects\MYRND\Pattern\PatternAndPractice\FactoryMethod\bin\Debug\FactoryMethod.exe");

        }
    }

    abstract class a { }
    interface b { }
    class su : a,b
    { }
}
