using System;
using System.Linq;
using System.Collections.Generic;
using AdventCommon;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = ConsoleHelpers
                .ReadInput()
                .Select(long.Parse)
                .ToArray();

            Console.WriteLine(FindWeakNumber(lines, 25));
        }

        static long FindWeakNumber(long[] input, int preambleLength)
        {
            for (var i = preambleLength; i < input.Length; i++)
            {
                var nums = input
                    .Skip(i - preambleLength)
                    .Take(preambleLength)
                    .ToArray();

                var sums = GetSums(nums);

                if (!sums.Contains(input[i]))
                {
                    return input[i];
                }
            }

            return -1;
        }

        static long[] GetSums(long[] input)
        {
            var sums = new List<long>();
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    sums.Add(input[j] + input[i]);
                }
            }

            return sums.ToArray();
        }
    }
}
