using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc2020
{
    public class Day2 : AocBase
    {
        public Day2()
        {
            Console.WriteLine("Day 2");

            var values = LoadInput<string>(@"input\day2.txt");
            Part1(values);
        }

        private void Part1(IEnumerable<string> values)
        {
            var passwords = values.Select(s => new PasswordPolicy(s)).ToArray();
            var validPasswords = passwords.Count(p => p.IsValid());
            Console.WriteLine($"Part 1 - {validPasswords}");
        }
    }

    public class PasswordPolicy
    {
        public string Password { get; set; }
        public string Character { get; set; }
        public short MinCount { get; set; }
        public short MaxCount { get; set; }

        public PasswordPolicy(string input)
        {
            var regex = new Regex(@"(?'min'\d{1,2})-(?'max'\d{1,2})\s(?'character'\w):\s(?'password'\w*)");

            var match = regex.Match(input);
            if (match.Success)
            {
                MinCount = short.Parse(match.Groups[1].Value);
                MaxCount = short.Parse(match.Groups[2].Value);
                Character = match.Groups[3].Value;
                Password = match.Groups[4].Value;
            }
        }

        public bool IsValid() {
            var count = Password.Count(c => c.ToString() == Character);
            return count >= MinCount && count <= MaxCount;
        }
    }
}