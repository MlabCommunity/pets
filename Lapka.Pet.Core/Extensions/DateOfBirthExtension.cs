using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Extensions;

public static class DateOfBirthExtension
{
    public static double CalculateAge(this DateOfBirth dateOfBirth)
    {
        DateTime today = DateTime.UtcNow.AddDays(8);

        int years = today.Year - dateOfBirth.Value.Year;
        DateTime last = dateOfBirth.Value.AddYears(years);
        if (last > today)
        {
            last = last.AddYears(-1);
            years--;
        }

        DateTime next = last.AddYears(1);

        double yearDays = (next - last).Days;

        double days = (today - last).Days;

        double exactAge = (double)years + (days / yearDays);

        if (exactAge < 1)
        {
            if (exactAge < 0.1)
            {
                return 0;
            }

            return Math.Round(exactAge, 1);
        }

        return Math.Floor(exactAge);
    }
}