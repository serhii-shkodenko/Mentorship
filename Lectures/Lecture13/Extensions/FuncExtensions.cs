using System;

namespace Lecture13.Extensions
{
    public static class FuncExtensions
    {
        // Curring
        public static Func<string, string> DoActionOverOneArg(this Func<string, string, string> changeName, string valueToBeSubstitution)
        {
            return (unchangedValue) => changeName(unchangedValue, valueToBeSubstitution);
        }
    }
}