using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetShelterStatsQueryHandler : IQueryHandler<GetShelterStatsQuery, StatsDto>
{
    private readonly IUserCacheStorage _cacheStorage;

    private readonly DbSet<Shelter> _shelters;
    

    public GetShelterStatsQueryHandler(AppDbContext context, IUserCacheStorage cacheStorage)
    {
        _cacheStorage = cacheStorage;
        _shelters = context.Shelters;
    }

    public async Task<StatsDto> HandleAsync(GetShelterStatsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(query.PrincipalId);

        var shelter = await _shelters
            .AsNoTracking()
            .Include(x=>x.Archives)
            .Include(x => x.ShelterPets)
            .FirstOrDefaultAsync(x => x.Id == shelterId);


        var cardCount = shelter.ShelterPets.Count();

        var toAdoptCount = shelter.ShelterPets.Where(x=>x.IsVisible==true).Count();

        var Adopted = shelter.Archives.Count();

        return new StatsDto
        {
            CardCount = cardCount,
            ToAdoptCount = toAdoptCount,
            AdoptedCount = Adopted
        };
    }
}