using System;
using System.Linq;
using AdventCommon;

namespace part1
{
    class Program
    {
        static int Main(string[] args)
        {
            var lines = ConsoleHelpers.ReadInput();
            var max = lines.Select(GetBoardingPassID).Max();

            Console.WriteLine(max);
            return 0;
        }

        static int GetBoardingPassID(string pass)
        {
            var binaryString = pass
                .Replace('F', '0')
                .Replace('L', '0')
                .Replace('B', '1')
                .Replace('R', '1');
            return Convert.ToInt32(binaryString, 2);
        }
    }
}
