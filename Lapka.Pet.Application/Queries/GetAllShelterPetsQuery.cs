using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Application.Queries;

public record GetAllShelterPetsQuery
    (Guid PrincipalId, int PageNumber = 1, int PageSize = 10) : Convey.CQRS.Queries.IQuery<PagedResult<ShelterPetDto>>;