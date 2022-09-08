using Lapka.Pet.Core.DomainThings;

namespace Lapka.Pet.Core.ValueObjects;

public class ProfilePhotoId : TypeId
{
    public ProfilePhotoId(Guid value) : base(value)
    {
    }
    
    public static implicit operator ProfilePhotoId(Guid id)
        => new(id);
}