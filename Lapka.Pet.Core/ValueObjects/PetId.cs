using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public class PetId : TypeId
{
    public PetId(Guid value) : base(value)
    {
    }

    public static implicit operator Guid(PetId id)
        => id.Value;

    public static implicit operator PetId(Guid id)
        => new(id);
}