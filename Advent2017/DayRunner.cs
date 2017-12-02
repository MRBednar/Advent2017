using System;
using System.Collections.Generic;

namespace Advent2017
{
    class DayRunner
    {
        public static void Main(string[] args)
        {
            // I wanted a simple way to run whatever day's
            // code in whatever order I wanted. This takes
            // the days as inputs and runs them one by one
            int day;
            foreach (string arg in args)
            {
                if (int.TryParse(arg, out day))
                {
                    dayArgument[day].Run();
                }
                Console.ReadKey();
            }
        }

        public static Dictionary<int, IDay>
            dayArgument = new Dictionary<int, IDay>
            {
                {1, new Day1() },
            };
    }
}