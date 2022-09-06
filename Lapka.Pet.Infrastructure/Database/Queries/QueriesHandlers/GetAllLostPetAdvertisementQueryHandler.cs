using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class
    GetAllLostPetAdvertisementQueryHandler : IQueryHandler<GetAllLostPetAdvertisementQuery,
        Application.Dto.PagedResult<LostPetAdvertisementDto>>
{
    private readonly DbSet<LostPetAdvertisement> _advertisements;
    private readonly DbSet<Core.Entities.Pet> _pets;

    public GetAllLostPetAdvertisementQueryHandler(AppDbContext context)
    {
        _pets = context.Pets;
        _advertisements = context.LostPetAdvertisements;
    }

    public async Task<Application.Dto.PagedResult<LostPetAdvertisementDto>> HandleAsync(GetAllLostPetAdvertisementQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var advertisements = await _advertisements.Where(x => x.IsVisible).ToListAsync();
        
        var result = advertisements.Join(_pets.
                Include(x => x.Photos), x => x.PetId.Value, x => x.Id.Value,
            (advertisements, pet) =>
                advertisements.AsDto(pet))
            .Skip(query.PageSize * (query.PageNumber - 1))
            .Take(query.PageSize)
            .ToList();

        var count = await _advertisements
            .Where(x => x.IsVisible)
            .CountAsync();

        return new Application.Dto.PagedResult<LostPetAdvertisementDto>(result,count,query.PageSize,query.PageNumber);
    }
}