using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.DomainThings;

public abstract class TypeName : IEquatable<TypeName>
{
    public string Value { get; }

    protected TypeName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyNameException();
        }

        Value = value;
    }

    public bool Equals(TypeName other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((TypeName)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static implicit operator string(TypeName typeId)
        => typeId.Value;


    public override string ToString() => Value.ToString();
}