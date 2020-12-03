using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc2020
{
    public class Day3 : AocBase
    {
        private const char Tree = '#';

        public Day3()
        {
            Console.WriteLine("Day 3");

            var values = LoadInput<string>(@"input\day3.txt");
            Part1(values.ToArray());
        }

        private void Part1(string[] values)
        {
            var col = 0;
            var trees = 0;
            
            for (var row = 0; row < values.Count(); row++) {
                var position = values[row][col];
                if (position == Tree) {
                    trees++;
                }
                col +=3;
                if (col >= values[row].Length) {
                    col -= values[row].Length;
                }
            }

            Console.WriteLine($"Trees = {trees}");
        }
    }
}