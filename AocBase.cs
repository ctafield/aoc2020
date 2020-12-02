using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    public class AocBase
    {
        protected IEnumerable<T> LoadInput<T>(string fileName)
        {
            return System.IO.File.ReadAllLines(fileName).Select(s => (T)Convert.ChangeType(s, typeof(T)));
        }
    }
}