using System;
using System.Collections.Generic;

namespace Lecture13.Models
{
    public class Order
    {
        public Guid Id { get; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
        }
    }
}