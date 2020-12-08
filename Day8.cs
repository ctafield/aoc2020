using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    public class Day8 : AocBase
    {
        public Day8()
        {
            Console.WriteLine("Day 8");

            var input = LoadInput<string>(@"input\day8.txt");
            var operations = input.Select(x => new OpCode(x)).ToArray();

            Console.WriteLine("Part 1");

            int pointer = 0;
            int accumulator = 0;

            while (true)
            {
                var curr = operations[pointer];

                if (curr.HitCount == 1) {
                    Console.WriteLine($"Accumulator : {accumulator}");
                    break;
                }

                curr.HitCount++;

                switch (curr.Op)
                {
                    case "nop":
                        ++pointer;
                        break;

                    case "acc":
                        accumulator += curr.Val;                        
                        ++pointer;
                        break;

                    case "jmp":
                        pointer += curr.Val;
                        break;
                }
            }
        }
    }

    public class OpCode
    {
        public string Op { get; set; }

        public int Val { get; set; }

        public int HitCount { get; set; }

        public OpCode(string input)
        {
            var parts = input.Split(' ');
            Op = parts[0];
            Val = int.Parse(parts[1].Replace("+", ""));

            HitCount = 0;
        }
    }
}