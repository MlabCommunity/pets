using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Infrastructure.Database.Queries;

public record GetAllCurrentShelterAdvertisementQuery
    (Guid PrincipalId, int PageNumber = 1, int PageSize = 10) : Convey.CQRS.Queries.IQuery<
        PagedResult<CurrentShelterAdvertisementDetailsDto>>;