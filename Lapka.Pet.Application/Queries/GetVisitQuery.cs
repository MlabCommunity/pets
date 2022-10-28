using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Application.Queries;

public record GetVisitQuery(Guid VisitId, Guid PrincipalId) : IQuery<VisitDetailsDto>;