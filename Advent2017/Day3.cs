using System;
using System.Collections.Generic;

namespace Advent2017
{
    public class Day3 : BaseDay
    {
        List<List<double>> doubleCords;
        int[,] position;

        public override void Run()
        {
            //Y-Cord is [0], X-Cord is [1]
            var day3Input = GetDayInput(3);
            position = new int[,] { { 0, 0 }, { 0, 0 } };
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
            BuildDoubleCords(dataGoal, squareSide);
            int shortestTaxi = Convert.ToInt32((squareSide - 1) / 2);
            position[0,0] = 1;
            position[0, 1] = 0;

            doubleCords[shortestTaxi][shortestTaxi] = 1;
            double starting;
            int xStart;
            int yStart;
            for (double l = 3; l <= squareSide; l += 2)
            {
                starting = Math.Pow(l - 2, 2) + 1;
                xStart = Convert.ToInt32((l - 1) / 2) + shortestTaxi;
                yStart = xStart - (Convert.ToInt32(l) - 2);
                if (l < squareSide)
                {
                    Navigate(starting, l * l, l, xStart, yStart, dataGoal);
                }
                else
                {
                    Navigate(starting, dataGoal, l, xStart, yStart, dataGoal);
                }

            }

            var dist = Math.Abs(position[0, 0]) + Math.Abs(position[0, 1]);
            Console.WriteLine("Distince to start node: {0}", dist);

             Console.WriteLine("First Square Value greater than input: {0}", doubleCords[(position[1, 0])][(position[1, 1])]);
        }

        public void Navigate (double currentStep, double finalStep, double sideLength, int startX, int startY, double input)
        {
            double currentStepValue = 0;
            while (currentStep <= finalStep)
            {
                if (startX < doubleCords.Count && startY < doubleCords.Count && startX >= 0 && startY >= 0 && doubleCords[startX][startY] == 0)
                {
                    currentStepValue = valueCheck(startX, startY);

                    doubleCords[startX][startY] += currentStepValue;

                    if (currentStepValue > input && position[1,0] == 0 && position[1,1] == 0)
                    {
                        position[1, 0] = startX;
                        position[1, 1] = startY;
                    }

                    currentStepValue = 0;
                }

                for (double u = 1; u < sideLength - 1 && currentStep < finalStep; u++)
                {   
                    if (doubleCords[startX][startY] == 0)
                    {
                        currentStepValue = valueCheck(startX, startY);

                        doubleCords[startX][startY] += currentStepValue;

                        if (currentStepValue > input && position[1, 0] == 0 && position[1, 1] == 0)
                        {
                            position[1, 0] = startX;
                            position[1, 1] = startY;
                        }
                    }
                    currentStepValue = 0;

                    startY++;
                    if (currentStep < input)
                    {
                        position[0, 1]++;
                    }
                    currentStep++;
                }

                for (double l = 0; l < sideLength - 1 && currentStep < finalStep; l++)
                {

                    if (doubleCords[startX][startY] == 0)
                    {
                        currentStepValue = valueCheck(startX, startY);

                        doubleCords[startX][startY] += currentStepValue;

                        if (currentStepValue > input && position[1, 0] == 0 && position[1, 1] == 0)
                        {
                            position[1, 0] = startX;
                            position[1, 1] = startY;
                        }
                    }
                    currentStepValue = 0;
                    startX--;
                    if (currentStep < input)
                    {
                        position[0, 0]--;
                    }
                    currentStep++;
                }

                for (double d = 0; d < sideLength - 1 && currentStep < finalStep; d++)
                {

                    if (doubleCords[startX][startY] == 0)
                    {
                        currentStepValue = valueCheck(startX, startY);

                        doubleCords[startX][startY] += currentStepValue;

                        if (currentStepValue > input && position[1, 0] == 0 && position[1, 1] == 0)
                        {
                            position[1, 0] = startX;
                            position[1, 1] = startY;
                        }
                    }
                    currentStepValue = 0;
                    startY--;
                    if (currentStep < input)
                    {
                        position[0, 1]--;
                    }
                    currentStep++;
                }

                for (double r = 0; r < sideLength - 1 && currentStep < finalStep; r++)
                {

                    if (doubleCords[startX][startY] == 0)
                    {
                        currentStepValue = valueCheck(startX, startY);

                        doubleCords[startX][startY] += currentStepValue;

                        if (currentStepValue > input && position[1, 0] == 0 && position[1, 1] == 0)
                        {
                            position[1, 0] = startX;
                            position[1, 1] = startY;
                        }
                    }
                    currentStepValue = 0;
                    startX++;
                    if (currentStep < input)
                    {
                        position[0, 0]++;
                    }
                    currentStep++;
                }

                currentStep++;
            }

            if (startX < doubleCords.Count && startY < doubleCords.Count && startX >= 0 && startY >= 0 && doubleCords[startX][startY] == 0)
            {
                currentStepValue = valueCheck(startX, startY);

                doubleCords[startX][startY] += currentStepValue;

                if (currentStepValue > input && position[1, 0] == 0 && position[1, 1] == 0)
                {
                    position[1, 0] = startX;
                    position[1, 1] = startY;
                }

                currentStepValue = 0;
            }

            if (currentStep < input)
            {
                position[0, 0]++;
            }
            currentStepValue = 0;
        }

        public double valueCheck(int xCord, int yCord)
        {
            double currentStepValue = 0;
            if (xCord - 1 > 0)
            {
                currentStepValue += doubleCords[xCord - 1][yCord];

                if (yCord - 1 > 0)
                {
                    currentStepValue += doubleCords[xCord - 1][yCord - 1];
                }

                if (yCord + 1 < doubleCords.Count)
                {
                    currentStepValue += doubleCords[xCord - 1][yCord + 1];
                }
            }

            if (xCord + 1 < doubleCords.Count)
            {
                currentStepValue += doubleCords[xCord + 1][yCord];

                if (yCord - 1 > 0)
                {
                    currentStepValue += doubleCords[xCord + 1][yCord - 1];
                }

                if (yCord + 1 < doubleCords.Count)
                {
                    currentStepValue += doubleCords[xCord + 1][yCord + 1];
                }
            }

            if (yCord - 1 > 0)
            {
                currentStepValue += doubleCords[xCord][yCord - 1];
            }

            if (yCord + 1 < doubleCords.Count)
            {
                currentStepValue += doubleCords[xCord][yCord + 1];
            }

            var finalStepValue = currentStepValue;

            currentStepValue = 0;
            return finalStepValue;
        }

        public void BuildDoubleCords(double lastInt, double squareSide)
        {
            doubleCords = new List<List<double>>();
            double range = (squareSide - 1) / 2;
            for (double r = range*-1; r <= range; r++)
            {
                List<double> yCords = new List<double>();
                for (double y = range * -1; y <= range; y++)
                {
                    yCords.Add(0);
                }
                doubleCords.Add(yCords);
            }
        }
    }
}
