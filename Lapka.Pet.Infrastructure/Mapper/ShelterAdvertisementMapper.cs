using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Mapper.Extensions;
using Lapka.Pet.Infrastructure.Services;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class ShelterAdvertisementMapper
{
    public static ShelterPetAdvertisementDto AsAdvertisementDto(this ShelterPet pet, double latitude, double longitude,
        Guid principalId)
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
                    Age = cat.DateOfBirth.CalculateAgeInMonths(),
                    Gender = cat.Gender,
                    ProfilePhoto = cat.ProfilePhoto,
                    IsLiked = cat.IsLiked(principalId),
                    Distance = cat.Localization.CalculateDistance(longitude, latitude),
                    City = cat.City,
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
                    Age = dog.DateOfBirth.CalculateAgeInMonths(),
                    Gender = dog.Gender,
                    ProfilePhoto = dog.ProfilePhoto,
                    IsLiked = dog.IsLiked(principalId),
                    Distance = dog.Localization.CalculateDistance(longitude, latitude),
                    City = dog.City,
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
                    Age = pet.DateOfBirth.CalculateAgeInMonths(),
                    Gender = pet.Gender,
                    IsLiked = pet.IsLiked(principalId),
                    Distance = pet.Localization.CalculateDistance(longitude, latitude),
                    City = pet.City,
                    ProfilePhoto = pet.ProfilePhoto,
                };
            }
        }
    }

    public static ShelterPetAdvertisementDto AsAdvertisementDto(this ShelterPet pet, double latitude, double longitude)
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
                    Age = cat.DateOfBirth.CalculateAgeInMonths(),
                    Gender = cat.Gender,
                    ProfilePhoto = cat.ProfilePhoto,
                    IsLiked = true,
                    Distance = cat.Localization.CalculateDistance(longitude, latitude),
                    City = cat.City,
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
                    Age = dog.DateOfBirth.CalculateAgeInMonths(),
                    Gender = dog.Gender,
                    ProfilePhoto = dog.ProfilePhoto,
                    IsLiked = true,
                    Distance = dog.Localization.CalculateDistance(longitude, latitude),
                    City = dog.City,
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
                    Age = pet.DateOfBirth.CalculateAgeInMonths(),
                    Gender = pet.Gender,
                    IsLiked = true,
                    Distance = pet.Localization.CalculateDistance(longitude, latitude),
                    City = pet.City,
                    ProfilePhoto = pet.ProfilePhoto,
                };
            }
        }
    }
}