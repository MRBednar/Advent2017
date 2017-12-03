using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2017
{
    public class Day2 : BaseDay
    {
        public override void Run()
        {
            List<string> numberString = null;
            List<int> numbers = null;
            var day2Input = GetDayInput(2);
            int totalChecksum = 0;
            foreach (string inputLine in day2Input)
            {
                string[] inputSplit = { "\t" };
                numberString = inputLine.Split(inputSplit, StringSplitOptions.RemoveEmptyEntries).ToList();
                numbers = numberString.Select(i => int.Parse(i)).ToList();
                numbers.Sort();
                totalChecksum = totalChecksum + (numbers.Max() - numbers.Min());
            }
            Console.WriteLine("Final Total Checksum: {0}", totalChecksum);
        }
    }
}
