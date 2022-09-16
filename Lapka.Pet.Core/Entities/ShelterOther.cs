using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class ShelterOther : ShelterPet
{
    private ShelterOther(){}
    
    public ShelterOther(OwnerId ownerId, ProfilePhotoId profilePhotoId,PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, string description,
        OrganizationName organizationName, bool isVisible, Longitude longitude, Latitude latitude) : base(ownerId,
        profilePhotoId, PetType.OTHER, name, gender, dateOfBirth, isSterilized, weight, description, organizationName, isVisible,
        longitude, latitude)
    {
    }
}