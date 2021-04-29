using System;
using System.Text;

namespace Lecture5
{
    public class Interning
    {
        public string CheckReferences()
        {
            var sameString = ".net";
            var sameString2 = ".NET";

            return GetEqualityResult(nameof(CheckReferences), sameString, sameString2);
        }

        public string CheckReferencesSB()
        {
            var sameString = ".NET";
            var sameString2 = new StringBuilder().Append(".").Append("NET").ToString();

            return GetEqualityResult(nameof(CheckReferencesSB), sameString, sameString2);
        }

        public string CheckReferencesSBIntern()
        {
            var sameString = ".NET";
            var sameString2 = string.Intern(new StringBuilder().Append(".").Append("NET").ToString());

            return GetEqualityResult(nameof(CheckReferencesSBIntern), sameString, sameString2);
        }

        public string CheckReferencesConcatenate()
        {
            var sameString = ".NET";
            var sameString2 = "." + "N" + "E" + "T";

            return GetEqualityResult(nameof(CheckReferencesConcatenate), sameString, sameString2);
        }

        public string GetEqualityResult(string methodName, string one, string two)
        {
            var equality = one.Equals(two, StringComparison.Ordinal);
            var refEquality = ReferenceEquals(one, two);

            var result = one == two;

            return $"{methodName.ToUpper()}{Environment.NewLine}{nameof(equality)}: {equality}{Environment.NewLine}{nameof(refEquality)}: {refEquality} {Environment.NewLine}";
        }


    }
}