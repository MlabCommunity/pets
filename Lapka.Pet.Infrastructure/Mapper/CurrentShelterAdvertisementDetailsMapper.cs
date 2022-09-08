using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class CurrentShelterAdvertisementDetailsMapper
{
    public static CurrentShelterAdvertisementDetailsDto AsCurrentShelterAdvertisementDto(
        this ShelterAdvertisement advertisement,
        Core.Entities.Pet pet)
        => new()
        {
            AdvertisementId = advertisement.Id,
            IsVisible = advertisement.IsVisible,
            OrganizationName = advertisement.OrganizationName,
            Localization = advertisement.Localization.ToString(),
            IsReserved = advertisement.IsReserved,
            Description = advertisement.Description,
            Pet = pet.AsDto()
        };
}