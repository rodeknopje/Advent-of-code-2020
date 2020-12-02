using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode_2020
{
    public class Day1 : BaseDay
    {
        protected override int Day => 1;

        private List<int> Numbers { get; set; }

        public Day1()
        {
            Numbers = File.ReadAllLines(FilePath).Select(line => Convert.ToInt32(line)).ToList();
        }

        public override void Solution1()
        {
            Console.WriteLine((
                from a in Numbers 
                from b in Numbers 
                where a + b == 2020 
                select a * b).FirstOrDefault());
        }

        public override void Solution2()
        {
            Console.WriteLine((
                from a in Numbers
                from b in Numbers
                from c in Numbers
                where a + b + c == 2020
                select a * b * c).FirstOrDefault());
        }
    }
}