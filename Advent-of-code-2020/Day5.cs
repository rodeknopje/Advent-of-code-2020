using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_code_2020
{
    public class Day5 : BaseDay
    {
        protected override int Day => 5;

        private int GetSeatId(string line)
        {
            (int min, int max) row = (0, 127);
            (int min, int max) col = (0, 007);

            foreach (var letter in line.Take(7))
            {
                var halfRange = (row.max - row.min + 1) / 2;

                row.max -= letter == 'F' ? halfRange : 0;
                row.min += letter == 'B' ? halfRange : 0;
            }

            foreach (var letter in line.Skip(7))
            {
                var halfRange = (col.max - col.min + 1) / 2;

                col.max -= letter == 'L' ? halfRange : 0;
                col.min += letter == 'R' ? halfRange : 0;
            }

            return row.min * 8 + col.min;
        }

        public override void Solution1()
        {
            Console.WriteLine(File.ReadAllLines(FilePath).Select(GetSeatId).OrderByDescending(x => x).First());
        }

        public override void Solution2()
        {
            var seatsOnPlane = File.ReadAllLines(FilePath).Select(GetSeatId).ToList();

            Console.WriteLine(
                seatsOnPlane.FirstOrDefault(id =>
                    seatsOnPlane.Contains(id + 1) == false &&
                    seatsOnPlane.Contains(id + 2) == true
                ) + 1
            );
        }
    }
}