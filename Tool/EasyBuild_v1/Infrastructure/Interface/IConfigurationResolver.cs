using System.Collections;
using System.Collections.Generic;

namespace Infrastructure.Interface
{
    public interface IConfigurationResolver<T> where T : class
    {
        IEnumerable<T> GetConfiguration();
    }
}
