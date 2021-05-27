using System;
using System.Threading;
using static System.Console;

namespace Lecture10
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ThreadSynchronizationExample();

            // General
            WriteLine(Environment.NewLine);
            WriteLine("All is done in Main thread!");
            ReadLine();
        }

        private static void RunTwoTreadsSimpleExample()
        {
            var simpleExamples = new WorkingWithThreads();
            simpleExamples.RunningTwoThreads();
        }

        private static void RunInBackgroundExample()
        {
            var simpleExamples = new WorkingWithThreads();
            simpleExamples.RunningInBackground();
        }

        private static void RunRaceConditionExample()
        {
            Thread.CurrentThread.Name = "Main";
            RaceConditions.MakeOrdersFromTwoThreads(5);

            WriteLine(RaceConditions.Orders.OrdersCount);
        }

        private static void RunRaceConditionWithLockExample()
        {
            Thread.CurrentThread.Name = "Main";
            RaceConditionsWithLocks.MakeOrdersFromTwoThreads(10);
            WriteLine(RaceConditionsWithLocks.OrdersWithLock.OrdersCount);
        }

        private static void ThreadSynchronizationExample()
        {
            Thread.CurrentThread.Name = "Main";
            ThreadSynchronizationWithAutoResetEvent.CreateConsumers();
            ThreadSynchronizationWithAutoResetEvent.StartProducing();

        }
    }
}