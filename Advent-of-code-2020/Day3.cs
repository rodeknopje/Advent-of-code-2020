using System;
using System.IO;
using System.Linq;

namespace Advent_of_code_2020
{
    public class Day3 : BaseDay
    {
        protected override int Day => 3;

        public override void Solution1()
        {
            var lines = File.ReadAllLines(FilePath).ToList();

            var sizeY = lines.Count;
            var sizeX = lines[0].Length;

            var answer = 0;

            for (var y = 0; y < sizeY; y++)
            {
                answer += lines[y][y * 3 % sizeX] == '#' ? 1 : 0;
            }
            
            Console.WriteLine(answer);
        }

        public override void Solution2()
        {
            Console.WriteLine(
                GetTreeCount(1, 1) *
                GetTreeCount(3, 1) *
                GetTreeCount(5, 1) *
                GetTreeCount(7, 1) *
                GetTreeCount(1, 2)
            );

            long GetTreeCount(int right, int down)
            {
                var lines = File.ReadAllLines(FilePath).ToList();

                var sizeY = lines.Count;
                var sizeX = lines[0].Length;

                var planeX = 0;
                var answer = 0;

                for (var y = 0; y < sizeY; y += down)
                {
                    answer += lines[y][planeX] == '#' ? 1 : 0;

                    planeX = (planeX + right) % sizeX;
                }

                return answer;
            }
        }
    }
}