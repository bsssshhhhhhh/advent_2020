using System;
using System.Collections.Generic;
using System.Linq;
using AdventCommon;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = ConsoleHelpers.ReadInput();

            int answer = 0;
            var visitedInstructions = new List<int>();
            for (var i = 0; i < lines.Length; i++)
            {
                if (visitedInstructions.Contains(i))
                {
                    break;
                }

                visitedInstructions.Add(i);

                var parts = lines[i].Split(" ");
                var instruction = parts[0];
                var arg = int.Parse(parts[1]);

                if (instruction == "nop")
                {
                    continue;
                }

                if (instruction == "jmp")
                {
                    i += arg - 1;
                }

                if (instruction == "acc")
                {
                    answer += arg;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
