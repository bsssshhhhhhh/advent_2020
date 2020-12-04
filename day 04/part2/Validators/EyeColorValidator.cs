using System.Linq;

namespace part2
{
    public class EyeColorValidator : IPassportValidator
    {
        private static readonly string[] ValidValues = new string[]
        {
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth"
        };

        public bool Validate(Passport passport)
        {
            var eyeColor = passport.EyeColor;
            if (string.IsNullOrEmpty(eyeColor))
            {
                return false;
            }

            return ValidValues.Any(clr => clr == eyeColor);
        }
    }
}