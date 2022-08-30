using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Infrastructure.Database.Queries;


public record GetAllVisitsQuery(Guid PetId, Guid PrincipalId):IQuery<List<VisitDto>>;