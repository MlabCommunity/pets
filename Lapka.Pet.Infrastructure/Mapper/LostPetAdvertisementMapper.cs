using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Mapper.Extensions;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class LostPetAdvertisementMapper
{
    public static LostPetAdvertisementDto AsDto(this LostPet pet)
    {
        switch (pet.Type)
        {
            case PetType.CAT:
            {
                var cat = (LostCat)pet;
                return new LostCatAdvertisementDto
                {
                    Age = cat.DateOfBirth.CalculateAgeInMonths(),
                    Gender = cat.Gender,
                    PetId = cat.Id,
                    ProfilePhoto = cat.ProfilePhoto,
                    Name = cat.Name,
                    Breed = cat.CatBreed
                };
            }

            case PetType.DOG:
            {
                var dog = (LostDog)pet;
                return new LostDogAdvertisementDto
                {
                    Age = dog.DateOfBirth.CalculateAgeInMonths(),
                    Gender = dog.Gender,
                    PetId = dog.Id,
                    ProfilePhoto = dog.ProfilePhoto,
                    Name = dog.Name,
                    Breed = dog.DogBreed
                };
            }

            default:
            {
                return new LostPetAdvertisementDto
                {
                    Age = pet.DateOfBirth.CalculateAgeInMonths(),
                    PetId = pet.Id,
                    Gender = pet.Gender,
                    ProfilePhoto = pet.ProfilePhoto,
                    Name = pet.Name,
                };
            }
        }
    }
}