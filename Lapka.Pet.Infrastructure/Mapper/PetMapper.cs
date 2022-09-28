using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Extensions;

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
                    Age = cat.DateOfBirth.CalculateAge(),
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
                    Age = dog.DateOfBirth.CalculateAge(),
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
                    Age = pet.DateOfBirth.CalculateAge(),
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