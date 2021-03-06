﻿using System;
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
            int divChecksum = 0;
            foreach (string inputLine in day2Input)
            {
                string[] inputSplit = { "\t" };
                numberString = inputLine.Split(inputSplit, StringSplitOptions.RemoveEmptyEntries).ToList();
                numbers = numberString.Select(i => int.Parse(i)).ToList();
                numbers.Sort();
                totalChecksum = totalChecksum + (numbers.Max() - numbers.Min());
                divChecksum = divChecksum + DivideLoop(numbers);
            }
            Console.WriteLine("Final Total Checksum: {0}", totalChecksum);
            Console.WriteLine("Final Div Checksum: {0}", divChecksum);
        }

        private int DivideLoop(List<int> listInts)
        {
            for (int i = 0; i < listInts.Count; i++)
            {
                for (int s = i+1; s < listInts.Count; s++)
                {
                    if (listInts[i] % listInts[s] == 0)
                    {
                        return listInts[i] / listInts[s];
                    } else if (listInts[s] % listInts[i] == 0)
                    {
                        return listInts[s] / listInts[i];
                    }
                }
            }
            return 0;
        }
    }
}
