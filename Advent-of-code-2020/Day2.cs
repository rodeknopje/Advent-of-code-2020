using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode_2020
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
                    
                    var min        = Convert.ToInt32(match.Groups[1].ToString());
                    var max        = Convert.ToInt32(match.Groups[2].ToString());
                    var letter= match.Groups[3].ToString().First();
                    var password   = match.Groups[4].ToString();
                    
                    var letterCount =  password.Count(c => c == letter);

                    return letterCount >= min && letterCount <= max;
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
                    
                    var firstIndex   = Convert.ToInt32(match.Groups[1].ToString()) -1;
                    var secondIndex  = Convert.ToInt32(match.Groups[2].ToString()) -1;
                    var letter= match.Groups[3].ToString().First();
                    var password   = match.Groups[4].ToString();

                    var firstMatch  = password[firstIndex]  == letter;
                    var secondMatch = password[secondIndex] == letter;

                    return (firstMatch && !secondMatch) || (!firstMatch && secondMatch) ;
                });

            Console.WriteLine(count);
        }
    }
}