using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventCommon;

namespace part1
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
                            Contents = Array.Empty<string>()
                        };
                    }

                    return new Bag
                    {
                        Color = parts[0],
                        Contents = matches.Select(m => m.Groups[2].Value).ToArray()
                    };
                })
                .ToDictionary(f => f.Color, f => f.Contents);

                Console.WriteLine(bagDefs.Count(x => HasShinyGold(x.Key, bagDefs)));
        }

        public class Bag
        {
            public string Color { get; set; }
            public string[] Contents { get; set; }
        }

        static bool HasShinyGold(string color, Dictionary<string, string[]> defs)
        {
            if (!defs.ContainsKey(color))
            {
                return false;
            }
    
            if (defs[color].Any(d => d == "shiny gold"))
            {
                return true;
            }

            return defs[color].Any(d => HasShinyGold(d, defs));
        }
    }
}
