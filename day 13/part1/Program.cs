using System;
using System.Linq;
using AdventCommon;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = ConsoleHelpers.ReadInput();
            var timestamp = int.Parse(lines[0]);
            var buses = lines[1]
                .Split(",")
                .Where(id => id != "x")
                .Select(x => (int?)int.Parse(x));

            for (var i = timestamp;;i++)
            {
                var bus = buses.FirstOrDefault(x => i % x.Value == 0);
                if (bus.HasValue)
                {
                    Console.WriteLine(bus.Value * (i - timestamp));
                    break;
                }
            }
        }
    }
}
