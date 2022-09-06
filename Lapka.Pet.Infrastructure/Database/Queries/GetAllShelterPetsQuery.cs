using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Infrastructure.Database.Queries;

public record GetAllShelterPetsQuery(Guid PrincipalId,int PageNumber = 1, int PageSize = 10) : IQuery<Application.Dto.PagedResult<PetDto>>;