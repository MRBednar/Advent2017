using System;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.Stream;
using System.Collections.Generic;
using System.Net.Http;

namespace Advent2017
{
    public class Day1 : IDay
    {
        public void Run()
        {
            steam inputString = null;
            using (var client = new HttpClient()) {
                inputString = client.GetStreamAsync("adventofcode.com/2017/day/1/input");
            }

        }
    }
}