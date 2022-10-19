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
    private readonly DbSet<ShelterPet> _shelterPets;

    public GetAllShelterPetsQueryHandler(AppDbContext context, IUserCacheStorage cacheStorage)
    {
        _cacheStorage = cacheStorage;
        _shelterPets = context.ShelterPets;
    }

    public async Task<PagedResult<ShelterPetDto>> HandleAsync(GetAllShelterPetsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(query.PrincipalId);

        var result = await _shelterPets
            .Where(x => x.OwnerId == shelterId)
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => x.AsDto())
            .Skip(query.PageSize * (query.PageNumber - 1))
            .Take(query.PageSize)
            .ToListAsync();


        var count = await _shelterPets.CountAsync(x => x.OwnerId == shelterId);

        return new PagedResult<ShelterPetDto>(result, count, query.PageSize, query.PageNumber);
    }
}