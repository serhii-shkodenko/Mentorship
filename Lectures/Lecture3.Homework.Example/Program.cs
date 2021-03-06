using Lecture3.Homework.Example.Contracts;
using Lecture3.Homework.Example.Data;
using Lecture3.Homework.Example.Models;
using Lecture3.Homework.Example.Services;
using Lecture3.Homework.Example.UI;
using System;
using static Lecture3.Homework.Example.Services.Logger;

namespace Lecture3.Homework.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ImplementationsContainer();

            container.Set<IStoreContext>(new StoreContext());
            container.Set<ILogger>(new Logger());
            container.Set<IUsersService>(new UsersService(container.Get<IStoreContext>(), container.Get<ILogger>()));

            var result = container.Get<IUsersService>();

            var store = new StoreContext();
            var options = new LoggerOptions
            {
                FileNameToSaveContent = "whereToSave.txt"
            };

            var logger = new Logger(options);
            //store.DataInit();

            var userService = new UsersService(store, logger);

            var presenter = new Presenter();
            presenter.Start();

        }
    }
}
