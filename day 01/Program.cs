using System;
using System.Collections.Generic;
using System.Linq;

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

            var entry1 = entries.Last();
            var entry1Index = entries.Length - 1;

            while (entry1Index > 0)
            {
                for (var entry2Index = 0; entry2Index < entry1Index; entry2Index++)
                {
                    var entry2 = entries[entry2Index];
                    if (entry1 + entry2 == 2020)
                    {
                        PrintAnswer(entry1, entry2);
                        return 0;
                    }
                }

                entry1Index--;
                entry1 = entries[entry1Index];
            }

            return 0;
        }

        static void PrintAnswer(int num1, int num2)
        {
            Console.WriteLine($"num1={num1}, num2={num2}, answer={num1 * num2}");
        }

        static int[] GetExpenseReportEntries()
        {
            // read numbers from stdin
            var nums = new List<int>();

            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                if (!int.TryParse(line, out int num))
                {
                    continue;
                }

                nums.Add(num);
            }

            return nums.ToArray();
        }
    }
}
