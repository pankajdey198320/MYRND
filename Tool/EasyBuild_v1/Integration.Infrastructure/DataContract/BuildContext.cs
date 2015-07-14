using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Infrastructure.DataContract
{
    public class BuildContext
    {
        public class BuilConfiguration {
            public enum BuildConfigurationType {
                GlobalProperties,BuildProperties
            }
            public string Value { get; set; }
            public string Key { get; set; }
            public BuildConfigurationType Type { get; set; }

        }
        public List<BuilConfiguration> BuildProperties { get; set; }
        public string SourceLocation { get; set; }

    }
}
