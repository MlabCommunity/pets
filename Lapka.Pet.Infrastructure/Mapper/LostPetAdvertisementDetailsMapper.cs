using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
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
                    DateOfBirth = cat.DateOfBirth,
                    Gender = cat.Gender,
                    PetId = cat.Id,
                    ProfilePhoto = cat.ProfilePhoto,
                    Photos = cat.Photos.Select(x => x.Link.Value).ToList(),
                    Name = cat.Name,
                    Breed = cat.CatBreed,
                    Color = cat.CatColor,
                    Weight = cat.Weight,
                    PhoneNumber = cat.PhoneNumber,
                    FirstName = cat.FirstName,
                    Distance = cat.Localization.CalculateDistance(longitude, latitude),
                    Localization = cat.Localization.AsDto()
                };
            }

            case PetType.DOG:
            {
                var dog = (LostDog)pet;
                return new LostDogAdvertisementDetailsDto
                {
                    DateOfBirth = dog.DateOfBirth,
                    Gender = dog.Gender,
                    PetId = dog.Id,
                    ProfilePhoto = dog.ProfilePhoto,
                    Breed = dog.DogBreed,
                    Color = dog.DogColor,
                    Photos = dog.Photos.Select(x => x.Link.Value).ToList(),
                    Name = dog.Name,
                    PhoneNumber = dog.PhoneNumber,
                    FirstName = dog.FirstName,
                    Weight = dog.Weight,
                    Distance = dog.Localization.CalculateDistance(longitude, latitude),
                    Localization = dog.Localization.AsDto()
                };
            }
            
            default:
            {
                return new LostPetAdvertisementDetailsDto
                {
                    DateOfBirth = pet.DateOfBirth,
                    Gender = pet.Gender,
                    PetId = pet.Id,
                    ProfilePhoto = pet.ProfilePhoto,
                    Photos = pet.Photos.Select(x => x.Link.Value).ToList(),
                    Name = pet.Name,
                    PhoneNumber = pet.PhoneNumber,
                    
                    FirstName = pet.FirstName,
                    Weight = pet.Weight,
                    Distance = pet.Localization.CalculateDistance(longitude, latitude),
                    Localization = pet.Localization.AsDto()
                };
            }
        }
    }
}