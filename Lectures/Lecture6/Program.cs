using System;

namespace Lecture6
{
    public class Program
    {
        public static Logger Logger;

        private static void Main(string[] args)
        {
            Run();
            Console.ReadLine();
        }

        private static void Run()
        {
            using var logger = new Logger("logfile.txt");

            //// Do your application stuff here ...
            //logger.ToString();

            //var logger2 = new Logger("logfile.txt");
            //logger2.ToString();

            ////GC.WaitForPendingFinalizers();
            //GC.Collect();

            //Logger = new Logger("logfile.txt");

            var derivedWriter = new DerivedWriter();

            var adult = new User
            {
                Age = 20,
            };

            if(derivedWriter.TryGetName(adult, out var result))
            {
                Console.WriteLine(result);
            }

            var child = new User
            {
                Age = 10,
            };

            if (!derivedWriter.TryGetName(child, out var resultAnother))
            {
                Console.WriteLine(resultAnother);
            }

            Console.ReadLine();
        }
    }
}