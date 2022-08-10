namespace Lapka.Pet.Core.ValueObjects;

public class PhotoId : TypeId
{
    public PhotoId(Guid value) : base(value)
    {
    }
    
    public static implicit operator PhotoId(Guid id)
        => new(id);
}