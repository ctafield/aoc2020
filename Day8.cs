using System;
using System.Linq;

namespace aoc2020
{
    public class Day8 : AocBase
    {
        private int pointer;

        private int accumulator;

        public Day8()
        {
            Console.WriteLine("Day 8");

            var input = LoadInput<string>(@"input\day8.txt").ToArray();

            Console.WriteLine("Part 1");
            Part1(input);

            Console.WriteLine("Part 2");
            Part2(input);
        }

        private void Part1(string[] input)
        {
            var operations = input.Select(x => new OpCode(x)).ToArray();
            Execute(operations);
        }

        private void Part2(string[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                var newOpCodes = input.Select(x => new OpCode(x)).ToArray();
                var swapped = false;

                if (newOpCodes[i].Op == "nop")
                {
                    newOpCodes[i].Op = "jmp";
                    swapped = true;
                }
                else if (newOpCodes[i].Op == "jmp")
                {
                    newOpCodes[i].Op = "nop";
                    swapped = true;
                }

                if (!swapped)
                {
                    continue;
                }

                var res = Execute(newOpCodes, false);
                if (res)
                {
                    Console.WriteLine($"Accumulator : {accumulator}");
                    break;
                }
            }
        }

        private bool Execute(OpCode[] operations, bool logOnLoop = true)
        {
            pointer = 0;
            accumulator = 0;

            while (true)
            {
                if (pointer >= operations.Length)
                {
                    // finished ok
                    return true;
                }

                var curr = operations[pointer];

                if (curr.HitCount == 1)
                {
                    // looping
                    if (logOnLoop)
                    {
                        Console.WriteLine($"Accumulator : {accumulator}");
                    }
                    return false;
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

        public int HitCount { get; set; } = 0;

        public OpCode(string input)
        {
            var parts = input.Split(' ');
            Op = parts[0];
            Val = int.Parse(parts[1]);
        }
    }
}