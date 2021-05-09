using Lecture3.Homework.Example.Contracts;
using Lecture3.Homework.Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<User> GetAdultUsers()
        {
            return _storeContext.Users.Where(x => x.UserAgeType == UserAgeType.Adult);
        }



    }


}