using System;
using System.Text.RegularExpressions;

namespace Lecture5
{
    public class RegularExpressions
    {
        public void PrintIsMatch()
        {
            var pattern = @"\+\d{3}\(\d{2}\)\d{3}\s\d{2}\s\d{2}";
            var stringMatch = "+380(95)222 55 88";

            var expression = new Regex(pattern, RegexOptions.Compiled);
            var isMatch = expression.IsMatch(stringMatch);

            Console.WriteLine(isMatch);
        }
    }
}