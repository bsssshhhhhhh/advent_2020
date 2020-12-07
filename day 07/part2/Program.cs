using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventCommon;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var bagDefRegex = new Regex(@"(\d+) (.*?) bags?[,.]");
            var lines = ConsoleHelpers.ReadInput();
            var bagDefs = lines
                .Select(line =>
                {
                    var parts = line.Split(" bags contain ");
                    var matches = bagDefRegex.Matches(parts[1]);

                    if (matches.Count == 0)
                    {
                        return new Bag
                        {
                            Color = parts[0],
                            Contents = null
                        };
                    }

                    return new Bag
                    {
                        Color = parts[0],
                        Contents = matches.ToDictionary(x => x.Groups[2].Value, x => int.Parse(x.Groups[1].Value))
                    };
                })
                .ToDictionary(f => f.Color, f => f.Contents);

                Console.WriteLine(CountBagsInside("shiny gold", bagDefs));
        }

        public class Bag
        {
            public string Color { get; set; }
            public Dictionary<string, int> Contents { get; set; }
        }

        static int CountBagsInside(string color, Dictionary<string, Dictionary<string, int>> defs)
        {
            if (defs[color] == null)
            {
                return 0;
            }

            return defs[color].Sum(x => x.Value + (x.Value * CountBagsInside(x.Key, defs)));
        }
    }
}
