using System;

namespace Lecture5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var tester2 = new InterpolationAndStringLiteral();
            //tester2.Compare();
            //Console.ReadLine();


            // Interning
            {
                //var tester = new Interning();
                //Console.WriteLine(tester.CheckReferencesConcatenate());
                //Console.WriteLine(tester.CheckReferencesSB());
                //Console.WriteLine(tester.CheckReferencesConcatenate());
                //Console.WriteLine(tester.CheckReferencesSBIntern());
            }

            // Regular expressions
            {
                var tester3 = new RegularExpressions();
                tester3.PrintIsMatch();

                //Console.ReadLine();
            }


            //var guid = Guid.NewGuid();

            ////var result = DateTime.Parse("");

            //string param = string.Empty;

            //var one = "One";
            //var two = "Two";
            //var result = one;

            //foreach

            //Console.WriteLine(param);
        }
    }
}