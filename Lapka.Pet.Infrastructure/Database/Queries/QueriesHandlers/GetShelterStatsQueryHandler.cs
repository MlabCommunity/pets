using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetShelterStatsQueryHandler : IQueryHandler<GetShelterStatsQuery, StatsDto>
{
    private readonly IUserCacheStorage _cacheStorage;

    private readonly DbSet<Shelter> _shelters;
    private readonly DbSet<Core.Entities.Pet> _pet;

    public GetShelterStatsQueryHandler(AppDbContext context, IUserCacheStorage cacheStorage)
    {
        _cacheStorage = cacheStorage;
        _shelters = context.Shelters;
        _pet = context.Pets;
    }

    public async Task<StatsDto> HandleAsync(GetShelterStatsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(query.PrincipalId);

        var shelter = await _shelters
            .AsNoTracking()
            .Include(x => x.Advertisements)
            .FirstOrDefaultAsync(x => x.Id == shelterId);


        var cardCount = await _pet.CountAsync(x => x.OwnerId == shelter.Id.Value);

        var toAdoptCount = shelter.Advertisements.Count;

        var Adopted = 1;

        return new StatsDto
        {
            CardCount = cardCount,
            ToAdoptCount = toAdoptCount,
            AdoptedCount = Adopted
        };
    }
}