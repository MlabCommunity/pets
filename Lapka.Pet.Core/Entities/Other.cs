using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class Other : Pet
{
    private Other()
    {
    }

    private Other(OwnerId ownerId,ProfilePhotoId profilePhotoId, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight) : base(
        ownerId,
        profilePhotoId,PetType.OTHER, name, gender, dateOfBirth, isSterilized, weight)
    {
    }

    public static Other Create(OwnerId ownerId,ProfilePhotoId profilePhotoId, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, ICollection<Guid> photos)
    {
        var other = new Other(ownerId, profilePhotoId,name, gender, dateOfBirth, isSterilized, weight);
        other.AddPhotos(photos);
        return other;
    }
}