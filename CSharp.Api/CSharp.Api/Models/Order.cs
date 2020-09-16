using System;

namespace CSharp.Api.Models
{
    public class Order
    {
        public long Id { get; set; }

        public long CustomerId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public Customer Customer { get; set; }
    }
}
