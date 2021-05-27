using System;
using System.Threading;

namespace Lecture10
{
    public class RaceConditionsWithLocks
    {
        private static object _lock = new object(); // this vs "this"

        public static void MakeOrders(int itemsToOrder)
        {
            for (var i = 0; i < itemsToOrder; i++)
            {
                lock(_lock) // syntaxic sugar. Show the Sharplab.io
                {
                    OrdersWithLock.OrdersCount += 1; // is a critical section;
                }

                Console.WriteLine($"{nameof(OrdersWithLock.OrdersCount)} is {OrdersWithLock.OrdersCount} in {Thread.CurrentThread.Name}");
            }
        }

        public static void MakeOrdersFromTwoThreads(int itemsToOrder)
        {
            var thread = new Thread(() => MakeOrders(itemsToOrder));
            thread.Name = "MyThread";
            thread.Start();

            MakeOrders(itemsToOrder);
        }

        public static class OrdersWithLock
        {
            public static int OrdersCount { get; set; }
        }
    }
}