using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Database.Queries;

internal static class Extensions
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
                    DateOfBirth = cat.DateOfBirth,
                    Gender = cat.Gender,
                    Id = cat.Id,
                    IsSterilized = cat.IsSterilized,
                    Photos = cat.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Name = cat.Name,
                    Type = cat.Type,
                    Weight = cat.Weight,
                    CatBreed = cat.Breed,
                    CatColor = cat.Color
                };
            }

            case PetType.DOG:
            {
                var dog = (Dog)pet;
                return new DogDto
                {
                    DateOfBirth = dog.DateOfBirth,
                    Gender = dog.Gender,
                    Id = dog.Id,
                    IsSterilized = dog.IsSterilized,
                    Photos = dog.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Name = dog.Name,
                    Type = dog.Type,
                    Weight = dog.Weight,
                    DogBreed = dog.Breed,
                    DogColor = dog.Color
                };
            }

            case PetType.OTHER:
            {
                var other = (Other)pet;
                return new OtherDto
                {
                    DateOfBirth = other.DateOfBirth,
                    Gender = other.Gender,
                    Id = other.Id,
                    IsSterilized = other.IsSterilized,
                    Photos = other.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Name = other.Name,
                    Type = other.Type,
                    Weight = other.Weight
                };
            }

            default:
            {
                return new PetDto
                {
                    DateOfBirth = pet.DateOfBirth,
                    Gender = pet.Gender,
                    Id = pet.Id,
                    IsSterilized = pet.IsSterilized,
                    Photos = pet.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Name = pet.Name,
                    Type = pet.Type,
                    Weight = pet.Weight
                };
            }
        }
    }
}