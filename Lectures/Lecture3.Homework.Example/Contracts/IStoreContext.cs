using Lecture3.Homework.Example.Models;
using System.Collections.Generic;

namespace Lecture3.Homework.Example.Contracts
{
    public interface IStoreContext
    {
        ICollection<User> Users { get; set; }

        void DataInit();
    }
}