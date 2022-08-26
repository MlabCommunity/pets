using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Queries;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class LostPetAdvertisementDetailsMapper
{
    public static LostPetAdvertisementDetailsDto AsDetailsDto(this LostPetAdvertisement advertisement,
        Core.Entities.Pet pet)
    {
        switch (pet.Type)
        {
            case PetType.CAT:
            {
                return new LostCatAdvertisementDetailsDto
                {
                    DateOfDisappearance = advertisement.DateOfDisappearance,
                    Localization = advertisement.Localization.ToString(),
                    Description = advertisement.Description,
                    FirstName = advertisement.FirstName,
                    PhoneNumber = advertisement.PhoneNumber,
                    Pet = pet.AsDto()
                };
            }

            case PetType.DOG:
            {
                return new LostDogAdvertisementDetailsDto
                {
                    DateOfDisappearance = advertisement.DateOfDisappearance,
                    Localization = advertisement.Localization.ToString(),
                    Description = advertisement.Description,
                    FirstName = advertisement.FirstName,
                    PhoneNumber = advertisement.PhoneNumber,
                    Pet = pet.AsDto()
                };
            }

            case PetType.OTHER:
            {
                return new LostOtherPetAdvertisementDetailsDto
                {
                    DateOfDisappearance = advertisement.DateOfDisappearance,
                    Localization = advertisement.Localization.ToString(),
                    Description = advertisement.Description,
                    FirstName = advertisement.FirstName,
                    PhoneNumber = advertisement.PhoneNumber,
                    Pet = pet.AsDto()
                };
            }

            default:
            {
                return new LostPetAdvertisementDetailsDto
                {
                    DateOfDisappearance = advertisement.DateOfDisappearance,
                    Localization = advertisement.Localization.ToString(),
                    Description = advertisement.Description,
                    FirstName = advertisement.FirstName,
                    PhoneNumber = advertisement.PhoneNumber,
                    Pet = pet.AsDto()
                };
            }
        }
    }
}