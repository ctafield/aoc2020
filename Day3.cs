using System;
using System.Linq;

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
            Part2(values.ToArray());
        }

        private void Part1(string[] values)
        {
            var trees = ProcessTraversal(values, 3, 1);
            Console.WriteLine($"Part 1 - Trees = {trees}");
        }

        private void Part2(string[] values)
        {
            var val1 = ProcessTraversal(values, 1, 1);
            var val2 = ProcessTraversal(values, 3, 1);
            var val3 = ProcessTraversal(values, 5, 1);
            var val4 = ProcessTraversal(values, 7, 1);
            var val5 = ProcessTraversal(values, 1, 2);

            var trees = val1 * val2 * val3 * val4 * val5;

            Console.WriteLine($"Part 2 - Trees = {trees}");
        }

        private int ProcessTraversal(string[] values, int rightStep, int downStep)
        {
            var col = 0;
            var trees = 0;

            for (var row = 0; row < values.Count(); row += downStep)
            {
                var position = values[row][col];
                if (position == Tree)
                {
                    trees++;
                }
                col += rightStep;
                if (col >= values[row].Length)
                {
                    col -= values[row].Length;
                }
            }

            return trees;
        }
    }
}