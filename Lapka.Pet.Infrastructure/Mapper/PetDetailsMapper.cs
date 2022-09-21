using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Mapper;

public static class PetDetailsMapper
{
    public static PetDetailsDto AsDetailsDto(this Core.Entities.Pet pet)
    {
        switch (pet.Type)
        {
            case PetType.CAT:
            {
                var cat = (Cat)pet;
                return new CatDetailsDto
                {
                    DateOfBirth = cat.DateOfBirth,
                    Gender = cat.Gender,
                    PetId = cat.Id,
                    ProfilePhoto = cat.ProfilePhoto,
                    Name = cat.Name,
                    Photos = cat.Photos.Select(x => x.Value).ToList(),
                    Color = cat.Color,
                    Breed = cat.Breed,
                    IsSterilized = cat.IsSterilized,
                    Weight = cat.Weight
                };
            }

            case PetType.DOG:
            {
                var dog = (Dog)pet;
                return new DogDetailsDto
                {
                    DateOfBirth = dog.DateOfBirth,
                    Gender = dog.Gender,
                    PetId = dog.Id,
                    ProfilePhoto = dog.ProfilePhoto,
                    Name = dog.Name,
                    Photos = dog.Photos.Select(x => x.Value).ToList(),
                    Color = dog.Color,
                    Breed = dog.Breed,
                    IsSterilized = dog.IsSterilized,
                    Weight = dog.Weight
                };
            }
            
            default:
            {
                return new PetDetailsDto
                {
                    DateOfBirth = pet.DateOfBirth,
                    Gender = pet.Gender,
                    PetId = pet.Id,
                    ProfilePhoto = pet.ProfilePhoto,
                    Name = pet.Name,
                    Photos = pet.Photos.Select(x => x.Value).ToList(),
                    IsSterilized = pet.IsSterilized,
                    Weight = pet.Weight
                };
            }
        }
    }

}