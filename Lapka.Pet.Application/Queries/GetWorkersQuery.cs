using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Application.Queries;

public record GetWorkersQuery(Guid PrincipalId) : IQuery<List<WorkerDto>>;