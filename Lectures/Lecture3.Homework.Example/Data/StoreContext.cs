using Lecture3.Homework.Example.Contracts;
using Lecture3.Homework.Example.Models;
using System;
using System.Collections.Generic;

namespace Lecture3.Homework.Example.Data
{
    public class StoreContext : IStoreContext
    {
        public ICollection<User> Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void DataInit()
        {
            throw new NotImplementedException();
        }
    }
}