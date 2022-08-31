using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public class WeightOnVisit
{
    public double Value { get; }

    public WeightOnVisit(double value)
    {
        if (value < 0 && value > 200)
        {
            throw new InvalidWeightException();
        }

        Value = value;
    }

    public static implicit operator double?(WeightOnVisit? weight)
        => weight is null ? null : weight.Value;

    public static implicit operator WeightOnVisit(double weight)
        => new(weight);
}