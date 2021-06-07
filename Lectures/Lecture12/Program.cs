using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lecture12
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            await foreach (var item in GetInt(3))
            {
                Console.WriteLine(item);
            }
        }

        public static async IAsyncEnumerable<int> GetInt(int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return i;
            }
        }

        public class BaseService
        {
            public virtual Task<TaskScheduler> GetContext()
            {
                return Task.FromResult(TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        public class DerivedService : BaseService
        {
            public sealed override Task<TaskScheduler> GetContext()
            {
                return Task.FromResult(TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
    }
}