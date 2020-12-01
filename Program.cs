using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class Program
    {
        private static IEnumerable<T> LoadInput<T>(string fileName)
        {
            return System.IO.File.ReadAllLines(fileName).Select(s => (T)Convert.ChangeType(s, typeof(T)));
        }

        static void Main(string[] args)
        {
            var values = LoadInput<int>(@"input\day1.txt");

            foreach (var v1 in values)
            {
                foreach (var v2 in values)
                {
                    if (v1 + v2 == 2020)
                    {
                        Console.WriteLine($"Day 1 part 1 = {v1}*{v2}={v1 * v2}");
                        break;
                    }
                }
            }

            foreach (var v1 in values)
            {
                foreach (var v2 in values)
                {
                    foreach (var v3 in values)
                    {
                        if (v1 + v2 + v3 == 2020)
                        {
                            Console.WriteLine($"Day 1 part 2 = {v1}*{v2}*{v3}={v1 * v2 * v3}");                            
                        }
                    }
                }
            }
        }
    }
}
