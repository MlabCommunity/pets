﻿using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class ShelterCat : ShelterPet
{
    public CatColor Color { get; private set; }
    public CatBreed Breed { get; private set; }

    private ShelterCat()
    {
    }

    public ShelterCat(OwnerId ownerId, ProfilePhotoId profilePhotoId, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, string description,
        OrganizationName organizationName, bool isVisible, Longitude longitude, Latitude latitude, CatColor color,
        CatBreed breed) : base(ownerId, profilePhotoId, PetType.CAT, name, gender, dateOfBirth, isSterilized, weight,
        description, organizationName, isVisible, longitude, latitude)
    {
        Color = color;
        Breed = breed;
    }
}