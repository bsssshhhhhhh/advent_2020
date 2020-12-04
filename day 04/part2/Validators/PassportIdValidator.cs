using System.Text.RegularExpressions;

namespace part2
{
    public class PassportIdValidator : IPassportValidator
    {
        private static readonly Regex PassportIdRegex = new Regex(@"^\d{9}$");
        public bool Validate(Passport passport)
        {
            var passportId = passport.PassportID;
            if (string.IsNullOrEmpty(passportId))
            {
                return false;
            }

            return PassportIdRegex.IsMatch(passportId);
        }
    }
}