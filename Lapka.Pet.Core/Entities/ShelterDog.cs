﻿using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class ShelterDog : ShelterPet
{
    public DogBreed DogBreed { get; private set; }
    public DogColor Color { get; private set; }

    private ShelterDog()
    {
    }

    public ShelterDog(OwnerId ownerId, ProfilePhoto profilePhoto, PetName name, Gender gender,
        double age, bool isSterilized, Weight weight, string description,
        OrganizationName organizationName, bool isVisible, Longitude longitude, Latitude latitude, DogBreed dogBreed,
        DogColor color, ICollection<string> photos,Shelter shelter) : base(ownerId, profilePhoto, PetType.DOG, name, gender,
        new DateOfBirth(age), isSterilized, weight,
        description, organizationName, isVisible, longitude, latitude, photos,shelter)
    {
        DogBreed = dogBreed;
        Color = color;
    }
}