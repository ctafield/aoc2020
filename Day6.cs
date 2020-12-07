using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aoc2020
{
    public class Day6 : AocBase
    {
        public Day6()
        {
            Console.WriteLine("Day 6");

            var input = LoadInput<string>(@"input\day6.txt");
            var declarations = ParseInput(input, (r) => new Declaration(r));

            var result1 = CountYeses(declarations);
            Console.WriteLine($"Part 1 - {result1}");

            var result2 = CountUniqueYeses(declarations);
            Console.WriteLine($"Part 2 - {result2}");
        }

        private int CountYeses(IEnumerable<Declaration> declarations)
        {
            return declarations.Sum(d => d.DistinctYes.Count());
        }

        private int CountUniqueYeses(IEnumerable<Declaration> declarations)
        {
            return declarations.Sum(d => d.EveryoneYes);
        }
    }

    public class Declaration
    {
        public char[] Yes { get; set; }

        public int People { get; set; }

        public IEnumerable<char> DistinctYes
        {
            get
            {
                return Yes.Distinct();
            }
        }

        public int EveryoneYes
        {
            get
            {
                return DistinctYes.Count(dy => Yes.Count(y => y == dy) == People);
            }
        }

        public Declaration(string input)
        {
            var flat = input.Replace(" ", "");
            Yes = flat.Select(c => c).ToArray();

            People = input.Split(" ").Count() - 1;
        }
    }
}