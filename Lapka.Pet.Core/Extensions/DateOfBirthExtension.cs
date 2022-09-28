using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Extensions;

public static class DateOfBirthExtension
{
    public static int CalculateAgeInMonths(this DateOfBirth dateOfBirth)
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

        var months = (int)((exactAge) * 12);
        return months < 1 ? 1 : months;
    }
}