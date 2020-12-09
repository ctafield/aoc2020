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

            var input = LoadInput<ulong>(@"input\day9.txt");
            Part1(input, 25);
        }

        private void Part1(IEnumerable<ulong> input, int preamble)
        {
            for (var i = preamble; i < input.Count(); i++) {
                var subset = input.Skip(i-preamble).Take(preamble);
                var current = input.Skip(i).Take(1).FirstOrDefault();

                if (!IsMatch(current, subset.ToArray())) {
                    Console.WriteLine(current);
                    break;
                }
            }
        }

        private bool IsMatch(ulong current, ulong[] subset)
        {
            for (var i = 0; i < subset.Length; i++) {
                for (var j = 0;  j < subset.Length; j++) 
                {
                    if (i == j) {
                        continue;
                    }

                    var val1 = subset[i];
                    var val2 = subset[j];

                    if (val1 + val2 == current) {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}