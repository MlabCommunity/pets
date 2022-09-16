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

    public LostCat(OwnerId ownerId, ProfilePhotoId profilePhotoId, PetName name,
        Gender gender, DateOfBirth dateOfBirth, bool isSterilized, Weight weight,
        DateOfDisappearance dateOfDisappearance, PhoneNumber phoneNumber, Longitude longitude, Latitude latitude,
        bool isVisible, FirstName firstName, string description, CatBreed catBreed, CatColor catColor) : base(ownerId,
        profilePhotoId, PetType.CAT, name, gender, dateOfBirth, isSterilized, weight, dateOfDisappearance, phoneNumber,
        longitude, latitude, isVisible, firstName, description)
    {
        CatBreed = catBreed;
        CatColor = catColor;
    }
}