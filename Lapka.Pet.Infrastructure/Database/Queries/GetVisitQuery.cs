using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Infrastructure.Database.Queries;

public record GetVisitQuery(Guid PetId,Guid VisitId,Guid PrincipalId) : IQuery<VisitDto>;