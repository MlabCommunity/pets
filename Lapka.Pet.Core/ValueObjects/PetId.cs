namespace Lapka.Pet.Core.ValueObjects;

public class PetId : TypeId
{
    public PetId(Guid value) : base(value)
    {
    }
    
    public static implicit operator PetId(Guid id)
        => new(id);
}