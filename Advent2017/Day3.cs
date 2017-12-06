using System;
using System.Collections.Generic;

namespace Advent2017
{
    public class Day3 : BaseDay
    {
        public override void Run()
        {
            var pos = new List<Coord>();
            //Y-Cord is [0], X-Cord is [1]
            double[] position = { 0, 0 };
            var day3Input = GetDayInput(3);
            double dataGoal = Double.Parse(day3Input[0]);
            if (dataGoal == 1)
            {
                Console.WriteLine("Input is 1, so dist = 0");
            }
            double squareSide = Math.Ceiling(Math.Sqrt(dataGoal));
            if (squareSide % 2 == 0)
            {
                squareSide++;
            }
            double shortestTaxi = (squareSide - 1) / 2;
            position[0] = (shortestTaxi - 1) * -1;
            position[1] = shortestTaxi;
            double startNumber = Math.Pow(squareSide - 2, 2) + 1;

            double c = startNumber;
            while (c <= dataGoal)
            {
                for (double u = 1; u < squareSide - 1 && c < dataGoal; u++)
                {
                    position[0]++;
                    c++;
                }

                for (double l = 0; l < squareSide - 1 && c < dataGoal; l++)
                {
                    position[1]--;
                    c++;
                }

                for (double d = 0; d < squareSide - 1 && c < dataGoal; d++)
                {
                    position[0]--;
                    c++;
                }

                for (double r = 0; r < squareSide - 1 && c < dataGoal; r++)
                {
                    position[1]++;
                    c++;
                }
                c++;
            }

            var dist = Math.Abs(position[0]) + Math.Abs(position[1]);
            Console.WriteLine("Distince to start node: {0}", dist);
        }
    }

    public class Coord
    {
        public int XCord { get; set; }
        public int YCord { get; set; }
        public double value { get; set; }
    }
}
