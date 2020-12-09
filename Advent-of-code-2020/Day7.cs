using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_code_2020
{
    public class Day7 : BaseDay
    {
        protected override int Day => 7;

        public override void Solution1()
        {
            var lines = File.ReadAllLines(FilePath).Where(line => line.Contains("no other bags") == false).ToList();

            var bags = new Dictionary<string, HashSet<string>>();

            foreach (var line in lines)
            {
                
                var matches = new Regex("(?:^|\\s\\d\\s)(.+?) bags??").Matches(line).Select(match => match.Groups[1].ToString()).ToList();

                var firstBag = matches.First();

                matches.Skip(1).ToList().ForEach(bag =>
                {

                    
                    if (bags.ContainsKey(bag))
                    {
                        if (bags[bag].Contains(bag) == false)
                        {
                            bags[bag].Add(firstBag);
                        }
                    }
                    else
                    {
                        bags.Add(bag,new HashSet<string> {firstBag});
                    }
                });
            }

            var goodBags = bags["shiny gold"];
            
            var allGoodBags = goodBags;
            
            while (goodBags.Any())
            {
                allGoodBags.UnionWith(goodBags);
                
                var newGoodBags = new HashSet<string>();

                goodBags.ToList().ForEach(bag =>
                {
                    if (bags.ContainsKey(bag))
                    {
                        newGoodBags.UnionWith(bags[bag]);
                    }
                });

                goodBags = newGoodBags;
            }

            Console.WriteLine(allGoodBags.Count());
        }

        public override void Solution2()
        {
        }
    }
}