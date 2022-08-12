using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Core.Entities;

public class Other : Pet
{
    private Other()
    {
    }

    private Other(Guid ownerId, string name, Gender gender,
        DateTime dateOfBirth, bool isSterilized, double weight) : base(
        ownerId,
        PetType.OTHER, name, gender, dateOfBirth, isSterilized, weight)
    {
    }

    public static Other Create(Guid ownerId, string name, Gender gender,
        DateTime dateOfBirth, bool isSterilized, double weight)
    {
        var other = new Other(ownerId, name, gender, dateOfBirth, isSterilized, weight);
        return other;
    }
}