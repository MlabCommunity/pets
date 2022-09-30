using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Application.Queries;

public record GetAllSheltersQuery
    (double Longitude, double Latitude, int PageNumber = 1, int PageSize = 10) : IQuery<
        Application.Dto.PagedResult<ShelterDto>>;