using System;
using System.Text.RegularExpressions;
using AdventCommon;
using System.Collections.Generic;
using System.Linq;

namespace day_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var entries = ConsoleHelpers.ReadAllLines().Select(PasswordEntry.Parse);
            Console.WriteLine(entries.Count(IsPasswordValid));
        }

        public class PasswordEntry
        {
            public int Min { get; set; }
            public int Max { get; set; }
            public char Character { get; set; }
            public string Password { get; set; }

            public static PasswordEntry Parse(string str)
            {
                var match = Regex.Match(str, @"^(\d+)-(\d+) (\w): (.*)$");

                if (match == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(str));
                }

                return new PasswordEntry
                {
                    Min = int.Parse(match.Groups[1].Value),
                    Max = int.Parse(match.Groups[2].Value),
                    Character = match.Groups[3].Value[0],
                    Password = match.Groups[4].Value
                };
            }
        }

        static bool IsPasswordValid(PasswordEntry entry)
        {
            var count = entry.Password.Count(c => c == entry.Character);
            return entry.Min <= count && entry.Max >= count;
        }
    }
}
