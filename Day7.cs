using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    public class Day7 : AocBase
    {
        public Dictionary<string, LuggageRule[]> LuggageRules { get; private set; }

        public Day7()
        {
            Console.WriteLine("Day 7");

            var input = LoadInput<string>(@"input\day7-test.txt");
            LuggageRules = ParseInput(input);

            var target = "shiny gold";
            var count = 0;
            foreach (var rule in LuggageRules.Where(x => x.Key != target)) {
                if (ContainsTarget(target, rule, 1)) {
                    count += 1;
                }
            }

            Console.WriteLine($"Part 1 - {count}");
        }

        private bool ContainsTarget(string target, KeyValuePair<string, LuggageRule[]> rules, int level)
        {
            if (rules.Value == null) {
                return false;
            }

            foreach (var rule in rules.Value) {
                var subBag = LuggageRules.FirstOrDefault(x => x.Key == rule.Colour);
                if (rules.Key == target || ContainsTarget(target, subBag, level+1)) {                    
                    return true;
                }
            }

            return false;
        }

        private Dictionary<string, LuggageRule[]> ParseInput(IEnumerable<string> rules)
        {
            var output = new Dictionary<string, LuggageRule[]>();

            foreach (var rule in rules)
            {
                var parts = rule.Split("bags contain", 2, StringSplitOptions.TrimEntries);
                var index = parts[0];

                if (!parts[1].Contains("no other bags"))  {
                    var theseRules = parts[1].Replace(".", "").Split(',').Select(r => new LuggageRule(r.Trim())).ToArray();
                    output.Add(index, theseRules);
                } else {
                    output.Add(index, null);
                }
            }

            return output;
        }
    }

    public class LuggageRule
    {
        public int Count { get; set; }

        public string Colour { get; set; }

        public LuggageRule(string input)
        {
            var parts = input.Split(" ", 2, StringSplitOptions.TrimEntries);
            Count = int.Parse(parts[0]);
            Colour = parts[1].Replace("bags", "bag").Replace("bag", "").Trim();
        }
    }
}