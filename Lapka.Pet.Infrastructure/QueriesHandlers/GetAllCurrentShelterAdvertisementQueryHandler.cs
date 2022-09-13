using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class
    GetAllCurrentShelterAdvertisementQueryHandler : Convey.CQRS.Queries.IQueryHandler<
        GetAllCurrentShelterAdvertisementQuery,
        PagedResult<CurrentShelterAdvertisementDetailsDto>>
{
    private readonly DbSet<ShelterAdvertisement> _advertisements;
    private readonly DbSet<Core.Entities.Pet> _pet;
    private readonly IUserCacheStorage _cacheStorage;

    public GetAllCurrentShelterAdvertisementQueryHandler(AppDbContext context, IUserCacheStorage cacheStorage)
    {
        _cacheStorage = cacheStorage;
        _advertisements = context.ShelterAdvertisements;
        _pet = context.Pets;
    }

    public async Task<PagedResult<CurrentShelterAdvertisementDetailsDto>> HandleAsync(
        GetAllCurrentShelterAdvertisementQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(query.PrincipalId);

        var advertisements = await _advertisements
            .Where(x => x.ShelterId == shelterId)
            .ToListAsync();

        var result =
            advertisements.Join(_pet.Include(x => x.Photos), x => x.PetId.Value, x => x.Id.Value,
                    (advertisement, pet) =>
                        advertisement.AsCurrentShelterAdvertisementDto(pet))
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

        var count = await _advertisements
            .Where(x => x.ShelterId == shelterId)
            .CountAsync();

        return new PagedResult<CurrentShelterAdvertisementDetailsDto>(result, count, query.PageSize, query.PageNumber);
    }
}