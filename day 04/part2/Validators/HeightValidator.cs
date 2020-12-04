using System.Text.RegularExpressions;

namespace part2
{
    public class HeightValidator : IPassportValidator
    {
        private static readonly Regex HeightRegex = new Regex(@"^(\d+)(in|cm)$");
        public bool Validate(Passport passport)
        {
            var height = passport.Height;

            if (string.IsNullOrEmpty(height))
            {
                return false;
            }

            var match = HeightRegex.Match(height);
            if (!HeightRegex.IsMatch(height))
            {
                return false;
            }

            var num = int.Parse(match.Groups[1].Value);
            var units = match.Groups[2].Value;

            return units switch
            {
                // i guess short people and tall people are illegal ?
                "in" => num >= 59 && num <= 76,
                "cm" => num >= 150 && num <= 193,
                _ => false,
            };
        }
    }
}