namespace part2
{
    public class IssueYearValidator : IPassportValidator
    {
        public bool Validate(Passport passport)
        {
            var issueYear = passport.IssueYear;
            if (string.IsNullOrEmpty(issueYear))
            {
                return false;
            }

            if (!int.TryParse(issueYear, out int year))
            {
                return false;
            }

            return year >= 2010 && year <= 2020;
        }
    }
}