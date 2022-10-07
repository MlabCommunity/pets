using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Application.Queries;

public record GetAllWorkersQuery(Guid PrincipalId,int PageNumber = 1, int PageSize = 10) : IQuery<Dto.PagedResult<WorkerDto>>;