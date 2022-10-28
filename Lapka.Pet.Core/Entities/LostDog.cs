using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class LostDog : LostPet
{
    public DogBreed DogBreed { get; private set; }
    public DogColor DogColor { get; private set; }

    private LostDog()
    {
    }


    public LostDog(OwnerId ownerId, ProfilePhoto profilePhoto, PetName name,
        Gender gender, DateOfBirth dateOfBirth, bool isSterilized, Weight weight,
        DateOfDisappearance dateOfDisappearance, PhoneNumber phoneNumber, Longitude longitude, Latitude latitude,
        string street, string city, string zipCode,
        bool isVisible, FirstName firstName, string description, DogBreed dogBreed, DogColor dogColor,
        ICollection<string> photos) : base(ownerId,
        profilePhoto, PetType.DOG, name, gender, dateOfBirth, isSterilized, weight, dateOfDisappearance, phoneNumber,
        longitude, latitude, street, city, zipCode, isVisible, firstName, description, photos)
    {
        DogBreed = dogBreed;
        DogColor = dogColor;
    }
}