using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class
    GetAllShelterAdvertisementQueryHandler : IQueryHandler<GetAllShelterAdvertisementQuery,
        Application.Dto.PagedResult<ShelterPetAdvertisementDto>>
{
    private readonly DbSet<ShelterAdvertisement> _shelterAdvertisements;
    private readonly DbSet<Core.Entities.Pet> _pet;

    public GetAllShelterAdvertisementQueryHandler(AppDbContext context)
    {
        _shelterAdvertisements = context.ShelterAdvertisements;
        _pet = context.Pets;
    }

    public async Task<Application.Dto.PagedResult<ShelterPetAdvertisementDto>> HandleAsync(
        GetAllShelterAdvertisementQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var advertisements = await _shelterAdvertisements
            .Where(x => x.IsVisible == true)
            .ToListAsync();

        var pets = await _pet.Include(x => x.Photos)
            .Where(x => ((query.Type == null || query.Type == x.Type) &&
                         (query.Gender == null || query.Gender == x.Gender)))
            .ToListAsync();

        var result = advertisements.Join(pets
                    .Where(x => ((query.Type == null || query.Type == x.Type) &&
                                 (query.Gender == null || query.Gender == x.Gender))), //Dumny jestem z tego query 
                advertisement => advertisement.PetId.Value, pet => pet.Id.Value,
                (advertisements, pet) => advertisements.AsDto(pet))
            .Skip(query.PageSize * (query.PageNumber - 1))
            .Take(query.PageSize)
            .ToList();

        var count = await _shelterAdvertisements
            .Where(x => x.IsVisible == true)
            .CountAsync();

        return new Application.Dto.PagedResult<ShelterPetAdvertisementDto>(result, count, query.PageSize, query.PageNumber);
    }
}