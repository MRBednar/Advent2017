using System;
using System.Collections.Generic;


namespace Advent2017
{
    public class Day1 : BaseDay
    {
        public override void Run()
        {
            var day1Input = GetDayInput(1).Result;

            int inputTotal = 0;

            foreach (string inputLine in day1Input)
            {
                int lineSum = 0;
                var charArray = inputLine.ToCharArray();
                for(int index = 1; index < charArray.Length; index++)
                {
                    if (charArray[index] == charArray[index - 1])
                    {
                        lineSum = lineSum + charArray[index];
                    }

                    if (index+1 == charArray.Length)
                    {
                        if (charArray[index] == charArray[0])
                        {
                            lineSum = lineSum + charArray[index];
                        }
                    }
                }
                Console.WriteLine("Line total: {0}",lineSum);
                inputTotal = inputTotal + lineSum;
            }
            Console.WriteLine("Input total: {0}", inputTotal);
        }
    }
}