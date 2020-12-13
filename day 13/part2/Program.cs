using System;
using AdventCommon;
using System.Linq;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = ConsoleHelpers.ReadInput();
            var buses = lines[1]
                .Split(",")
                .ToArray();

            var product = 1L;
            var timestamp = 100000000000000L;

            for (var i = 0L; i < buses.Length; i++)
            {
                if (buses[i] == "x")
                {
                    continue;
                }

                var bus = int.Parse(buses[i]);

                if ((timestamp + i) % bus == 0)
                {
                    product *= bus;
                }
                else
                {
                    timestamp += product;
                    i--;
                }
            }

            Console.WriteLine(timestamp);
        }
    }
}
