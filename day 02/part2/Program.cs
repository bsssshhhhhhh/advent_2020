using System;
using System.Text.RegularExpressions;
using AdventCommon;
using System.Collections.Generic;
using System.Linq;

namespace day_02
{
    class Program
    {
        static int Main(string[] args)
        {
            var entries = ConsoleHelpers.ReadAllLines().Select(PasswordEntry.Parse);
            Console.WriteLine(entries.Count(IsPasswordValid));
            return 0;
        }

        public class PasswordEntry
        {
            public int Position1 { get; set; }
            public int Position2 { get; set; }
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
                    Position1 = int.Parse(match.Groups[1].Value),
                    Position2 = int.Parse(match.Groups[2].Value),
                    Character = match.Groups[3].Value[0],
                    Password = match.Groups[4].Value
                };
            }
        }

        static bool IsPasswordValid(PasswordEntry entry)
        {
             var firstChar = entry.Password[entry.Position1 - 1];
             var secondChar = entry.Password[entry.Position2 - 1];

             return firstChar != secondChar && (firstChar == entry.Character || secondChar == entry.Character);
        }
    }
}
