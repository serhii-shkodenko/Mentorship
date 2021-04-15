using System;

namespace Lecture2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var product = new ProductRecord(20);
            var productAnother = new ProductRecord(20);

            object unknownPerson = new Person();
            ((Person)unknownPerson).CreatePerson(20);

            var realPerson = unknownPerson as Person;
            if(realPerson is not null)
            {

            }

            if(unknownPerson is Person personReal)
            {
                personReal.CreatePerson(20);
            }


            Console.WriteLine(product.Equals(productAnother));

            Console.ReadLine();
        }

        //public class Man : Human
        //{
        //    private string _name;

        //    static string StaticValue { get; set; }

        //    static Man()
        //    {
        //        StaticValue = "ldjfhslkdj";
        //    }

        //    public Man(string gender) : base(gender)
        //    {
        //    }

        //    public string Name
        //    {
        //        get => _name;
        //        set
        //        {
        //            _name = value;
        //        }
        //    }
        //}

        //public class Human
        //{
        //    public string Gender { get; set; }

        //    public Human(string gender)
        //    {
        //    }
        //}

        //public struct ManStruct
        //{
        //    public int Value { get; set; }

        //    public int Value2 { get; set; }

        //    public ManStruct(int value)
        //    {
        //        Value = value;
        //    }
        //}

        //[Flags]
        //public enum Gender
        //{

        //}

        public record ProductRecord(int Id);
    }
}