using System;
using System.Linq;
using AdventCommon;

namespace part2
{
    class Program
    {
        const char TREE = '#';
        static int Main(string[] args)
        {
            var lines = ConsoleHelpers.ReadInput();

            var slopes = new double[]
            {
                1,
                1 / 3d,
                1 / 5d,
                1 / 7d,
                2
            };

            var answer = slopes
                .Select(m => CountTreesAlongSlope(lines, m))
                .Aggregate(1UL, (prev, cur) => prev * cur);


            Console.WriteLine(answer);

            return 0;
        }

        static ulong CountTreesAlongSlope(string[] mountain, double m)
        {
            var treeCount = 0UL;
            var xMax = mountain[0].Length;
            for (var y = 0; y < mountain.Length; y++)
            {
                // if the slope is >1, make sure not to count rows
                // that should be skipped
                if (m > 1 && y % m != 0)
                {
                    continue;
                }

                var x = (int) Math.Floor(y / m);
                
                while (x >= xMax)
                {
                    x -= xMax;
                }

                
                if (mountain[y][x] == TREE)
                {
                    treeCount++;
                }
            }


            return treeCount;
        }
    }
}
