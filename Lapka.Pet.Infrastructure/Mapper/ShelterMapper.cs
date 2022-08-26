using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class ShelterMapper
{
    public static ShelterDto AsDto(this Shelter shelter)
        => new()
        {
            Id = shelter.Id,
            OrganizationName = shelter.OrganizationName,
            Localization = shelter.Localization.ToString()
        };
}