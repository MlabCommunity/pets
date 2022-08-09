using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public class ShelterId : TypeId
{
    
    public ShelterId(Guid value) : base(value)
    {
    }

    public static implicit operator Guid(ShelterId id)
        => id.Value;

    public static implicit operator ShelterId(Guid id)
        => new(id);
}