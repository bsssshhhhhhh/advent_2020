using System;
using System.Collections.Generic;
using System.Linq;
using AdventCommon;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = ConsoleHelpers.ReadInput();
            var mutations = Mutate(lines);
            
            foreach (var mutation in mutations)
            {
                var answer = RunBootCode(mutation);

                if (answer.HasValue)
                {
                    Console.WriteLine(answer);
                    break;
                }
            }
        }

        static IEnumerable<string[]> Mutate(string[] lines)
        {
            var replacements = new Dictionary<string, string>
            {
                {"nop", "jmp"},
                {"jmp", "nop"}
            };
            // build mutated versions of the program
            for (var i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split(" ");

                if (!replacements.ContainsKey(parts[0]))
                {
                    continue;
                }

                var clone = lines.Clone() as string[];
                clone[i] = $"{replacements[parts[0]]} {parts[1]}";

                yield return clone;
            }
        }

        static int? RunBootCode(string[] code)
        {
            int answer = 0;
            var visitedInstructions = new List<int>();
            for (var i = 0; i < code.Length; i++)
            {
                if (visitedInstructions.Contains(i))
                {
                    return null;
                }

                visitedInstructions.Add(i);

                var parts = code[i].Split(" ");
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

            return answer;
        }
    }
}
