using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class Other : Pet
{
    private Other()
    {
    }

    private Other(OwnerId ownerId, ProfilePhoto profilePhoto, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, ICollection<string> photos) : base(
        ownerId,
        profilePhoto, PetType.OTHER, name, gender, dateOfBirth, isSterilized, weight, photos)
    {
    }

    public static Other Create(OwnerId ownerId, ProfilePhoto profilePhoto, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, ICollection<string> photos)
    {
        var other = new Other(ownerId, profilePhoto, name, gender, dateOfBirth, isSterilized, weight, photos);
        return other;
    }
}