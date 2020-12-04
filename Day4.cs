using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aoc2020
{
    public class Day4 : AocBase
    {
        public Day4()
        {
            Console.WriteLine("Day 4");

            var input = LoadInput<string>(@"input\day4.txt");

            var passports = ParseInput(input);

            var validPassports = passports.Count(p => p.IsValid());
            Console.WriteLine($"Part 1 - {validPassports}");
        }

        private IEnumerable<Passport> ParseInput(IEnumerable<string> input)
        {

            List<Passport> passports = new List<Passport>();

            var current = new StringBuilder();

            foreach (var row in input)
            {
                if (!string.IsNullOrWhiteSpace(row))
                {
                    current.Append(row + " ");
                }
                else
                {
                    passports.Add(new Passport(current.ToString()));
                    current = new StringBuilder();
                }
            }

            passports.Add(new Passport(current.ToString()));

            return passports;
        }
    }

    internal class Passport
    {
        public Passport(string flat)
        {
            var values = flat.Split(" ");
            foreach (var value in values)
            {
                var property = value.Split(":");
                switch (property[0])
                {
                    case "byr":
                        Byr = property[1];
                        break;
                    case "iyr":
                        Iyr = property[1];
                        break;
                    case "eyr":
                        Eyr = property[1];
                        break;
                    case "hgt":
                        Hgt = property[1];
                        break;
                    case "hcl":
                        Hcl = property[1];
                        break;
                    case "ecl":
                        Ecl = property[1];
                        break;
                    case "pid":
                        Pid = property[1];
                        break;
                    case "cid":
                        Cid = property[1];
                        break;
                }
            }
        }

        public bool IsValid()
        {
            var hasRequired =
                !string.IsNullOrWhiteSpace(Eyr) &&
                !string.IsNullOrWhiteSpace(Pid) &&
                !string.IsNullOrWhiteSpace(Hcl) &&
                !string.IsNullOrWhiteSpace(Byr) &&
                !string.IsNullOrWhiteSpace(Iyr) &&
                !string.IsNullOrWhiteSpace(Ecl) &&
                !string.IsNullOrWhiteSpace(Hgt);

            if (hasRequired)
            {
                return true;
            }

            return false;

        }

        public string Eyr { get; set; }

        public string Pid { get; set; }

        public string Hcl { get; set; }

        public string Byr { get; set; }

        public string Iyr { get; set; }

        public string Ecl { get; set; }

        public string Hgt { get; set; }

        public string Cid { get; set; }
    }
}
