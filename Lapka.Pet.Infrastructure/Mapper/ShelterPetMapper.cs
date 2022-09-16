using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class ShelterPetMapper
{
    public static ShelterPetDto AsDto(
        this ShelterPet pet)
    {
        switch (pet.Type)
        {
            case PetType.CAT:
            {
                var cat = (ShelterCat)pet;
                return new ShelterCatDto
                {
                    Gender = cat.Gender,
                    Id = cat.Id,
                    IsSterilized = cat.IsSterilized,
                    Name = cat.Name,
                    Type = cat.Type,
                    Weight = cat.Weight,
                    Color = cat.Color,
                    CreatedAt = cat.CreatedAt
                };

            }

            case PetType.DOG:
            {
                var dog = (ShelterDog)pet;
                return new ShelterDogDto
                {

                    Gender = dog.Gender,
                    Id = dog.Id,
                    IsSterilized = dog.IsSterilized,
                    Name = dog.Name,
                    Type = dog.Type,
                    Weight = dog.Weight,
                    Color = dog.Color,
                    CreatedAt = dog.CreatedAt
                };
            }
            
            default:
            {
                return new ShelterPetDto
                {
                    Gender = pet.Gender,
                    Id = pet.Id,
                    IsSterilized = pet.IsSterilized,
                    Name = pet.Name,
                    Type = pet.Type,
                    Weight = pet.Weight,
                    CreatedAt = pet.CreatedAt
                };
            }
        }
    }
}