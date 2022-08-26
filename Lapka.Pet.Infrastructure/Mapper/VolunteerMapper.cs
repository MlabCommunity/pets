using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class VolunteerMapper
{
    public static List<VolunteerDto> AsVolunteerDtos(this Shelter shelter)
        => new List<VolunteerDto>(shelter.Volunteers.Select(x => x.AsDto()));

    public static VolunteerDto AsDto(this Volunteer volunteer)
        => new()
        {
            Email = volunteer.Email,
            UserId = volunteer.UserId
        };
}