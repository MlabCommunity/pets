using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Mapper.Extensions;
using Lapka.Pet.Infrastructure.Services;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class ShelterMapper
{
    public static ShelterDto AsDto(this Shelter shelter)
        => new()
        {
            Id = shelter.Id,
            OrganizationName = shelter.OrganizationName,
            ProfilePhoto = shelter.ProfilePhoto,
            Email = shelter.Email,
            FirstName = shelter.FirstName,
            LastName = shelter.LastName,
        };

    public static ShelterDto AsDto(this Shelter shelter, double longitude, double latitude)
        => new()
        {
            Id = shelter.Id,
            OrganizationName = shelter.OrganizationName,
            ProfilePhoto = shelter.ProfilePhoto,
            FirstName = shelter.FirstName,
            LastName = shelter.LastName,
            PhoneNumber = shelter.PhoneNumber,
            Distance = shelter.Localization.CalculateDistance(longitude, latitude),
            City = shelter.City,
            Email = shelter.Email,
            Street = shelter.Street
        };
}