using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class
    GetAllLostPetAdvertisementQueryHandler : IQueryHandler<GetAllLostPetAdvertisementQuery,
        List<LostPetAdvertisementDto>>
{
    private readonly DbSet<LostPetAdvertisement> _advertisements;
    private readonly DbSet<Core.Entities.Pet> _pets;

    public GetAllLostPetAdvertisementQueryHandler(AppDbContext context)
    {
        _pets = context.Pets;
        _advertisements = context.LostPetAdvertisements;
    }

    public async Task<List<LostPetAdvertisementDto>> HandleAsync(GetAllLostPetAdvertisementQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        
        var result = _advertisements.Where(x => x.IsVisible).ToList()
            .Join(_pets.Include(x => x.Photos), x => x.PetId.Value, x => x.Id.Value, (advertisements, pet) =>
                advertisements.AsDto(pet)).ToList();

        return result;
    }
}