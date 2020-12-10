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
            var bags = new Dictionary<string, Dictionary<string,int>>();
            
            var lines = File.ReadAllLines(FilePath);

            foreach (var line in lines)
            {
                var matches = new Regex("(?:^(.+?)\\sbags|(\\d)\\s(.+?)\\sbag)").Matches(line).ToList();
                
                var fistBag = matches.First().Groups[1].ToString();
                
                bags.Add(fistBag,new Dictionary<string, int>());
                
                foreach (var match in matches.Skip(1))
                {
                    bags[fistBag].Add(
                        match.Groups[3].ToString(),
                        Convert.ToInt32(match.Groups[2].ToString()));
                }
            }

            var answer = 0;
            
            var currentBags = new List<string>();

            foreach (var bag in bags["shiny gold"])
            {
                for (var i = 0; i < bag.Value; i++)
                {
                    currentBags.Add(bag.Key);
                }
            }

            while (currentBags.Any())
            {
                answer += currentBags.Count;

                var newBags = new List<string>();

                foreach (var bag in currentBags)
                {
                    var bagsContent = bags[bag];

                    foreach (var content in bagsContent)
                    {
                        for (var i = 0; i < content.Value; i++)
                        {
                            newBags.Add(content.Key);
                        }
                    }
                }

                currentBags = newBags;
            }

            Console.WriteLine(answer);
        }
    }
}