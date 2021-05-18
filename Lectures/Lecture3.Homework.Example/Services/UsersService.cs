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
        private readonly ILogger _logger;

        public UsersService(IStoreContext storeContext, ILogger logger)
        {
            _storeContext = storeContext ?? throw new ArgumentNullException(nameof(storeContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool Create(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAdultUsers()
        {
            var result = _storeContext.Users.Where(x => x.UserAgeType == UserAgeType.Adult);

            _logger.Log($"DateOfOperation: {DateTime.UtcNow}, Content: {result}");

            return result;
        }
    }
}