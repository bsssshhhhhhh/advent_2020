using System;
using AdventCommon;
using System.Linq;
using System.Collections.Generic;

namespace part1
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
            
            var differences = new List<int>();
            for (var i = 0; i < adapterJoltages.Count - 1; i++)
            {
                differences.Add(adapterJoltages[i + 1] - adapterJoltages[i]);
            }


            Console.WriteLine(differences.Count(x => x == 1) * differences.Count(x => x == 3));
        }
    }
}
