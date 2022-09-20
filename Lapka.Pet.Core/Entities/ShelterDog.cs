using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class ShelterDog : ShelterPet
{
    public DogBreed DogBreed { get; private set; }
    public DogColor Color { get; private set; }

    private ShelterDog()
    {
    }

    public ShelterDog(OwnerId ownerId, ProfilePhoto profilePhoto, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, string description,
        OrganizationName organizationName, bool isVisible, Longitude longitude, Latitude latitude, DogBreed dogBreed,
        DogColor color,ICollection<string> photos) : base(ownerId, profilePhoto, PetType.DOG, name, gender, dateOfBirth, isSterilized, weight,
        description, organizationName, isVisible, longitude, latitude,photos)
    {
        DogBreed = dogBreed;
        Color = color;
    }
}