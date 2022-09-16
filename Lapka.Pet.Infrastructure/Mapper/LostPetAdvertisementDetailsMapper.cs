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
                    ProfilePhotoId = cat.ProfilePhotoId,
                    Photos = cat.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Name = cat.Name,
                    Breed = cat.CatBreed,
                    Color = cat.CatColor,
                    Weight = cat.Weight,
                    Distance = cat.Localization.CalculateDistance(longitude, latitude),
                    Localization = cat.Localization.AsDto()
                };
            }

            case PetType.DOG:
            {
                var dog = (LostDog)pet;
                return new LostPetAdvertisementDetailsDto
                {
                    DateOfBirth = dog.DateOfBirth,
                    Gender = dog.Gender,
                    PetId = dog.Id,
                    ProfilePhotoId = dog.ProfilePhotoId,
                    Photos = dog.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Name = dog.Name,
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
                    ProfilePhotoId = pet.ProfilePhotoId,
                    Photos = pet.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Name = pet.Name,
                    Weight = pet.Weight,
                    Distance = pet.Localization.CalculateDistance(longitude, latitude),
                    Localization = pet.Localization.AsDto()
                };
            }
        }
    }
}