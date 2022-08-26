using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Infrastructure.Database.Queries;

public record GetShelterStatsQuery(Guid PrincipalId) : IQuery<StatsDto>;