using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class Other : Pet
{
    private Other()
    {
    }

    private Other(OwnerId ownerId, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight) : base(
        ownerId,
        PetType.OTHER, name, gender, dateOfBirth, isSterilized, weight)
    {
    }

    public static Other Create(OwnerId ownerId, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight)
    {
        var other = new Other(ownerId, name, gender, dateOfBirth, isSterilized, weight);
        return other;
    }
}