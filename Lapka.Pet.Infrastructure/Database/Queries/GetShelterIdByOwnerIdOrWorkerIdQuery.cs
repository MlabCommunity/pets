using Convey.CQRS.Queries;

namespace Lapka.Pet.Infrastructure.Database.Queries;

public record GetShelterIdByOwnerIdOrWorkerIdQuery(Guid PrincipalId) : IQuery<Guid>;