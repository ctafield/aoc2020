using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aoc2020
{
    public abstract class AocBase
    {
        protected IEnumerable<T> LoadInput<T>(string fileName)
        {
            return System.IO.File.ReadAllLines(fileName).Select(s => (T)Convert.ChangeType(s, typeof(T)));
        }

        protected IEnumerable<T> ParseInput<T>(IEnumerable<string> input, Func<string, T> factory)
        {
            var results = new List<T>();
            var result = new StringBuilder();

            foreach (var row in input)
            {
                if (!string.IsNullOrWhiteSpace(row))
                {
                    result.Append(row + " ");
                }
                else
                {
                    results.Add(factory(result.ToString()));
                    result = new StringBuilder();
                }
            }

            results.Add(factory(current.ToString()));

            return results;
        }             
    }
}