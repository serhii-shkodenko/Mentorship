#nullable enable

using System;
using System.Threading;

namespace Lecture10
{
    public class WorkingWithThreads
    {
        public void JustALoop(string threadDesignator)
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"Iteration {i} completed in {threadDesignator}. Real thread is {Thread.CurrentThread.Name}");
            }

            Console.ReadLine(); // No effect for IsBackground = true.
        }

        public void JustALoop()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"Iteration {i}. Real thread is {Thread.CurrentThread.Name}");
            }

            Console.ReadLine(); // No effect for IsBackground = true.
        }

        public void RunningTwoThreads()
        {
            var thread = new Thread(()=> JustALoop("NewThread")); //() => JustALoop("NewThread")
            thread.Name = "MyNewThread"; // Only once. Exception for second attempt.
            thread.Start();

            JustALoop("MainThread");
        } // Thread will be ended after that automatically and can not be restarted.

        public void RunningInBackground()
        {
            var thread = new Thread(() => JustALoop("NewThread"));
            thread.Name = "MyNewThread"; // Only once. Exception for second attempt.

            // Background threads are identical to foreground threads with one exception:
            // a background thread does not keep the managed execution environment running.

            //thread.IsBackground = true;
            thread.Start();
        } // Thread will be ended after that automatically and can not be restarted.
    }
}