using System;
using System.Collections.Generic;

namespace Albelli.Data.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] Timestamp { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
