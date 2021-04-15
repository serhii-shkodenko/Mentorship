using System;

namespace Lecture2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var product = new ProductRecord(20);
            var productAnother = new ProductRecord(20);
            Console.WriteLine(product.Equals(productAnother));

            object unknownPerson = new Person();
            ((Person)unknownPerson).CreatePerson(20);

            var realPerson = unknownPerson as Person;
            if (realPerson is not null)
            {
            }

            if (unknownPerson is Person personReal)
            {
                personReal.CreatePerson(20);
            }

            Console.ReadLine();
        }

        public record ProductRecord(int Id);
    }
}