using System;

namespace Lecture1
{
    public class Boxing
    {
        private void Demonstrate(object parameter)
        {
            var value = parameter.ToString();
        }

        public void Invoker()
        {
            Demonstrate(5);
            Demonstrate("5");
        }

        public void DoSomething(string someValue)
        {
            if(someValue is null)
            {

            }

            var result = someValue ?? throw new System.Exception();

            var collectionItems = new[]
            {
                1,
                2
            };

            for(var i= 0; i< collectionItems.Length; i++)
            {
                var item = collectionItems[i];

                if (item ==3)
                {
                    continue;
                }
            }

            foreach (var item in collectionItems ?? Array.Empty<int>())
            {

            }

            var objectToTest = new TestClassName();

            var resultOne = objectToTest.ClassValue?.Name;
        }

        public class TestClassName
        {
            public InnerClass ClassValue { get; set; }
        }

        public class InnerClass
        {
            public string Name { get; set; }
        }
    }
}