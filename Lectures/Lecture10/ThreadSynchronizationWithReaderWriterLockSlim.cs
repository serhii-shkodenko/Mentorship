//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Lecture10
//{
//    public class ThreadSynchronizationWithReaderWriterLockSlim
//    {
//        private Queue<Order> _orders = new Queue<Order>();

//        public static IList<Thread> Consumers { get; set; } = new List<Thread>();

//        private static readonly object _ordersLock = new object();

//        private static EventWaitHandle _orderAdded = new AutoResetEvent(false);

//        public static void AddOrder(Order order)
//        {
//            lock (_ordersLock)
//            {
//                order.Description += $"Added by {Thread.CurrentThread.Name}. ";
//                _orders.Enqueue(order);
//            }

//            _orderAdded.Set();
//        }

//        public static void DeliverOrder()
//        {
//            while (true)
//            {
//                Order order = default;
//                lock (_ordersLock)
//                {
//                    if (_orders.Count > 0)
//                    {
//                        order = _orders.Dequeue();
//                    }
//                }

//                if (order is not null)
//                {
//                    order.Description += $"Delivered by {Thread.CurrentThread.Name}";
//                    Console.WriteLine(order.Description);
//                }
//                else
//                {
//                    _orderAdded.WaitOne();
//                }
//            }
//        }

//        public static void CreateConsumers()
//        {
//            for (var i = 0; i < 3; i++)
//            {
//                var thread = new Thread(DeliverOrder);
//                thread.Name = $"Thread{i}";
//                Consumers.Add(thread);
//            }

//            foreach (var thread in Consumers)
//            {
//                thread.Start();
//            }
//        }

//        public static void StartProducing()
//        {
//            var producer = new Thread(() =>
//            {
//                while (true)
//                {
//                    var newOrder = new Order();
//                    AddOrder(newOrder);
//                    Thread.Sleep(300);
//                }
//            });

//            producer.Name = "Producer";
//            producer.Start();
//        }
//    }

//    public class Order
//    {
//        public string Description { get; set; }
//    }
//}
//}
