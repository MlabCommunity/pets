using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Lapka.Pet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetAllShelterAdvertisementQueryHandler : Convey.CQRS.Queries.IQueryHandler<
    GetAllShelterAdvertisementQuery,
    PagedResult<ShelterPetAdvertisementDto>>
{
    private readonly DbSet<ShelterPet> _shelterPets;

    public GetAllShelterAdvertisementQueryHandler(AppDbContext context)
    {
        _shelterPets = context.ShelterPets;
    }

    public async Task<PagedResult<ShelterPetAdvertisementDto>> HandleAsync(
        GetAllShelterAdvertisementQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var pets = await _shelterPets
            .Include(x => x.Photos)
            .Include(x => x.Localization)
            .Include(x => x.Likes)
            .Where(x => x.IsVisible == true &&
                        (query.Type == null || query.Type == x.Type) &&
                        (query.Gender == null || query.Gender == x.Gender))
            .Select(x => x.AsAdvertisementDto(query.Latitude, query.Longitude, query.PrincipalId))
            .ToListAsync();

        var result = pets
            .OrderBy(x => x.Distance)
            .Skip(query.PageSize * (query.PageNumber - 1))
            .Take(query.PageSize).ToList();

        var count = pets.Count();

        return new PagedResult<ShelterPetAdvertisementDto>
            (result, count, query.PageSize, query.PageNumber);
    }
}
