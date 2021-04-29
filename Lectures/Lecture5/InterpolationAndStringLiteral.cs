using System;
using System.Globalization;

namespace Lecture5
{
    public class InterpolationAndStringLiteral
    {
        public string CreateStringFromChars()
        {
            //return new string(new[] { '1', '2' });

            var collection = "abc";
            foreach (var item in collection)
            {
            }

            return string.Empty;
        }

        public void Compare()
        {
            var net = ".NET";
            var result = string.Compare(net, "T");
            Console.WriteLine(result);
        }

        public void GetInterpolatedString()
        {
            int index = default;

            try
            {
                var result = 4 / index;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message is {ex.Message}.");
                Console.WriteLine($"Message is \"{ex.Message}\".");
            }
        }

        public void StringLiteral()
        {
            string filename1 = @"c:\documents\files\u0066.txt";
            string filename2 = "c:\\documents\\files\\u0066.txt";

            Console.WriteLine(filename1);
            Console.WriteLine(filename2);
        }

        public void FormatDate()
        {
            var now = DateTime.Now;

            var culture = new CultureInfo("pt-BR");
            var cultureFrance = new CultureInfo("fr-FR");
            var cultureUkraine = new CultureInfo("uk-UA");

            var stringToOut = string.Format(culture, "Today is {0:dddd} and Month is {1:MMM}.", now, now);
            var stringToOut2 = string.Format(cultureFrance, "Today is {0:dddd}.", now);
            var stringToOut3 = string.Format(cultureUkraine, "Today is {0:dddd}", now);

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(stringToOut);
            Console.WriteLine(stringToOut2);
            Console.WriteLine(stringToOut3);
        }
    }
}