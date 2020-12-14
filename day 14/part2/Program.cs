using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventCommon;

namespace part2
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

                var locs = GetAddressLocations(address, mask);
                foreach (var loc in locs)
                {
                    memory[loc] = value;
                }
            }

            Console.WriteLine(memory.Values.Sum());
        }

        static long[] GetAddressLocations(long address, string mask)
        {
            // cba to figure out bitwise math
            var binary = Convert.ToString(address, 2);

            var maskReversed = mask.Reverse().ToArray();
            var addressReversed = string.Join("", binary.PadLeft(36, '0').Reverse()).ToCharArray();

            var xIndices = new List<int>();

            for (var i = 0; i < maskReversed.Length; i++)
            {
                if (maskReversed[i] == '0')
                {
                    continue;
                }

                if (maskReversed[i] == '1')
                {
                    addressReversed[i] = '1';
                    continue;
                }

                if (maskReversed[i] == 'X')
                {
                    xIndices.Add(i);
                }
            }


            var locations = new List<char[]>();
            var possibleCombos = Math.Pow(2, xIndices.Count);
            for (var i = 0; i < possibleCombos; i++)
            {
                var bits = Convert.ToString(i, 2).PadLeft(xIndices.Count, '0');
                var addr = addressReversed.Clone() as char[];
                for (var j = 0; j < bits.Length; j++)
                {
                    addr[xIndices[j]] = bits[j];
                }
                locations.Add(addr);
            }


            return locations.Select(x => Convert.ToInt64(string.Join("", x.Reverse()), 2)).Distinct().ToArray();
        }
    }
}
