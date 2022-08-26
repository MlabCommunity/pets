using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class
    GetAllShelterAdvertisementQueryHandler : IQueryHandler<GetAllShelterAdvertisementQuery,
        List<ShelterPetAdvertisementDto>>
{
    private readonly DbSet<ShelterAdvertisement> _shelterAdvertisements;
    private readonly DbSet<Core.Entities.Pet> _pet;

    public GetAllShelterAdvertisementQueryHandler(AppDbContext context)
    {
        _shelterAdvertisements = context.ShelterAdvertisements;
        _pet = context.Pets;
    }

    public async Task<List<ShelterPetAdvertisementDto>> HandleAsync(GetAllShelterAdvertisementQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var result = _shelterAdvertisements
            .Where(x => x.IsVisible == true).ToList().Join(_pet
                    .Include(x => x.Photos)
                    .Where(x => ((query.Type == null || query.Type == x.Type) &&
                                 (query.Gender == null || query.Gender == x.Gender))), //Dumny jestem z tego query 
                advertisement => advertisement.PetId.Value, pet => pet.Id.Value,
                (advertisements, pet) => advertisements.AsDto(pet)).ToList();

        return result;
    }
}