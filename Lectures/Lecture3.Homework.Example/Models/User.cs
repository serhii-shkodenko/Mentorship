using System.Collections.Generic;

namespace Lecture3.Homework.Example.Models
{
    public class User
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }

    public class Basket
    {
        public ICollection<Order> Orders { get; set; }

        public User User { get; set; }
    }
}