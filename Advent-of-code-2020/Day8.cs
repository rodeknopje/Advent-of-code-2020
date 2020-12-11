using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_code_2020
{
    public class Day8 : BaseDay
    {
        protected override int Day => 8;

        private (bool succes, int accumulator) CalculateAccumulator(List<string> lines)
        {
            var index = 0;
            var accumulator = 0;

            var previousIndices = new List<int>();

            while (index < lines.Count)
            {
                if (previousIndices.Contains(index) || index < 0)
                {
                    return (false, accumulator);
                }

                previousIndices.Add(index);

                var command = lines[index].Split(" ");

                switch (command[0])
                {
                    case "nop":
                    {
                        index++;
                        break;
                    }
                    case "acc":
                    {
                        accumulator += Convert.ToInt32(command[1]);
                        index++;
                        break;
                    }
                    case "jmp":
                    {
                        index += Convert.ToInt32(command[1]);
                        break;
                    }
                }
            }
            
            return (true, accumulator);
        }

        public override void Solution1()
        {
            Console.WriteLine(CalculateAccumulator(File.ReadAllLines(FilePath).ToList()).accumulator);
        }

        public override void Solution2()
        {
            var lines = File.ReadAllLines(FilePath).ToList();
            
            for (var i = 0; i < lines.Count; i++)
            {
                var command = lines[i].Split(" ");

                if (command[0] == "jmp" || command[0] == "nop")
                {
                    var testLines = new List<string>(lines);

                    testLines[i] = $"{(command[0] == "jmp" ? "nop" : "jmp")} {command[1]}";

                    var tryCalculate = CalculateAccumulator(testLines);

                    if (tryCalculate.succes)
                    {
                        Console.WriteLine(tryCalculate.accumulator);
                        
                        break;
                    }
                }
            }
        }
    }
}