using System;


namespace Advent2017
{
    public class Day3 : BaseDay
    {
        public override void Run()
        {
            var day3Input = GetDayInput(3);
            double dataGoal = Double.Parse(day3Input[0]);
            double test = 23;
            double squareSide = Math.Ceiling(Math.Sqrt(test));
            if (squareSide % 2 == 0)
            {
                squareSide = squareSide + 1;
                
            }
            double sidePos = test - Math.Pow((squareSide - 2), 2);
            double shortestTaxi = (squareSide - 1) / 2;
            while (sidePos - squareSide > 0)
            {
                sidePos = sidePos - squareSide;
            }
            double test2 = 0;
            if (sidePos > ((squareSide)/2)) {
                test2 = Math.Ceiling(sidePos % ((squareSide)/2));
                Console.WriteLine("Dist = {0}", (test2+shortestTaxi));
            } else if (sidePos < ((squareSide)/2))
            {
                test2 = Math.Ceiling(((squareSide)/2) % sidePos);
                Console.WriteLine("Dist = {0}", (test2 + shortestTaxi));
            } else
            {
                Console.WriteLine("Max dist = {0}", shortestTaxi);
            }
        }
    }
}
