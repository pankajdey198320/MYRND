using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Infrastructure.DataContract
{
    public class SourceContext
    {
        public class Credential {
            public string UseName { get; set; }
            public string Domain { get; set; }
            public SecureString Password { get; set; }
        }
        public string URL { get; set; }
        public int MyProperty { get; set; }
        public Credential UserCredential { get; set; }
    }
}
