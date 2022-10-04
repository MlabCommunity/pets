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

    public ShelterCat(OwnerId ownerId, ProfilePhoto profilePhoto, PetName name, Gender gender,
        double age, bool isSterilized, Weight weight, string description,
        OrganizationName organizationName, bool isVisible, Longitude longitude, Latitude latitude, CatColor color,
        CatBreed breed, ICollection<string> photos,Shelter shelter) : base(ownerId, profilePhoto, PetType.CAT, name, gender,
        new DateOfBirth(age), isSterilized, weight,
        description, organizationName, isVisible, longitude, latitude, photos,shelter)
    {
        Color = color;
        Breed = breed;
    }
}