using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public record DateOfDisappearance
{
    public DateTime Value { get; }

    public DateOfDisappearance(DateTime value)
    {
        if (value > DateTime.Now || value < DateTime.Now.AddYears(-5))
        {
            throw new InvalidDateOfDisappearanceException();
        }

        Value = value;
    }

    public static implicit operator DateTime(DateOfDisappearance dateOfDisappearance)
        => dateOfDisappearance.Value;

    public static implicit operator DateOfDisappearance(DateTime dateOfDisappearance)
        => new(dateOfDisappearance);
}