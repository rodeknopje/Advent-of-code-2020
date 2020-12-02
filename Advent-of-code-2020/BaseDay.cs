using System;
using System.IO;

namespace Advent_of_code_2020
{
    public abstract class BaseDay
    {
        protected abstract int Day { get; }

        public abstract void Solution1();
        public abstract void Solution2();

        protected string FilePath =>  Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName,$"input\\{Day}.txt");
    }
}