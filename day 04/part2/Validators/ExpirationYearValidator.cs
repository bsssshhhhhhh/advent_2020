namespace part2
{
    public class ExpirationYearValidator : IPassportValidator
    {
        public bool Validate(Passport passport)
        {
            var expirationYear = passport.ExpirationYear;
            if (string.IsNullOrEmpty(expirationYear))
            {
                return false;
            }

            if (expirationYear.Length != 4)
            {
                return false;
            }

            if (!int.TryParse(expirationYear, out int year))
            {
                return false;
            }

            return year >= 2020 && year <= 2030;
        }
    }
}