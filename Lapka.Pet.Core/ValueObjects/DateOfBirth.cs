using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public record DateOfBirth
{
    public DateTime Value { get; }

    public DateOfBirth(DateTime value)
    {
        if (value > DateTime.Now || value < DateTime.Now.AddYears(-50))
        {
            throw new InvalidDateOfBirthException();
        }

        Value = value;
    }

    public DateOfBirth(double age)
    {
        var dob = DateTime.UtcNow;
        var days = age * 365.25;
        var value = dob.AddDays(-days);

        if (value > DateTime.Now || value < DateTime.Now.AddYears(-50))
        {
            throw new InvalidDateOfBirthException();
        }

        Value = value;
    }

    public static implicit operator DateTime(DateOfBirth dateOfBirth)
        => dateOfBirth.Value;

    public static implicit operator DateOfBirth(DateTime dateOfBirth)
        => new(dateOfBirth);
}