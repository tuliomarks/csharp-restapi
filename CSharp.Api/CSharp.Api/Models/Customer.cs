using System.Collections.Generic;

namespace CSharp.Api.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public IEnumerable<Order> Orders { get; set; }
        
    }
}
