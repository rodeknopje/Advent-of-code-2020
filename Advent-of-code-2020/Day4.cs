using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_code_2020
{
    public class Day4 : BaseDay
    {
        protected override int Day => 4;


        public override void Solution1()
        {
            var requiredTags = new List<string>
            {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid"
            };

            var passports = File.ReadAllText(FilePath).Split("\r\n\r\n");

            var answer = passports
                .Select(passport => new Regex("(.{3}):(.+?)(?:\\s|\n|$)").Matches(passport)
                    .Select(match => match.Groups[1])
                    .Where(group => requiredTags.Contains(group.Value)).ToList())
                .Count(matches => matches.Count == 7);

            Console.WriteLine(answer);
        }

        public override void Solution2()
        {
            var requiredTags = new Dictionary<string, Func<string, bool>>
            {
                {"byr", input => 1920 <= Convert.ToInt32(input) && Convert.ToInt32(input) <= 2002},
                {"iyr", input => 2010 <= Convert.ToInt32(input) && Convert.ToInt32(input) <= 2020},
                {"eyr", input => 2020 <= Convert.ToInt32(input) && Convert.ToInt32(input) <= 2030},
                {"hcl", input => new Regex("^#[\\da-f]{6}$").IsMatch(input)},
                {"pid", input => new Regex("^\\d{9}$").IsMatch(input)},
                {"ecl", input => "amb-blu-brn-gry-grn-hzl-oth".Split("-").Contains(input)},
                {
                    "hgt", input =>
                    {
                        var number = Convert.ToInt32(new Regex("\\d+").Match(input).ToString());

                        return
                            input.Contains("cm")
                                ? 150 <= number && number <= 193
                                : input.Contains("in") && 58 <= number && number <= 76;
                    }
                }
            };

            var passports = File.ReadAllText(FilePath).Split("\r\n\r\n");

            var answer = passports
                .Select(passport => new Regex("(.{3}):(.+?)(?:\\s|\n|$)").Matches(passport)
                    .Where(match => requiredTags.ContainsKey(match.Groups[1].ToString()))
                    .Where(match => requiredTags[match.Groups[1].ToString()](match.Groups[2].ToString())).ToList())
                .Count(matches => matches.Count == 7);

            Console.WriteLine(answer);
        }
    }
}