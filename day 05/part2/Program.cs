using System;
using AdventCommon;
using System.Collections.Generic;
using System.Linq;
namespace part2
{
    class Program
    {
        static int Main(string[] args)
        {
            var lines = ConsoleHelpers.ReadInput();
            var ids = lines.Select(GetBoardingPassID);
            Console.WriteLine(FindMyBoardingPassID(ids));
            
            return 0;
        }

        static int FindMyBoardingPassID(IEnumerable<int> ids)
        {
            var idList = ids.ToList();
            idList.Sort();

            for (var i = 0; i < idList.Count - 1; i++)
            {
                if (idList[i] + 2 == idList[i + 1])
                {
                    return idList[i] + 1;
                }
            }

            return -1;
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
