using System;
using System.IO;
using System.Linq;
using AdventCommon;

namespace part1
{
    class Program
    {
        const char TREE = '#';

        static int Main(string[] args)
        {
            var lines = ConsoleHelpers.ReadInput();

            Console.WriteLine(CountTreesAlongSlope(lines, (1 / 3d)));

            return 0;
        }

        static int CountTreesAlongSlope(string[] mountain, double m)
        {
            var treeCount = 0;
            var xMax = mountain[0].Length;
            for (var y = 1; y < mountain.Length; y++)
            {
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
