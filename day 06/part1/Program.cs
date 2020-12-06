using System;
using AdventCommon;
using System.Linq;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var answer = string
                .Join("\n", ConsoleHelpers.ReadInput())
                .Split("\n\n")
                .Select(x => x
                    .Replace("\n", "")
                    .Distinct()
                    .Count())
                .Aggregate(0, (prev, cur) => prev + cur);


            Console.WriteLine(answer);
        }
    }
}
