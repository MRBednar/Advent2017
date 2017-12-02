using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Advent2017
{
    public abstract class BaseDay : IDay
    {
        public abstract void Run();
        

        public List<string> GetDayInput(int day)
        {
            List<string> results = new List<string>();
            using (StreamReader sr = new StreamReader(String.Format("inputs/day{0}.txt", day)))
            {
                while (sr.Peek() >= 0)
                {
                    results.Add(sr.ReadLine());
                }
            }
            return results;
        }

    }
}