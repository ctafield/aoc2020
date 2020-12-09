using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    public class Day9 : AocBase
    {
        public Day9()
        {
            Console.WriteLine("Day 9");

            Console.WriteLine("Part 1");

            const int preamble = 25;

            var input = LoadInput<ulong>(@"input\day9.txt");
            var value = Part1(input, preamble);

            if (value == null)
            {
                Console.WriteLine("something went wrong.");
                return;
            }

            Part2(input, value.Value);
        }

        private void Part2(IEnumerable<ulong> input, ulong value)
        {
            for (var i = 0; i < input.Count(); i++)
            {
                for (var j = 1; j < input.Count(); j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    
                    var subset = input.Skip(i).Take(j);
                    var sum = subset.Aggregate((a, b) => a + b);
                    if (sum == value) {
                        subset = subset.OrderBy(a => a);
                        var low = subset.First();
                        var high = subset.Last();
                        Console.WriteLine($"low - {low} ");
                        Console.WriteLine($"high - {high} ");
                        Console.WriteLine($"result - {low+high} ");
                        return;
                    }
                }
            }
        }

        private ulong? Part1(IEnumerable<ulong> input, int preamble)
        {
            for (var i = preamble; i < input.Count(); i++)
            {
                var subset = input.Skip(i - preamble).Take(preamble);
                var current = input.Skip(i).Take(1).FirstOrDefault();

                if (!IsMatch(current, subset.ToArray()))
                {
                    Console.WriteLine(current);
                    return current;
                }
            }

            return null;
        }

        private bool IsMatch(ulong current, ulong[] subset)
        {
            for (var i = 0; i < subset.Length; i++)
            {
                for (var j = 0; j < subset.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var val1 = subset[i];
                    var val2 = subset[j];

                    if (val1 + val2 == current)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}