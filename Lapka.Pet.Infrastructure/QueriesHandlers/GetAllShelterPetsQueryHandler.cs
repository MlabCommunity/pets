using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class
    GetAllShelterPetsQueryHandler : Convey.CQRS.Queries.IQueryHandler<GetAllShelterPetsQuery,
        PagedResult<ShelterPetDto>>
{
    private readonly IUserCacheStorage _cacheStorage;
    private readonly DbSet<Shelter> _shelters;

    public GetAllShelterPetsQueryHandler(AppDbContext context, IUserCacheStorage cacheStorage)
    {
        _cacheStorage = cacheStorage;
        _shelters = context.Shelters;
    }

    public async Task<PagedResult<ShelterPetDto>> HandleAsync(GetAllShelterPetsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(query.PrincipalId);

        var shelterPets = await _shelters
            .Include(x => x.ShelterPets)
            .Where(x => x.Id == shelterId)
            .Select(x => x.ShelterPets.ToList())
            .FirstOrDefaultAsync();

        var retult = shelterPets
            .OrderByDescending(x => x.CreatedAt)
            .Where(x => x.OwnerId == shelterId)
            .Skip(query.PageSize * (query.PageNumber - 1))
            .Take(query.PageSize)
            .Select(x => x.AsDto())
            .ToList();

        var count = shelterPets.Count();

        return new PagedResult<ShelterPetDto>(retult, count, query.PageSize, query.PageNumber);
    }
}