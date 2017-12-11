using System;
using System.Collections.Generic;

namespace Advent2017
{
    public class Day4 : BaseDay
    {
        public override void Run()
        {
            var day4Input = GetDayInput(4);
            var validCount = 0;
            foreach (string inputRow in day4Input)
            {
                var validPass = true;
                List<string> passphrases = new List<string>(inputRow.Split(' '));

                for (int i=0; i< passphrases.Count; i++)
                {
                    if (passphrases.LastIndexOf(passphrases[i]) > i)
                    {
                        validPass = false;
                        break;
                    }
                }

                if (validPass)
                {
                    validCount++;
                }
            }
            Console.WriteLine("Number of valid pasphrases: {0}", validCount);
        }
    }
}
