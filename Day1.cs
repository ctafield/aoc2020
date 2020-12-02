using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    public class Day1 : AocBase
    {
        public Day1() {
            var values = LoadInput<int>(@"input\day1.txt");
            Part1(values);
            Part2(values);
        }

        private void Part1(IEnumerable<int> values)
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

        private void Part2(IEnumerable<int> values)
        {
            foreach (var v1 in values)
            {
                foreach (var v2 in values)
                {
                    var v3 = values.FirstOrDefault(v => v + v1 + v2 == 2020);
                    if (v3 != default(int))
                    {
                        Console.WriteLine($"Day 1 part 2 = {v1 * v2 * v3}");
                        return;                        
                    }
                }
            }            
        }
    }

}