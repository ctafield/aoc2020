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
            Part2(values);
        }

        private void Part1(IEnumerable<string> values)
        {
            var passwords = values.Select(s => new PasswordPolicy(s)).ToArray();
            var validPasswords = passwords.Count(p => p.IsValid(true));
            Console.WriteLine($"Part 1 - {validPasswords}");
        }

        private void Part2(IEnumerable<string> values)
        {
            var passwords = values.Select(s => new PasswordPolicy(s)).ToArray();
            var validPasswords = passwords.Count(p => p.IsValid(false));
            Console.WriteLine($"Part 2 - {validPasswords}");
        }
    }

    public class PasswordPolicy
    {
        public string Password { get; set; }
        public char Character { get; set; }
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
                Character = char.Parse(match.Groups[3].Value);
                Password = match.Groups[4].Value;
            }
        }

        public bool IsValid(bool useCount)
        {
            if (useCount) {
                return HasValidCount(Password, MinCount, MaxCount);
            }

            var checkpoints = $"{Password[MinCount - 1]}{Password[MaxCount - 1]}";
            return HasValidCount(checkpoints, 1, 1);
        }

        private bool HasValidCount(string input, short lower, short upper) {
            var count = input.Count(c => c == Character);
            return count >= lower && count <= upper;
        }
    }
}