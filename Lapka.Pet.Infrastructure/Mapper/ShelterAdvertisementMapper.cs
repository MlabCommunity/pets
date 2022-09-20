using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Services;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class ShelterAdvertisementMapper
{
    public static ShelterPetAdvertisementDto AsAdvertisementDto(this ShelterPet pet,double latitude,double longitude)
    {
        switch (pet.Type)
        {
            case PetType.CAT:
            {
                var cat = (ShelterCat)pet;
                return new ShelterCatAdvertisementDto
                {
                    OrganizationName = cat.OrganizationName,
                    PetId = cat.Id,
                    Name = cat.Name,
                    DateOfBirth = cat.DateOfBirth,
                    Gender = cat.Gender,
                    ProfilePhoto = cat.ProfilePhoto,
                    Distance = cat.Localization.CalculateDistance(longitude, latitude),
                    Localization = cat.Localization.AsDto(),
                    Breed = cat.Breed,
                };
            }

            case PetType.DOG:
            {
                var dog = (ShelterDog)pet;
                return new ShelterDogAdvertisementDto
                {
                    OrganizationName = pet.OrganizationName,
                    PetId = dog.Id,
                    Name = dog.Name,
                    DateOfBirth = dog.DateOfBirth,
                    Gender = dog.Gender,
                    ProfilePhoto = dog.ProfilePhoto,
                    Distance = dog.Localization.CalculateDistance(longitude, latitude),
                    Localization = dog.Localization.AsDto(),
                    Breed = dog.DogBreed,
                };
            }
            
            default:
            {
                return new ShelterPetAdvertisementDto
                {
                    OrganizationName = pet.OrganizationName,
                    PetId = pet.Id,
                    Name = pet.Name,
                    DateOfBirth = pet.DateOfBirth,
                    Gender = pet.Gender,
                    Distance = pet.Localization.CalculateDistance(longitude, latitude),
                    Localization = pet.Localization.AsDto(),
                    ProfilePhoto = pet.ProfilePhoto,
                };
            }
        }
    }
}