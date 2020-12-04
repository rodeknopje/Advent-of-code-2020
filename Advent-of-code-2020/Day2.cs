using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace Advent_of_code_2020
{
    public class Day2 : BaseDay
    {
        protected override int Day => 2;

        public override void Solution1()
        {
            var count = File
                .ReadLines(FilePath)
                .ToList()
                .Count(line =>
                {
                    var match = new Regex("(\\d+)-(\\d+)\\s(\\w):\\s(.+)").Match(line);

                    var min = Convert.ToInt32(match.Groups[1].ToString());
                    var max = Convert.ToInt32(match.Groups[2].ToString());
                    
                    var letter = char.Parse(match.Groups[3].ToString());
                    
                    var password = match.Groups[4].ToString();

                    var letterCount = password.Count(c => c == letter);
                    
                    return min <= letterCount && letterCount <= max;
                });

            Console.WriteLine(count);
        }

        public override void Solution2()
        {
            var count = File
                .ReadLines(FilePath)
                .ToList()
                .Count(line =>
                {
                    var match = new Regex("(\\d+)-(\\d+)\\s(\\w):\\s(.+)").Match(line);

                    var index1 = Convert.ToInt32(match.Groups[1].ToString());
                    var index2 = Convert.ToInt32(match.Groups[2].ToString());
                    
                    var letter = char.Parse(match.Groups[3].ToString());
                    
                    var password = match.Groups[4].ToString();
                    
                    var match1 = password[--index1] == letter;
                    var match2 = password[--index2] == letter;

                    return match1 ^ match2;
                });
            
            Console.WriteLine(count);
        }
    }
}