using Lecture13.Models;
using System.Collections.Generic;

namespace Lecture13.Interfaces
{
    public interface IStorage
    {
        ICollection<User> Users { get; set; }
    }
}