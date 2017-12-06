using System;
using System.Collections.Generic;

namespace Advent2017
{
    public class Day3 : BaseDay
    {
        public override void Run()
        {
            //Y-Cord is [0], X-Cord is [1]
            int[] position = { 0, 0 };
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
            var doubleCords = Part2(dataGoal, squareSide);
            int shortestTaxi = Convert.ToInt32((squareSide - 1) / 2);
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

            doubleCords[shortestTaxi][shortestTaxi] = 1;
            double starting;
            int xStart;
            int yStart;
            for (double l = 3; l <= dataGoal; l+=2)
            {
                starting = Math.Pow(l - 2, 2) + 1;
                xStart = Convert.ToInt32((l - 1) / 2)+ shortestTaxi;
                yStart = xStart - (Convert.ToInt32(l)-2);
                if (l * l < dataGoal)
                {
                    doubleCords = Navigate(starting, l * l, l, doubleCords, xStart, yStart, dataGoal);
                } else
                {
                    doubleCords = Navigate(starting, dataGoal, l, doubleCords, xStart, yStart, dataGoal);
                }
                
            }

            var test = doubleCords[(position[1] + shortestTaxi)][(position[0] + shortestTaxi)];
            Console.WriteLine(test);
        }

        public List<List<double>> Navigate (double currentStep, double finalStep, double sideLength, List<List<double>> coord, int startX, int startY, double input)
        {
            double currentStepValue = 0;
            while (currentStep <= finalStep)
            {
                for (double u = 1; u < sideLength - 1 && currentStep < finalStep; u++)
                {
                    if (coord[startX][startY] == 0)
                    {
                        if (startX - 1 > 0)
                        {
                            currentStepValue += coord[startX - 1][startY];

                            if (startY - 1 > 0)
                            {
                                currentStepValue += coord[startX - 1][startY - 1];
                            }

                            if (startY + 1 < coord.Count)
                            {
                                currentStepValue += coord[startX -1][startY + 1];
                            }
                        }

                        if (startX + 1 < coord.Count)
                        {
                            currentStepValue += coord[startX + 1][startY];

                            if (startY - 1 > 0)
                            {
                                currentStepValue += coord[startX - 1][startY - 1];
                            }

                            if (startY + 1 < coord.Count)
                            {
                                currentStepValue += coord[startX - 1][startY + 1];
                            }
                        }

                        if (startY - 1 > 0)
                        {
                            currentStepValue += coord[startX][startY - 1];
                        } 

                        if (startY + 1 < coord.Count)
                        {
                            currentStepValue += coord[startX][startY + 1];
                        }

                        coord[startX][startY] += currentStepValue;

                        if (currentStepValue > input)
                        {
                            Console.WriteLine("Value over input: {0}", currentStepValue);
                            Console.ReadKey();
                            return coord;
                        }

                        currentStepValue = 0;
                    }
                    startY++;
                    currentStep++;
                }

                for (double l = 0; l < sideLength - 1 && currentStep < finalStep; l++)
                {

                    if (coord[startX][startY] == 0)
                    {
                        if (startX - 1 > 0)
                        {
                            currentStepValue += coord[startX - 1][startY];

                            if (startY - 1 > 0)
                            {
                                currentStepValue += coord[startX - 1][startY - 1];
                            }

                            if (startY + 1 < coord.Count)
                            {
                                currentStepValue += coord[startX - 1][startY + 1];
                            }
                        }

                        if (startX + 1 < coord.Count)
                        {
                            currentStepValue += coord[startX + 1][startY];

                            if (startY - 1 > 0)
                            {
                                currentStepValue += coord[startX - 1][startY - 1];
                            }

                            if (startY + 1 < coord.Count)
                            {
                                currentStepValue += coord[startX - 1][startY + 1];
                            }
                        }

                        if (startY - 1 > 0)
                        {
                            currentStepValue += coord[startX][startY - 1];
                        }

                        if (startY + 1 < coord.Count)
                        {
                            currentStepValue += coord[startX][startY + 1];
                        }

                        coord[startX][startY] += currentStepValue;

                        if (currentStepValue > input)
                        {
                            Console.WriteLine("Value over input: {0}", currentStepValue);
                            Console.ReadKey();
                            return coord;
                        }

                        currentStepValue = 0;
                    }
                    startX--;
                    currentStep++;
                }

                for (double d = 0; d < sideLength - 1 && currentStep < finalStep; d++)
                {

                    if (coord[startX][startY] == 0)
                    {
                        if (startX - 1 > 0)
                        {
                            currentStepValue += coord[startX - 1][startY];

                            if (startY - 1 > 0)
                            {
                                currentStepValue += coord[startX - 1][startY - 1];
                            }

                            if (startY + 1 < coord.Count)
                            {
                                currentStepValue += coord[startX - 1][startY + 1];
                            }
                        }

                        if (startX + 1 < coord.Count)
                        {
                            currentStepValue += coord[startX + 1][startY];

                            if (startY - 1 > 0)
                            {
                                currentStepValue += coord[startX - 1][startY - 1];
                            }

                            if (startY + 1 < coord.Count)
                            {
                                currentStepValue += coord[startX - 1][startY + 1];
                            }
                        }

                        if (startY - 1 > 0)
                        {
                            currentStepValue += coord[startX][startY - 1];
                        }

                        if (startY + 1 < coord.Count)
                        {
                            currentStepValue += coord[startX][startY + 1];
                        }

                        coord[startX][startY] += currentStepValue;

                        if (currentStepValue > input)
                        {
                            Console.WriteLine("Value over input: {0}", currentStepValue);
                            Console.ReadKey();
                            return coord;
                        }

                        currentStepValue = 0;
                    }
                    startY--;
                    currentStep++;
                }

                for (double r = 0; r < sideLength - 1 && currentStep < finalStep; r++)
                {

                    if (coord[startX][startY] == 0)
                    {
                        if (startX - 1 > 0)
                        {
                            currentStepValue += coord[startX - 1][startY];

                            if (startY - 1 > 0)
                            {
                                currentStepValue += coord[startX - 1][startY - 1];
                            }

                            if (startY + 1 < coord.Count)
                            {
                                currentStepValue += coord[startX - 1][startY + 1];
                            }
                        }

                        if (startX + 1 < coord.Count)
                        {
                            currentStepValue += coord[startX + 1][startY];

                            if (startY - 1 > 0)
                            {
                                currentStepValue += coord[startX - 1][startY - 1];
                            }

                            if (startY + 1 < coord.Count)
                            {
                                currentStepValue += coord[startX - 1][startY + 1];
                            }
                        }

                        if (startY - 1 > 0)
                        {
                            currentStepValue += coord[startX][startY - 1];
                        }

                        if (startY + 1 < coord.Count)
                        {
                            currentStepValue += coord[startX][startY + 1];
                        }

                        coord[startX][startY] += currentStepValue;

                        if (currentStepValue > input)
                        {
                            var test = coord[startX][startY];
                            Console.WriteLine("Value over input: {0}  At: {1}, {2}", currentStepValue, startX, startY);
                            Console.ReadKey();
                            return coord;
                        }

                        currentStepValue = 0;
                    }
                    startX++;
                    currentStep++;
                }

                currentStep++;
            }

            if (startX < coord.Count && startY < coord.Count && startX >= 0 && startY >= 0 && coord[startX][startY] == 0)
            {
                if (startX - 1 > 0)
                {
                    currentStepValue += coord[startX - 1][startY];

                    if (startY - 1 > 0)
                    {
                        currentStepValue += coord[startX - 1][startY - 1];
                    }

                    if (startY + 1 < coord.Count)
                    {
                        currentStepValue += coord[startX - 1][startY + 1];
                    }
                }

                if (startX + 1 < coord.Count)
                {
                    currentStepValue += coord[startX + 1][startY];

                    if (startY - 1 > 0)
                    {
                        currentStepValue += coord[startX - 1][startY - 1];
                    }

                    if (startY + 1 < coord.Count)
                    {
                        currentStepValue += coord[startX - 1][startY + 1];
                    }
                }

                if (startY - 1 > 0)
                {
                    currentStepValue += coord[startX][startY - 1];
                }

                if (startY + 1 < coord.Count)
                {
                    currentStepValue += coord[startX][startY + 1];
                }

                coord[startX][startY] += currentStepValue;

                if (currentStepValue > input)
                {
                    Console.WriteLine("Value over input: {0}", currentStepValue);
                    Console.ReadKey();
                    return coord;
                }

                currentStepValue = 0;
            }

            return coord;
        }

        public List<List<double>> Part2(double lastInt, double squareSide)
        {
            List<List<double>> cords = new List<List<double>>();
            double range = (squareSide - 1) / 2;
            for (double r = range*-1; r <= range; r++)
            {
                List<double> yCords = new List<double>();
                for (double y = range * -1; y <= range; y++)
                {
                    yCords.Add(0);
                }
                cords.Add(yCords);
            }
            return cords;
        }
    }
}
