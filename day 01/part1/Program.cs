using System;
using System.Collections.Generic;
using System.Linq;
using AdventCommon;

namespace day_01
{
    class Program
    {
        static int Main()
        {
            var entries = GetExpenseReportEntries();

            if (entries.Length == 0) 
            {
                return 1;
            }

            
            for (var entry1Index = 0; entry1Index < entries.Length; entry1Index++)
            {
                var entry1 = entries[entry1Index];
                for (var entry2Index = entry1Index; entry2Index < entries.Length; entry2Index++)
                {
                    var entry2 = entries[entry2Index];
                    if (entry1 + entry2 == 2020)
                    {
                        PrintAnswer(entry1, entry2);
                        return 0;
                    }
                }
            }

            return 0;
        }

        static void PrintAnswer(int num1, int num2)
        {
            Console.WriteLine($"num1={num1}, num2={num2}, answer={num1 * num2}");
        }

        static int[] GetExpenseReportEntries()
        {
            return ConsoleHelpers.ReadAllLines().Select(line => int.Parse(line)).ToArray();
        }
    }
}
