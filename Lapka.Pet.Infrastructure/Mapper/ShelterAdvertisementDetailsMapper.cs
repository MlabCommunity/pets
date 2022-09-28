using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Extensions;
using Lapka.Pet.Infrastructure.Services;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class ShelterAdvertisementDetailsMapper
{
    public static ShelterPetAdvertisementDetailsDto AsAdvertisementDetailsDto(this ShelterPet pet,double longitude,double latitude,Guid PrincipalId)
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
                    Age = cat.DateOfBirth.CalculateAge(),
                    ProfilePhoto = cat.ProfilePhoto,
                    Gender = cat.Gender,
                    Photos = cat.Photos.Select(x => x.Link.Value).ToList(),
                    Breed = cat.Breed,
                    Color = cat.Color,
                    IsSterilized = cat.IsSterilized,
                    Weight = cat.Weight,
                    Description = cat.Description,
                    IsLiked = cat.IsLiked(PrincipalId),
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
                    Age = dog.DateOfBirth.CalculateAge(),
                    Gender = dog.Gender,
                    ProfilePhoto = dog.ProfilePhoto,
                    Photos = dog.Photos.Select(x => x.Link.Value).ToList(),
                    Breed = dog.DogBreed,
                    Color = dog.Color,
                    IsSterilized = dog.IsSterilized,
                    IsLiked = dog.IsLiked(PrincipalId),
                    Weight = dog.Weight,
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
                    Age = pet.DateOfBirth.CalculateAge(),
                    ProfilePhoto = pet.ProfilePhoto,
                    IsLiked = pet.IsLiked(PrincipalId),
                    IsSterilized = pet.IsSterilized,
                    Weight = pet.Weight,
                    Photos = pet.Photos.Select(x => x.Link.Value).ToList(),
                    Description = pet.Description,
                    Distance = pet.Localization.CalculateDistance(longitude, latitude),
                    Localization = pet.Localization.AsDto()
                };
            }
        }
    }
}