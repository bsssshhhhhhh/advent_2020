using System;
using System.Linq;
using System.Collections.Generic;
using AdventCommon;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = ConsoleHelpers
                .ReadInput()
                .Select(long.Parse)
                .ToArray();

            Console.WriteLine(GetEncryptionWeakness(lines, 25));
        }

        static long GetEncryptionWeakness(long[] input, int preambleLength)
        {
            var weakNumber = FindWeakNumber(input, preambleLength);

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 2; j < input.Length - 2; j++)
                {
                    var sub = input.Skip(i).Take(j);
                    var sum = sub.Sum();

                    if (sum == weakNumber)
                    {
                        return sub.Min() + sub.Max();
                    }

                    if (sum > weakNumber)
                    {
                        break;
                    }
                }
            }

            return -1;
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
