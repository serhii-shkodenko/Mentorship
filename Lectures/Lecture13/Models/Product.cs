using System;

namespace Lecture13.Models
{
    public class Product
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
        }
    }
}