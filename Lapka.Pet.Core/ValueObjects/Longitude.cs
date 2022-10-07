using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public record Longitude
{
    public double Value { get; }

    public Longitude(double value)
    {
        if (value < 14.07 && value > 24.15)
        {
            throw new InvalidLongitudeValueException();
        }

        Value = value;
    }

    public static implicit operator double(Longitude weight)
        => weight.Value;

    public static implicit operator Longitude(double weight)
        => new(weight);
}