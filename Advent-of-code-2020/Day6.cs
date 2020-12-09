using System;
using System.IO;
using System.Linq;

namespace Advent_of_code_2020
{
    public class Day6 : BaseDay
    {
        protected override int Day => 6;

        public override void Solution1()
        {
            Console.WriteLine(
                File.ReadAllText(FilePath)
                    .Split("\r\n\r\n").ToList()
                    .Select(group => group
                        .Replace("\r\n", string.Empty)
                        .Distinct()
                        .Count())
                    .Sum()
            );
        }

        public override void Solution2()
        {
            var groups = File.ReadAllText(FilePath)
                .Split("\r\n\r\n")
                .Select(group => group.Split("\r\n").ToList()).ToList();

            var answer = 0;
            
            foreach (var group in groups)
            {
                foreach (var letter in "abcdefghijklmnopqrstuvwxyz")
                {
                    var letterCount = group.Count(line => line.Contains(letter));
                    
                    if (letterCount == group.Count)
                    {
                        answer++;
                    }
                }
            }

            Console.WriteLine(answer);
        }
    }
}