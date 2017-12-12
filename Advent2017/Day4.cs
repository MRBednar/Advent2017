using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2017
{
    public class Day4 : BaseDay
    {
        public override void Run()
        {
            var day4Input = GetDayInput(4);
            var validCount = 0;
            var sortedCount = 0;
            foreach (string inputRow in day4Input)
            {
                var validPass = true;
                var sortedPass = true;
                var passphrases = new List<string>(inputRow.Split(' '));
                var sortedPassphrases = new List<string>();

                foreach (string password in passphrases)
                {
                    var passwordList = password.ToList();
                    passwordList.Sort();
                    sortedPassphrases.Add(String.Join("", passwordList.ToArray()));
                }

                for (int i=0; i< passphrases.Count; i++)
                {
                    if (passphrases.LastIndexOf(passphrases[i]) > i)
                    {
                        validPass = false;
                        sortedPass = false;
                        break;
                    }

                    if (sortedPassphrases.LastIndexOf(sortedPassphrases[i]) > i)
                    {
                        sortedPass = false;
                    }
                }

                if (validPass)
                {
                    validCount++;
                }

                if (sortedPass)
                {
                    sortedCount++;
                }
            }
            Console.WriteLine("Number of valid passphrases: {0}", validCount);
            Console.WriteLine("Number of valid sorted passphrases: {0}", sortedCount);
        }
    }
}
