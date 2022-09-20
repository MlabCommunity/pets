﻿using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class ShelterOther : ShelterPet
{
    private ShelterOther(){}
    
    public ShelterOther(OwnerId ownerId, ProfilePhoto profilePhoto,PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, string description,
        OrganizationName organizationName, bool isVisible, Longitude longitude, Latitude latitude,ICollection<string>photos) : base(ownerId,
        profilePhoto, PetType.OTHER, name, gender, dateOfBirth, isSterilized, weight, description, organizationName, isVisible,
        longitude, latitude,photos)
    {
    }
}