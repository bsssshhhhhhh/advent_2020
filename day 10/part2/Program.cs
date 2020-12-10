using System;
using AdventCommon;
using System.Linq;
using System.Collections.Generic;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var adapterJoltages = ConsoleHelpers
                .ReadInput()
                .Select(int.Parse)
                .ToList();
            
            adapterJoltages.Add(adapterJoltages.Max() + 3);
            adapterJoltages.Add(0);
            adapterJoltages.Sort();

            var answer = Enumerable
                .Range(0, adapterJoltages.Count - 1)
                .Reverse()
                .ToList()
                .Aggregate(
                    new Dictionary<int, long> { [adapterJoltages.Count - 1] = 1 },
                    (connections, i) => {
                        connections[i] = Enumerable
                            .Range(i + 1, adapterJoltages.Count - i - 1)
                            .TakeWhile(j => adapterJoltages[j] - adapterJoltages[i] <= 3)
                            .Aggregate(0L, (acc, j) => acc + connections[j]);

                        return connections;
                    }
                )
                .GetValueOrDefault(0);

            Console.WriteLine(answer);
        }
    }
}
