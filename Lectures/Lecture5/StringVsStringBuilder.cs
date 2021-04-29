using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture5
{
    public class StringVsStringBuilder
    {
        private IEnumerable<string> PrepareStringsForMemoryTests(int iterations)
        {
            List<string> result = new();

            for (var i = 0; i < iterations; i++)
            {
                result.Add(Guid.NewGuid().ToString());
            }

            return result;
        }

        private string GetConcatenatedByStringConcatenating(IEnumerable<string> collection)
        {
            string result = default;

            {
                foreach (var item in collection)
                {
                    result += item;
                }
            }

            return result;
        }

        private string GetConcatenatedByStringBuilder(IEnumerable<string> collection)
        {
            var sb = new StringBuilder();

            {
                foreach (var item in collection)
                {
                    sb.Append(item);
                }
            }

            return sb.ToString();
        }

        private string GetConcatenatedByStringBuilder(IEnumerable<string> collection, int length)
        {
            var sb = new StringBuilder(length);

            {
                foreach (var item in collection)
                {
                    sb.Append(item);
                }
            }

            return sb.ToString();
        }
    }
}