using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class ShelterAdvertisementMapper
{
    public static ShelterPetAdvertisementDto AsDto(this ShelterAdvertisement advertisement, Core.Entities.Pet pet)
    {
        switch (pet.Type)
        {
            case PetType.CAT:
            {
                var cat = (Cat)pet;
                return new ShelterCatAdvertisementDto()
                {
                    OrganizationName = advertisement.OrganizationName,

                    PetId = cat.Id,
                    Name = cat.Name,
                    DateOfBirth = cat.DateOfBirth,
                    Gender = cat.Gender,
                    Photos = cat.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Breed = cat.Breed,
                };
            }

            case PetType.DOG:
            {
                var dog = (Dog)pet;
                return new ShelterDogAdvertisementDto()
                {
                    OrganizationName = advertisement.OrganizationName,
                    PetId = pet.Id,
                    Name = pet.Name,
                    DateOfBirth = pet.DateOfBirth,
                    Gender = pet.Gender,
                    Photos = pet.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Breed = dog.Breed,
                };
            }

            case PetType.OTHER:
            {
                var other = (Other)pet;
                return new ShelterOtherPetAdvertisementDto
                {
                    OrganizationName = advertisement.OrganizationName,
                    PetId = pet.Id,
                    Name = pet.Name,
                    DateOfBirth = pet.DateOfBirth,
                    Gender = pet.Gender,
                    Photos = pet.Photos.Select(x => x.PhotoId.Value).ToList(),
                };
            }

            default:
            {
                return new ShelterPetAdvertisementDto
                {
                    OrganizationName = advertisement.OrganizationName,
                    PetId = pet.Id,
                    Name = pet.Name,
                    DateOfBirth = pet.DateOfBirth,
                    Gender = pet.Gender,
                    Photos = pet.Photos.Select(x => x.PhotoId.Value).ToList(),
                };
            }
        }
    }
}