using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public class Weight
{
    public double Value { get; }

    public Weight(double value)
    {
        if (value < 0 && value > 200)
        {
            throw new InvalidWeightException();
        }

        Value = value;
    }

    public static implicit operator double(Weight weight)
        => weight.Value;

    public static implicit operator Weight(double weight)
        => new(weight);
}