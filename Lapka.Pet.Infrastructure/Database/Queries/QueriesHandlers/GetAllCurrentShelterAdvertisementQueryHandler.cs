using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class
    GetAllCurrentShelterAdvertisementQueryHandler : IQueryHandler<GetAllCurrentShelterAdvertisementQuery,
        List<CurrentShelterAdvertisementDetailsDto>>
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

    public async Task<List<CurrentShelterAdvertisementDetailsDto>> HandleAsync(
        GetAllCurrentShelterAdvertisementQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(query.PrincipalId);
        var advertisements = await _advertisements
            .Where(x => x.ShelterId == shelterId).ToListAsync();
        var result =
            advertisements.Join(_pet.Include(x => x.Photos), x => x.PetId.Value, x => x.Id.Value,
                (advertisement, pet) =>
                    advertisement.AsCurrentShelterAdvertisementDto(pet)).ToList();

        return result;
    }
}