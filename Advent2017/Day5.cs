using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2017
{
    public class Day5 : BaseDay
    {
        public override void Run()
        {
            var day5Input = GetDayInput(5);
            List<int> input = new List<int>();
            bool outsideArray = false;
            bool part2Array = false;
            var index = 0;
            var steps = 0;
            var jumpValue = 0;
            var oldIndex = 0;
            foreach (string numberString in day5Input)
            {
                input.Add(int.Parse(numberString));
            }
            List<int> part2 = input.ToArray().ToList();
            while (outsideArray == false) {
                jumpValue = input[index];
                oldIndex = index;
                steps++;
                index = jumpValue + index;
                input[oldIndex]++;
                if (index >= input.Count)
                {
                    outsideArray = true;
                }
            }
            Console.WriteLine("Steps to exit maze for part 1: {0}", steps);
            var index2 = 0;
            var steps2 = 0;
            while (part2Array == false)
            {
                jumpValue = part2[index2];
                oldIndex = index2;
                steps2++;
                index2 = jumpValue + index2;
                if (jumpValue >= 3)
                {
                    part2[oldIndex]--;
                } else
                {
                    part2[oldIndex]++;
                }
                if (index2 >= part2.Count)
                {
                    part2Array = true;
                }
            }
            Console.WriteLine("Steps to exit maze for part 2: {0}", steps2);
        }
    }
}
