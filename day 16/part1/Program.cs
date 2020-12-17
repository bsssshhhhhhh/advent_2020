using System;
using AdventCommon;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = ConsoleHelpers.ReadInput();
            var parts = string.Join("\n", lines).Split("\n\n");
            var ruleRegex = new Regex(@"(.*): (\d+)-(\d+) or (\d+)-(\d+)");
            var rules = parts[0].Split('\n').Select((line) => {
                var match = ruleRegex.Match(line);

                var ruleName = match.Groups[1].Value;
                var firstRange = new Range(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value));
                var secondRange = new Range(int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value));

                return new[] { firstRange, secondRange };
            })
            .Aggregate(new List<Range>(), (accum, ruleTuple) => {
                return accum.Concat(ruleTuple).ToList();
            })
            
            .ToArray();

            var myTicket = parts[1].Split('\n').Skip(1).First().Split(',').Select(int.Parse).ToArray();
            var nearbyTickets = parts[2].Split('\n').Skip(1).Select((line) => line.Split(',').Select(int.Parse).ToArray()).ToArray();

            Console.WriteLine(nearbyTickets.Sum((ticket) => InvalidValues(ticket, rules)));
        }

        static int InvalidValues(int[] ticket, Range[] rules)
        {
            return ticket.Sum((num) => {
                var valid = rules.Any((rule) => num >= rule.Start.Value && num <= rule.End.Value);
                return valid ? 0 : num;
            });
        }
    }
}
