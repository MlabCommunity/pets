using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Mapper.Extensions;
using Lapka.Pet.Infrastructure.Services;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class LostPetAdvertisementDetailsMapper
{
    public static LostPetAdvertisementDetailsDto AsDetailsDto(this LostPet pet, double longitude,
        double latitude)
    {
        switch (pet.Type)
        {
            case PetType.CAT:
            {
                var cat = (LostCat)pet;
                return new LostCatAdvertisementDetailsDto
                {
                    Age = cat.DateOfBirth.CalculateAgeInMonths(),
                    Gender = cat.Gender,
                    PetId = cat.Id,
                    DateOfDisappearance = cat.DateOfDisappearance,
                    ProfilePhoto = cat.ProfilePhoto,
                    Photos = cat.Photos.Select(x => x.Link.Value).ToList(),
                    Name = cat.Name,
                    Breed = cat.CatBreed,
                    Description = cat.Description,
                    Color = cat.CatColor,
                    Weight = cat.Weight,
                    PhoneNumber = cat.PhoneNumber,
                    FirstName = cat.FirstName,
                    Distance = cat.Localization.CalculateDistance(longitude, latitude),
                    City = cat.City,
                    Street = cat.Street
                };
            }

            case PetType.DOG:
            {
                var dog = (LostDog)pet;
                return new LostDogAdvertisementDetailsDto
                {
                    Age = dog.DateOfBirth.CalculateAgeInMonths(),
                    DateOfDisappearance = dog.DateOfDisappearance,
                    Gender = dog.Gender,
                    PetId = dog.Id,
                    ProfilePhoto = dog.ProfilePhoto,
                    Breed = dog.DogBreed,
                    Color = dog.DogColor,
                    Photos = dog.Photos.Select(x => x.Link.Value).ToList(),
                    Name = dog.Name,
                    Description = dog.Description,
                    PhoneNumber = dog.PhoneNumber,
                    FirstName = dog.FirstName,
                    Weight = dog.Weight,
                    Distance = dog.Localization.CalculateDistance(longitude, latitude),
                    City = dog.City,
                    Street = dog.Street
                };
            }

            default:
            {
                return new LostPetAdvertisementDetailsDto
                {
                    Age = pet.DateOfBirth.CalculateAgeInMonths(),
                    Gender = pet.Gender,
                    DateOfDisappearance = pet.DateOfDisappearance,
                    PetId = pet.Id,
                    ProfilePhoto = pet.ProfilePhoto,
                    Photos = pet.Photos.Select(x => x.Link.Value).ToList(),
                    Name = pet.Name,
                    PhoneNumber = pet.PhoneNumber,
                    Description = pet.Description,
                    FirstName = pet.FirstName,
                    Weight = pet.Weight,
                    Distance = pet.Localization.CalculateDistance(longitude, latitude),
                    City = pet.City,
                    Street = pet.Street
                };
            }
        }
    }
}