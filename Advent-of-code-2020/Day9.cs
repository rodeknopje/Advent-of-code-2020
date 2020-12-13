using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Channels;

namespace Advent_of_code_2020
{
    public class Day9 : BaseDay
    {
        protected override int Day => 9;


        public override void Solution1()
        {
            var numbers = File.ReadAllLines(FilePath).Select(line => Convert.ToInt64(line)).ToList();

            for (var i = 25; i < numbers.Count; i++)
            {
                var number = numbers[i];

                var isValid = false;

                for (var j = i - 25; j < i; j++)
                {
                    for (var k = i - 25; k < i; k++)
                    {
                        if (k == j)
                        {
                            continue;
                        }

                        if (numbers[k] + numbers[j] == number)
                        {
                            isValid = true;
                        }
                    }
                }

                if (isValid == false)
                {
                    Console.WriteLine(number);
                    return;
                }
            }
        }

        public override void Solution2()
        {
            const long invalidNumber = 257342611;

            var numbers = File.ReadAllLines(FilePath).Select(line => Convert.ToInt64(line)).ToList();

            

            for (var i = 0; i < numbers.Count; i++)
            {
                var contiguousNumbers = new List<long>();
                
                for (var j = i; j < numbers.Count; j++)
                {
                    contiguousNumbers.Add(numbers[j]);

                    if (contiguousNumbers.Sum() > invalidNumber)
                    {
                        break;
                    }
                    if (contiguousNumbers.Sum() == invalidNumber)
                    {
                        contiguousNumbers = contiguousNumbers.OrderBy(x => x).ToList();
                        
                        Console.WriteLine(contiguousNumbers.First()+contiguousNumbers.Last());
                        
                        return;
                    }
                }
            }
        }
    }
}