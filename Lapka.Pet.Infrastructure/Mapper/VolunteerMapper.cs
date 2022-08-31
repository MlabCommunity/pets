using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class VolunteerMapper
{
    
    public static VolunteerDto AsDto(this Volunteer volunteer)
        => new()
        {
            Email = volunteer.Email,
            UserId = volunteer.UserId
        };
}