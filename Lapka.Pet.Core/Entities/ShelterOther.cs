using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class ShelterOther : ShelterPet
{
    private ShelterOther()
    {
    }

    public ShelterOther(OwnerId ownerId, ProfilePhoto profilePhoto, PetName name, Gender gender,
        double age, bool isSterilized, Weight weight, string description,
        OrganizationName organizationName, bool isVisible, Longitude longitude, Latitude latitude,string city,string street,string zipCode,
        ICollection<string> photos,Shelter shelter) : base(ownerId,
        profilePhoto, PetType.OTHER, name, gender, new DateOfBirth(age), isSterilized, weight, description,
        organizationName, isVisible,
        longitude, latitude,city,street,zipCode, photos,shelter)
    {
    }
}