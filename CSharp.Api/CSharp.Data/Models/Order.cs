using System;
using System.Collections.Generic;

namespace Albelli.Data.Models
{
    public partial class Order
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte[] Timestamp { get; set; }
        public bool Deleted { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
