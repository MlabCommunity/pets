using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class LostOther : LostPet
{
    private LostOther()
    {
    }

    public LostOther(OwnerId ownerId, ProfilePhotoId profilePhotoId, PetName name,
        Gender gender, DateOfBirth dateOfBirth, bool isSterilized, Weight weight,
        DateOfDisappearance dateOfDisappearance, PhoneNumber phoneNumber, Longitude longitude, Latitude latitude,
        bool isVisible, FirstName firstName, string description) : base(ownerId, profilePhotoId, PetType.OTHER, name, gender,
        dateOfBirth, isSterilized, weight, dateOfDisappearance, phoneNumber, longitude, latitude, isVisible, firstName,
        description)
    {
    }
}