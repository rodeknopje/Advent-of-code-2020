using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_code_2020
{
    public class Day10 : BaseDay
    {
        protected override int Day => 10;

        List<int> numbers = new List<int>();

        public Day10()
        {
            numbers = File.ReadAllLines(FilePath).Select(line => Convert.ToInt32(line)).OrderBy(x => x).ToList();
        }


        public override void Solution1()
        {
            var differences = new List<long>
            {
                numbers.First(), 3
            };

            for (var i = 1; i < numbers.Count; i++)
            {
                differences.Add(numbers[i] - numbers[i - 1]);
            }

            Console.WriteLine(
                differences.Count(x => x == 3) *
                differences.Count(x => x == 1)
            );
        }

        public override void Solution2()
        {
            numbers.Insert(0, 0);

            numbers = numbers.OrderBy(x => x).ToList();

            var paths = new Dictionary<int, List<int>>();

            for (var i = 0; i < numbers.Count; i++)
            {
                paths.Add(numbers[i], numbers.Where(number =>
                    number - numbers[i] <= 3 &&
                    number - numbers[i] > 0
                ).ToList());
            }
            var knowPaths = new Dictionary<int, ulong>();
            
            ulong TraversePath(int index)
            {
                if (knowPaths.ContainsKey(index))
                {
                    return knowPaths[index];
                }

                if (index == numbers.Last())
                {
                    return 1;
                }

                ulong value = 0;

                var route = paths[index];

                for (var i = 0; i < route.Count; i++)
                {
                    value += TraversePath(route[i]);
                }

                knowPaths.Add(index, value);

                return value;
            }

            Console.WriteLine(TraversePath(0));
        }
    }
}