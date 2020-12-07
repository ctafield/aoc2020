using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aoc2020
{
    public class Day7 : AocBase
    {
        public Day7()
        {
            Console.WriteLine("Day 7");

            var input = LoadInput<string>(@"input\day7-test.txt");
            var luggageRules = ParseInput(input);
        }

        private Dictionary<string, LuggageRule[]> ParseInput(IEnumerable<string> rules) {
            var output = new Dictionary<string, LuggageRule[]>();

            foreach (var rule in rules) {
                // bright olive bags contain 5 dotted white bags, 2 wavy lavender bags.
                var parts = rule.Split("bags contain", 2, StringSplitOptions.TrimEntries);
                var index = parts[0];

                var theseRules = parts[1].Replace(".", "").Split(',').Select(r => new LuggageRule(r.Trim())).ToArray();

                output.Add(index, theseRules);
            }

            return output;
        }
    }

    public class LuggageRule
    {
        public int Count { get; set;}

        public string Colour { get; set;}

        public LuggageRule(string input) {
            if (input == "no other bags") {
                Count = -1;
                return;
            }
            var parts = input.Split(" ", 2, StringSplitOptions.TrimEntries);
            Count = int.Parse(parts[0]);
            Colour = parts[1].Replace("bags", "bag").Replace("bag", "").Trim();
        }
    }
}