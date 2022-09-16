using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public record Latitude
{
    public double Value { get; }

    public Latitude(double value)
    {
        if (value < 49.00 && value > 55.34)
        {
            throw new InvalidLatitudeValueException();
        }

        Value = value;
    }

    public static implicit operator double(Latitude weight)
        => weight.Value;

    public static implicit operator Latitude(double weight)
        => new(weight);
}