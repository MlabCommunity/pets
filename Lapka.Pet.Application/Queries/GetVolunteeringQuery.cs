using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Application.Queries;

public record GetVolunteeringQuery(Guid ShelterId) : IQuery<VolunteeringDto>;