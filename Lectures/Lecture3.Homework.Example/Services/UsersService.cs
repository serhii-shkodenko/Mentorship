using Lecture3.Homework.Example.Contracts;
using Lecture3.Homework.Example.Models;
using System;

namespace Lecture3.Homework.Example.Services
{
    public class UsersService : IUsersService
    {
        private readonly IStoreContext _storeContext;

        public UsersService(IStoreContext storeContext)
        {
            _storeContext = storeContext ?? throw new ArgumentNullException(nameof(storeContext));
        }

        public bool Create(User user)
        {
            throw new NotImplementedException();
        }
    }
}