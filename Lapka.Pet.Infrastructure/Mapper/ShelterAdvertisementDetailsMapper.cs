using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class ShelterAdvertisementDetailsMapper
{
    public static ShelterAdvertisementDetailsDto AsDetailsDto(this ShelterAdvertisement advertisement,
        Core.Entities.Pet pet)
    {
        return new ShelterAdvertisementDetailsDto
        {
            AdvertisementId = advertisement.Id,
            Description = advertisement.Description,
            Localization = advertisement.Localization.ToString(),
            OrganizationName = advertisement.OrganizationName,
            IsReserved = advertisement.IsReserved,
            Pet = pet.AsDto()
        };
    }
}