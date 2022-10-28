using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class LostCat : LostPet
{
    public CatBreed CatBreed { get; private set; }
    public CatColor CatColor { get; private set; }

    private LostCat()
    {
    }

    public LostCat(OwnerId ownerId, ProfilePhoto profilePhoto, PetName name,
        Gender gender, DateOfBirth dateOfBirth, bool isSterilized, Weight weight,
        DateOfDisappearance dateOfDisappearance, PhoneNumber phoneNumber, Longitude longitude, Latitude latitude,
        string street, string city, string zipCode,
        bool isVisible, FirstName firstName, string description, CatBreed catBreed, CatColor catColor,
        ICollection<string> photos) : base(ownerId,
        profilePhoto, PetType.CAT, name, gender, dateOfBirth, isSterilized, weight, dateOfDisappearance, phoneNumber,
        longitude, latitude, street, city, zipCode, isVisible, firstName, description, photos)
    {
        CatBreed = catBreed;
        CatColor = catColor;
    }
}