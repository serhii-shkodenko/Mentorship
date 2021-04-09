using System;

namespace Lecture1
{
    public class StackHeap
    {
        private void TypesMemoryHandling(ref int valueParam, object referenceParam)
        {
            var someValueParam = 5;
            var someReferenceParam = "5";

            Console.WriteLine();
            Console.WriteLine("---Attempt to change the TestClass property value---");

            valueParam = int.MaxValue;
            referenceParam = Guid.NewGuid().ToString();

            Console.WriteLine(valueParam);
            Console.WriteLine(referenceParam);
        }

        private void TestClassMemoryHandling(TestClass entityToChange)
        {
            Console.WriteLine();
            Console.WriteLine("---Attempt to change the TestClass property value---");

            entityToChange.ValueToChange = int.MaxValue;

            Console.WriteLine(entityToChange.ValueToChange);
        }

        public void Run()
        {
            var originalValueParam = 1000;
            string originalReferenceParam = "1000";

            Console.WriteLine();
            Console.WriteLine("---Original values before the changing attempt---");
            Console.WriteLine(originalValueParam);
            Console.WriteLine(originalReferenceParam);

            TypesMemoryHandling(ref originalValueParam, originalReferenceParam);

            Console.WriteLine();
            Console.WriteLine("---Original values after the changing attempt---");
            Console.WriteLine(originalValueParam);
            Console.WriteLine(originalReferenceParam);
        }

        public void RunTestClass()
        {
            var objectToTest = new TestClass();
            objectToTest.ValueToChange = 5;

            Console.WriteLine();
            Console.WriteLine("---Original values before the changing attempt---");
            Console.WriteLine(objectToTest.ValueToChange);

            TestClassMemoryHandling(objectToTest);

            Console.WriteLine();
            Console.WriteLine("---Original values after the changing attempt---");
            Console.WriteLine(objectToTest.ValueToChange);

            //var valueToCheck = 5;

            //if (valueToCheck == 5)
            //{
            //    Console.WriteLine("Value is 5.");
            //}
            //else if (valueToCheck == 4)
            //{
            //    Console.WriteLine("Value is 4.");
            //}
            //else
            //{
            //    Console.WriteLine("Value is not 5 or 4.");
            //}

            //var result = valueToCheck == 5
            //    ? true
            //    : false;

            //int caseSwitch = 1;

            //var result2 = caseSwitch switch
            //{
            //    1 => "someString",
            //    2 => "someString2",
            //    _ => throw new NotImplementedException(),
            //};

            
        }

        public class TestClass
        {
            public int ValueToChange { get; set; }
        }
    }
}