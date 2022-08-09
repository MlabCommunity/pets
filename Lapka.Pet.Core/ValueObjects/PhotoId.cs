using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public class PhotoId : TypeId
{
    
    public PhotoId(Guid value) : base(value)
    {
    }

    public static implicit operator Guid(PhotoId id)
        => id.Value;

    public static implicit operator PhotoId(Guid id)
        => new(id);
}