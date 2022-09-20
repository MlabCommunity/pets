using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Services;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class ShelterAdvertisementDetailsMapper
{
    public static ShelterPetAdvertisementDetailsDto AsAdvertisementDetailsDto(this ShelterPet pet,double longitude,double latitude)
    {
        switch (pet.Type)
        {
            case PetType.CAT:
            {
                var cat = (ShelterCat)pet;
                return new ShelterCatAdvertisementDetailsDto
                {
                    OrganizationName = cat.OrganizationName,
                    PetId = cat.Id,
                    Name = cat.Name,
                    DateOfBirth = cat.DateOfBirth,
                    ProfilePhoto = cat.ProfilePhoto,
                    Gender = cat.Gender,
                    Photos = cat.Photos.Select(x => x.PhotoLink.Value).ToList(),
                    Breed = cat.Breed,
                    Description = cat.Description,
                    Distance = cat.Localization.CalculateDistance(longitude, latitude),
                    Localization = cat.Localization.AsDto()
                };
            }

            case PetType.DOG:
            {
                var dog = (ShelterDog)pet;
                return new ShelterDogAdvertisementDetailsDto
                {
                    OrganizationName = dog.OrganizationName,
                    PetId = dog.Id,
                    Name = dog.Name,
                    DateOfBirth = dog.DateOfBirth,
                    Gender = dog.Gender,
                    ProfilePhoto = dog.ProfilePhoto,
                    Photos = dog.Photos.Select(x => x.PhotoLink.Value).ToList(),
                    Breed = dog.DogBreed,
                    Description = dog.Description,
                    Distance = dog.Localization.CalculateDistance(longitude, latitude),
                    Localization = dog.Localization.AsDto()
                };
            }
            
            default:
            {
                return new ShelterPetAdvertisementDetailsDto
                {
                    OrganizationName = pet.OrganizationName,
                    PetId = pet.Id,
                    Name = pet.Name,
                    DateOfBirth = pet.DateOfBirth,
                    ProfilePhoto = pet.ProfilePhoto,
                    Photos = pet.Photos.Select(x => x.PhotoLink.Value).ToList(),
                    Description = pet.Description,
                    Distance = pet.Localization.CalculateDistance(longitude, latitude),
                    Localization = pet.Localization.AsDto()
                };
            }
        }
    }
}