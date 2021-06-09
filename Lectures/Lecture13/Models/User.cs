using System;
using System.Collections.Generic;

namespace Lecture13.Models
{
    public class User
    {
        public Guid Id { get; }

        public IEnumerable<Order> Orders { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }
    }
}