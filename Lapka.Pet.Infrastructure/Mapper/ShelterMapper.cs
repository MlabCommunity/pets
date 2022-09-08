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
    
    public static ShelterDetailsDto AsDetailsDto(this Shelter shelter)
        => new()
        {

            OrganizationName = shelter.OrganizationName,
            Street = shelter.Localization.Street,
            City = shelter.Localization.City,
            Krs = shelter.Krs,
            Nip = shelter.Nip,
            ZipCode = shelter.ZipCode
        };
}