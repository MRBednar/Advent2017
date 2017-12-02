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
        

        public async Task<List<string>> GetDayInput(int day)
        {
            List<string> results = new List<string>();
            using (var client = new HttpClient())
            {
                var inputString = await client.GetStreamAsync(String.Format("http://adventofcode.com/2017/day/{0}/input", day));
                using (StreamReader reader = new StreamReader(inputString))
                {
                    results.Add(reader.ReadLine());
                }
                return results;
            }
        }

    }
}