using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Services;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class ShelterMapper
{
    public static ShelterDto AsDto(this Shelter shelter)
        => new()
        {
            Id = shelter.Id,
            OrganizationName = shelter.OrganizationName,
            ProfilePhotoId = shelter.ProfilePhotoId,
            FirstName = shelter.FirstName,
            LastName = shelter.LastName,
        };
    
    public static ShelterDto AsDto(this Shelter shelter,double longitude,double latitude)
        => new()
        {
            Id = shelter.Id,
            OrganizationName = shelter.OrganizationName,
            ProfilePhotoId = shelter.ProfilePhotoId,
            FirstName = shelter.FirstName,
            LastName = shelter.LastName,
            Distance = shelter.Localization.CalculateDistance(longitude,latitude),
            Localization = shelter.Localization.AsDto()
        };
    
}