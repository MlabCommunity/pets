using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Infrastructure.Database.Queries;

public record GetShelterQuery(Guid Id) : IQuery<ShelterDto>;