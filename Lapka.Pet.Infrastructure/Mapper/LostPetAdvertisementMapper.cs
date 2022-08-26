using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class LostPetAdvertisementMapper
{
    public static LostPetAdvertisementDto AsDto(this LostPetAdvertisement advertisement, Core.Entities.Pet pet)
    {
        switch (pet.Type)
        {
            case PetType.CAT:
            {
                var cat = (Cat)pet;
                return new LostCatAdvertisementDto
                {
                    DateOfBirth = cat.DateOfBirth,
                    Gender = cat.Gender,
                    PetId = cat.Id,
                    Photos = cat.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Name = cat.Name,
                    CatBreed = cat.Breed,
                    CatColor = cat.Color
                };
            }

            case PetType.DOG:
            {
                var dog = (Dog)pet;
                return new LostDogAdvertisementDto
                {
                    DateOfBirth = dog.DateOfBirth,
                    Gender = dog.Gender,
                    PetId = dog.Id,
                    Photos = dog.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Name = dog.Name,
                    DogBreed = dog.Breed,
                    DogColor = dog.Color
                };
            }

            case PetType.OTHER:
            {
                var other = (Other)pet;
                return new LostOtherPetAdvertisementDto
                {
                    DateOfBirth = other.DateOfBirth,
                    Gender = other.Gender,
                    PetId = other.Id,
                    Photos = other.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Name = other.Name,
                };
            }

            default:
            {
                return new LostPetAdvertisementDto
                {
                    DateOfBirth = pet.DateOfBirth,
                    PetId = pet.Id,
                    Gender = pet.Gender,
                    Photos = pet.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Name = pet.Name,
                };
            }
        }
    }
}