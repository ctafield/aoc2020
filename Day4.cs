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

            var validStrictPassports = passports.Count(p => p.IsValidStrict());
            Console.WriteLine($"Part 2 - {validStrictPassports}");
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

        public bool IsValidStrict()
        {
            if (string.IsNullOrWhiteSpace(Eyr) ||
                string.IsNullOrWhiteSpace(Pid) ||
                string.IsNullOrWhiteSpace(Hcl) ||
                string.IsNullOrWhiteSpace(Byr) ||
                string.IsNullOrWhiteSpace(Iyr) ||
                string.IsNullOrWhiteSpace(Ecl) ||
                string.IsNullOrWhiteSpace(Hgt))
            {
                return false;
            }

            if (!int.TryParse(Byr, out var byr))
            {
                return false;
            }

            if (byr < 1920 || byr > 2002)
            {
                return false;
            }

            if (!int.TryParse(Iyr, out var iyr))
            {
                return false;
            }

            if (iyr < 2010 || iyr > 2020)
            {
                return false;
            }

            if (!int.TryParse(Eyr, out var eyr))
            {
                return false;
            }

            if (eyr < 2020 || eyr > 2030)
            {
                return false;
            }

            if (!Hgt.EndsWith("cm") && !Hgt.EndsWith("in"))
            {
                return false;
            }

            if (Hgt.EndsWith("cm"))
            {
                if (!int.TryParse(Hgt.Replace("cm", ""), out var hgt))
                {
                    return false;
                }
                if (hgt < 150 || hgt > 193)
                {
                    return false;
                }
            }

            if (Hgt.EndsWith("in"))
            {
                if (!int.TryParse(Hgt.Replace("in", ""), out var hgt))
                {
                    return false;
                }
                if (hgt < 59 || hgt > 76)
                {
                    return false;
                }
            }

            if (Hcl.Length != 7 || !Hcl.StartsWith("#")) {
                return false;
            }

            const string validHair = "0123456789abcdef";

            for (var i = 1; i < Hcl.Length; i++) {
                if (!validHair.Contains(Hcl[i].ToString().ToLower())) {
                    return false;
                }
            }

            string[] validEyes = new string[] {
                "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
            };

            if (!validEyes.Contains(Ecl.ToLower())){
                return false;
            }

            if (Pid.Length != 9)
            {
                return false;
            }

            if (!int.TryParse(Pid, out var temp1)) {
                return false;
            }

            return true;
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