using Lapka.Pet.Core.DomainThings;

namespace Lapka.Pet.Core.ValueObjects;

public class ShelterId : TypeId
{
    public ShelterId(Guid value) : base(value)
    {
    }

    public static implicit operator ShelterId(Guid id)
        => new(id);
}