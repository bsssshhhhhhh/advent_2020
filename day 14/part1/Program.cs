using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventCommon;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = ConsoleHelpers.ReadInput();
            var mask = string.Join("", Enumerable.Range(1, 36).Select(x => "X"));
            var memory = new Dictionary<long, long>();
            
            var memAssignmentRegex = new Regex(@"mem\[(\d+)\] = (\d+)$");
            foreach (var line in lines)
            {
                if (line.StartsWith("mask = "))
                {
                    mask = line.Split("mask = ")[1];
                    continue;
                }

                var match = memAssignmentRegex.Match(line);
                var address = long.Parse(match.Groups[1].Value);
                var value = long.Parse(match.Groups[2].Value);

                memory[address] = ApplyMask(value, mask);
            }

            Console.WriteLine(memory.Values.Sum());
        }

        static long ApplyMask(long value, string mask)
        {
            // cba to figure out bitwise math
            var binary = Convert.ToString(value, 2);

            var maskReversed = mask.Reverse().ToArray();
            var addressReversed = string.Join("", binary.PadLeft(36, '0').Reverse()).ToCharArray();

            for (var i = 0; i < maskReversed.Length; i++)
            {
                if (maskReversed[i] == 'X')
                {
                    continue;
                }
                
                addressReversed[i] = maskReversed[i];
            }

            return Convert.ToInt64(string.Join("", addressReversed.Reverse()), 2);
        }
    }
}
