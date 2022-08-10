namespace Lapka.Pet.Core.ValueObjects;

public class OwnerId : TypeId
{
    public OwnerId(Guid value) : base(value)
    {
    }
    
    public static implicit operator OwnerId(Guid id)
        => new(id);
}