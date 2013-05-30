using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CORS
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public static IEnumerable<Customer> GetSampleData()
        {
            yield return new Customer { Name = "Bob", Email = "bob@example.com" };
            yield return new Customer { Name = "Mark", Email = "mark@example.com" };
            yield return new Customer { Name = "John", Email = "john@example.com" };
        }
    }
}