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

        static void Part1(IEnumerable<int> values)
        {
            foreach (var v1 in values)
            {
                var v2 = values.FirstOrDefault(v => v + v1 == 2020);
                if (v2 != default(int))
                {
                    Console.WriteLine($"Day 1 part 1 = {v1 * v2}");
                    return;
                }
            }
        }

        static void Part2(IEnumerable<int> values)
        {
            foreach (var v1 in values)
            {
                foreach (var v2 in values)
                {
                    var v3 = values.FirstOrDefault(v => v + v1 + v2 == 2020);
                    if (v3 != default(int))
                    {
                        if (v1 + v2 + v3 == 2020)
                        {
                            Console.WriteLine($"Day 1 part 2 = {v1}*{v2}*{v3}={v1 * v2 * v3}");
                            return;
                        }
                    }
                }
            }            
        }        

        static void Main(string[] args)
        {
            var values = LoadInput<int>(@"input\day1.txt");
            Part1(values);
            Part2(values);
        }
    }
}
