using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Mapper.Extensions;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class PetMapper
{
    public static PetDto AsDto(this Core.Entities.Pet pet)
    {
        switch (pet.Type)
        {
            case PetType.CAT:
            {
                var cat = (Cat)pet;
                return new CatDto
                {
                    Age = cat.DateOfBirth.CalculateAgeInMonths(),
                    Gender = cat.Gender,
                    PetId = cat.Id,
                    ProfilePhoto = cat.ProfilePhoto,
                    Name = cat.Name,
                    Breed = cat.Breed,
                    CreatedAt = cat.CreatedAt
                };
            }

            case PetType.DOG:
            {
                var dog = (Dog)pet;
                return new DogDto
                {
                    Age = dog.DateOfBirth.CalculateAgeInMonths(),
                    Gender = dog.Gender,
                    PetId = dog.Id,
                    ProfilePhoto = dog.ProfilePhoto,
                    Name = dog.Name,
                    Breed = dog.Breed,
                    CreatedAt = dog.CreatedAt
                };
            }

            default:
            {
                return new PetDto
                {
                    Age = pet.DateOfBirth.CalculateAgeInMonths(),
                    Gender = pet.Gender,
                    PetId = pet.Id,
                    ProfilePhoto = pet.ProfilePhoto,
                    Name = pet.Name,
                    CreatedAt = pet.CreatedAt
                };
            }
        }
    }
}