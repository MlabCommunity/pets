using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class
    GetAllShelterPetsQueryHandler : Convey.CQRS.Queries.IQueryHandler<GetAllShelterPetsQuery, PagedResult<PetDto>>
{
    private readonly IUserCacheStorage _cacheStorage;
    private readonly DbSet<Core.Entities.Pet> _pets;

    public GetAllShelterPetsQueryHandler(AppDbContext context, IUserCacheStorage cacheStorage)
    {
        _cacheStorage = cacheStorage;
        _pets = context.Pets;
    }

    public async Task<PagedResult<PetDto>> HandleAsync(GetAllShelterPetsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(query.PrincipalId);

        var result = await _pets
            .Include(x => x.Photos)
            .Where(x => x.OwnerId == shelterId)
            .Skip(query.PageSize * (query.PageNumber - 1))
            .Take(query.PageSize)
            .Select(x => x.AsDto())
            .OrderBy(x => x.CreatedAt)
            .ToListAsync();

        var count = await _pets
            .Where(x => x.OwnerId == shelterId)
            .CountAsync();
        return new PagedResult<PetDto>(result, count, query.PageSize, query.PageNumber);
    }
}