using Lecture13.Extensions;
using Lecture13.Interfaces;
using Lecture13.Models;
using System;
using System.Linq;

namespace Lecture13.Services
{
    public class UserService
    {
        private readonly IStorage _storage;

        public UserService(IStorage storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public Product GetPurchasedProduct(Guid userId, Guid productId)
        {
            // Lazy executing.

            var slow = _storage.Users.FirstOrDefault(x => x.Id == userId);
            var fast = _storage.Users.Where(x => x.Id == userId).FirstOrDefault();


            var products = _storage.Users.FirstOrDefault(x => x.Id == userId)?.Orders
                                         .SelectMany(x => x.Products)
                                         .Where(x => x.Name.Length > 3)
                                         .Distinct();

            return products?.FirstOrDefault(x => x.Id == productId);
        }

        public string GetPurchasedProductAndChangeName(Guid userId, Guid productId, Func<string, string, string> changeName)
        {
            var changedName = _storage.Users.FirstOrDefault(x => x.Id == userId)?.Orders
                                         .SelectMany(x => x.Products)
                                         .Select(x =>
                                         {
                                             var boundedFunc = changeName.DoActionOverOneArg(x.Description);
                                             return boundedFunc(x.Name);
                                         })
                                         .Distinct();

            return changedName.FirstOrDefault();
        }
    }
}