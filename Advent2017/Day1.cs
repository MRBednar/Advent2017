using System;


namespace Advent2017
{
    public class Day1 : BaseDay
    {
        public override void Run()
        {
            var day1Input = GetDayInput(1);

            int halfwayTotal = 0;

            foreach (string inputLine in day1Input)
            {
                int lineSum = 0;
                var charArray = inputLine.ToCharArray();
                int halfLength = charArray.Length / 2;
                for (int index = 1; index < charArray.Length; index++)
                {

                    if (charArray[index] == charArray[index - 1])
                    {
                        lineSum = lineSum + int.Parse(charArray[index].ToString());
                    }

                    if (index+1 == charArray.Length)
                    {
                        if (charArray[index] == charArray[0])
                        {
                            lineSum = lineSum + int.Parse(charArray[index].ToString());
                        }
                    }

                    if (index < halfLength && charArray[index] == charArray[index + halfLength])
                    {
                        Console.WriteLine("Numbers match! Adding {0} to current total of: {1}", charArray[index], halfwayTotal);
                        halfwayTotal = halfwayTotal + int.Parse(charArray[index].ToString())*2;
                    }
                }
                Console.WriteLine("Line total: {0}",lineSum);
            }
            Console.WriteLine("Part 2, the halfway total: {0}", halfwayTotal);
        }
    }
}