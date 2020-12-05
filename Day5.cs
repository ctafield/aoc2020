using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aoc2020
{
    public class Day5 : AocBase
    {
        public Day5()
        {
            Console.WriteLine("Day 5");

            var input = LoadInput<string>(@"input\day5.txt");

            var seats = input.Select(i => new Seat(i)).ToArray();
            var seatId = seats.OrderBy(s => s.SeatId).Last().SeatId;

            Console.WriteLine($"Part 1 - {seatId}");

            var orderedSeats = seats.OrderBy(s => s.SeatId);

            for (var i = 0; i < orderedSeats.Count(); i++) {
                // is this seat taken?
                var taken = orderedSeats.Any(s => s.SeatId == i);        
                if (!taken) {
                    // does it exist?
                    var exists = orderedSeats.Count(s => s.SeatId == i -1 || s.SeatId == i + 1);                    
                    // check both exist
                    if (exists == 2) {
                        Console.WriteLine($"Part 2 - {i}"); 
                    }
                }
            }
        }
    }

    public class Seat
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int SeatId
        {
            get
            {
                return (Row * 8) + Col;
            }
        }

        public Seat(string input)
        {
            Row = Parse(input.Substring(0, 7), 127);
            Col = Parse(input.Substring(7, 3), 7);
        }

        private int Parse(string input, int high)
        {
            int low = 0;

            for (var i = 0; i < input.Length - 1; i++)
            {
                var move = input[i];

                int diff = (int)Math.Ceiling(((double)high - (double)low) / 2);

                if (move == 'F' || move == 'L')
                {
                    // lower half
                    high -= diff;
                }
                else if (move == 'B' || move == 'R')
                {
                    // upper half
                    low += diff;
                }
            }

            var lastMove = input[input.Length-1];

            if (lastMove == 'F' || lastMove == 'L')
            {
                // lower half
                return low;
            }
            else if (lastMove == 'B' || lastMove == 'R')
            {
                // upper half
                return high;
            }

            return -1;
        }
    }
}