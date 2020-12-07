using System;
using System.Linq;
using AdventCommon;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var answer = string
                .Join("\n", ConsoleHelpers.ReadInput())
                .Split("\n\n")
                .Select(x => {
                    var lines = x.Split("\n");
                    var remaining = lines[0];

                    if (lines.Length > 1) 
                    {
                        for (var i = 1; i < lines.Length; i++)
                        {
                            var line = lines[i];
                            foreach (var q in remaining)
                            {
                                if (!line.Contains(q))
                                {
                                    remaining = remaining.Replace($"{q}", string.Empty);
                                }
                            }
                        }
                    }

                    return remaining.Length;
                })
                .Sum();


            Console.WriteLine(answer);
        }
    }
}
