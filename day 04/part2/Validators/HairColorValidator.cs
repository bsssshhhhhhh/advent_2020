using System.Text.RegularExpressions;

namespace part2
{
    public class HairColorValidator : IPassportValidator
    {
        private static readonly Regex hairColorRegex = new Regex(@"^#[0-9a-fA-F]{6}$");
        public bool Validate(Passport passport)
        {
            var hairColor = passport.HairColor;

            if (string.IsNullOrEmpty(hairColor))
            {
                return false;
            }

            return hairColorRegex.IsMatch(hairColor);
        }
    }
}