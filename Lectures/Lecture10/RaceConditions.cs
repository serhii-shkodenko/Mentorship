using System;
using System.Threading;

namespace Lecture10
{
    public static class RaceConditions
    {
        public static Orders Orders { get; set; } = new Orders();

        public static void MakeOrders(int itemsToOrder)
        {
            for (var i = 0; i < itemsToOrder; i++)
            {
                Orders.OrdersCount += 1;

                Console.WriteLine($"{nameof(Orders.OrdersCount)} is {Orders.OrdersCount} in {Thread.CurrentThread.Name}");
            }
        }

        public static void MakeOrdersFromTwoThreads(int itemsToOrder)
        {
            var thread = new Thread(() => MakeOrders(itemsToOrder));
            thread.Name = "MyThread";
            thread.Start();
            thread.Join();

            MakeOrders(itemsToOrder);
        }
    }

    public class Orders
    {
        public int OrdersCount { get; set; }
    }
}