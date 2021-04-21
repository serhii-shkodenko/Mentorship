using System;
using System.Collections.Generic;

namespace Lecture3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IEnumerable<TestClass> PerfomeSomeAction(IEnumerable<TestClassAnother> collection)
        {
            var list = new List<TestClass>();

            foreach (var item in collection)
            {
                var newItem = new TestClass
                {
                    TestClassName = "Na",
                };

                list.Add(newItem);
            }

            return list;
        }
    }

    public class TestClass
    {
        public string TestClassName { get; set; }
    }

    public class TestClassAnother
    {
        public string TestClassAnotherName { get; set; }

        public IList<string> Collection { get; set; }

        public TestClassAnother()
        {
            Collection = new List<string>();
        }
    }
}