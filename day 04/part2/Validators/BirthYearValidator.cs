namespace part2
{
    public class BirthYearValidator : IPassportValidator
    {
        public bool Validate(Passport passport)
        {
            var birthYear = passport.BirthYear;
            if (string.IsNullOrEmpty(birthYear))
            {
                return false;
            }

            if (birthYear.Length != 4)
            {
                return false;
            }

            if (!int.TryParse(birthYear, out int year))
            {
                return false;
            }

            return year >= 1920 && year <= 2002;
        }
    }
}