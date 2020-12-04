using System;
using AdventCommon;
using System.Linq;
using System.Text.RegularExpressions;

namespace part1
{
    class Program
    {
        private const string FIELD_PATTERN = @"(\w{3}):(.*?)(?:\s|$)";


        static void Main(string[] args)
        {
            var inputs = string.Join("\n", ConsoleHelpers.ReadInput()).Split("\n\n");

            var answer = inputs.Select(Passport.Parse).Count(p => p.Validate());
            Console.WriteLine(answer);
        }

        public class Passport
        {
            public string BirthYear { get; set; }
            public string IssueYear { get; set; }
            public string ExpirationYear { get; set; }
            public string Height { get; set; }
            public string HairColor { get; set; }
            public string EyeColor { get; set; }
            public string PassportID { get; set; }
            public string CountryID { get; set; }

            public bool Validate()
            {
                var nonNulls = new string[]
                {
                    BirthYear,
                    IssueYear,
                    ExpirationYear,
                    Height,
                    HairColor,
                    EyeColor,
                    PassportID
                };

                return nonNulls.All(field => !string.IsNullOrEmpty(field));
            }

            public static Passport Parse(string str)
            {
                var fieldRegex = new Regex(FIELD_PATTERN, RegexOptions.Multiline);
                var fields = fieldRegex.Matches(str);
                var passport = new Passport();

                for (var i = 0; i < fields.Count; i++)
                {
                    var key = fields[i].Groups[1].Value;
                    var value = fields[i].Groups[2].Value;

                    switch(key)
                    {
                        case "byr": passport.BirthYear = value; break;
                        case "iyr": passport.IssueYear = value; break;
                        case "eyr": passport.ExpirationYear = value; break;
                        case "hgt": passport.Height = value; break;
                        case "hcl": passport.HairColor = value; break;
                        case "ecl": passport.EyeColor = value; break;
                        case "pid": passport.PassportID = value; break;
                        case "cid": passport.CountryID = value; break;
                    }
                }

                return passport;
            }
        }
    }
}
