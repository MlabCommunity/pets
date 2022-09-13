using Convey.CQRS.Queries;

namespace Lapka.Pet.Application.Queries;

public record GetShelterIdByOwnerIdOrWorkerIdQuery(Guid PrincipalId) : IQuery<Guid>;