using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class LostOther : LostPet
{
    private LostOther()
    {
    }

    public LostOther(OwnerId ownerId, ProfilePhoto profilePhoto, PetName name,
        Gender gender, DateOfBirth dateOfBirth, bool isSterilized, Weight weight,
        DateOfDisappearance dateOfDisappearance, PhoneNumber phoneNumber, Longitude longitude, Latitude latitude,
        string street, string city, string zipCode,
        bool isVisible, FirstName firstName, string description, ICollection<string> photos) : base(ownerId,
        profilePhoto, PetType.OTHER, name, gender,
        dateOfBirth, isSterilized, weight, dateOfDisappearance, phoneNumber, longitude, latitude, street, city,
        zipCode,isVisible, firstName,
        description, photos)
    {
    }
}