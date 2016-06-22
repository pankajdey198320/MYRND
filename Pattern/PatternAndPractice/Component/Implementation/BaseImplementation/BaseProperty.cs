using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Component.Implementation.BaseImplementation
{
    public class BaseProperties : Dictionary<string, string>
    {
        public BaseProperties()
        {

            var c = JsonConvert.DeserializeObject<Dictionary<string,string>>(System.IO.File.ReadAllText(@"C:\Projects\me\MyRND\Pattern\PatternAndPractice\ConsoleTest\BasicProperties.json"));
            foreach (var i in c)
            {
                Add(i.Key,i.Value);
            }
        }
    }
}
