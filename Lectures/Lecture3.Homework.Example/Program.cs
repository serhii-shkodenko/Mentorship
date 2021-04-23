using Lecture3.Homework.Example.Contracts;
using Lecture3.Homework.Example.Data;
using Lecture3.Homework.Example.Models;
using Lecture3.Homework.Example.Services;
using Lecture3.Homework.Example.UI;
using System;

namespace Lecture3.Homework.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ImplementationsContainer();

            container.Set<IStoreContext>(new StoreContext());
            container.Set<IUsersService>(new UsersService(container.Get<IStoreContext>()));

            var result = container.Get<IUsersService>();

            var store = new StoreContext();
            //store.DataInit();

            var userService = new UsersService(store);

            var presenter = new Presenter();
            presenter.Start();

        }
    }
}
