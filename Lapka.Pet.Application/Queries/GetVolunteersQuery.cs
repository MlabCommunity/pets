using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Application.Queries;

public record GetVolunteersQuery(Guid PrincipalId) : IQuery<List<VolunteerDto>>;