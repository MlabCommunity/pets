using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;

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
                    DateOfBirth = cat.DateOfBirth,
                    Gender = cat.Gender,
                    PetId = cat.Id,
                    ProfilePhotoId = cat.ProfilePhotoId,
                    Name = cat.Name,
                    Breed = cat.CatBreed
                };
            }

            case PetType.DOG:
            {
                var dog = (LostDog)pet;
                return new LostDogAdvertisementDto
                {
                    DateOfBirth = dog.DateOfBirth,
                    Gender = dog.Gender,
                    PetId = dog.Id,
                    ProfilePhotoId = dog.ProfilePhotoId,
                    Name = dog.Name,
                    DogBreed = dog.DogBreed
                };
            }
            
            default:
            {
                return new LostPetAdvertisementDto
                {
                    DateOfBirth = pet.DateOfBirth,
                    PetId = pet.Id,
                    Gender = pet.Gender,
                    ProfilePhotoId = pet.ProfilePhotoId,
                    Name = pet.Name,
                };
            }
        }
    }
}