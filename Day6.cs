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

            var declarations = ParseInput(input);
            var result1 = CountYeses(declarations.ToArray());

            Console.WriteLine($"Part 1 - {result1}");

            var result2 = CountUniqueYeses(declarations.ToArray());

            Console.WriteLine($"Part 2 - {result2}");            
        }

        private IEnumerable<Declaration> ParseInput(IEnumerable<string> input)
        {
            List<Declaration> declarations = new List<Declaration>();

            var current = new StringBuilder();

            foreach (var row in input)
            {
                if (!string.IsNullOrWhiteSpace(row))
                {
                    current.Append(row + " ");
                }
                else
                {
                    declarations.Add(new Declaration(current.ToString()));
                    current = new StringBuilder();
                }
            }

            declarations.Add(new Declaration(current.ToString()));

            return declarations;
        }        

        private int CountYeses(Declaration[] declarations) {
            var count = 0;
            foreach (var d in declarations) {
                count += d.Yes.Distinct().Count();
            }
            
            return count;
        }

        private int CountUniqueYeses(Declaration[] declarations) {
            var count = 0;

            foreach (var d in declarations) {
                var distinct = d.Yes.Distinct();
                foreach (var c in distinct) {
                    if (d.Yes.Count(y => y == c) == d.People) {
                        count += 1;
                    }
                }
            }
            
            return count;
        }        
    }

    public class Declaration 
    {        
        public char[] Yes {get; set;}

        public int People { get; set;}

        public Declaration(string input) {
            var flat = input.Replace(" ", "");
            Yes = flat.Select(c => c).ToArray();            

            People = input.Split(" ").Count() - 1;
        }
    }
}