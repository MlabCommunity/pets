using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class LocalizationMapper
{
    public static LocalizationDto AsDto(this Localization localization)
        => new()
        {
            Latitude = localization.Latitude,
            Longitude = localization.Longitude
        };
}