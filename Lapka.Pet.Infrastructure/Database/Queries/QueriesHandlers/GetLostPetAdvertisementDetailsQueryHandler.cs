using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class
    GetLostPetAdvertisementDetailsQueryHandler : IQueryHandler<GetLostPetAdvertisementDetailsQuery,
        LostPetAdvertisementDetailsDto>
{
    private readonly DbSet<LostPetAdvertisement> _advertisements;
    private readonly DbSet<Core.Entities.Pet> _pets;

    public GetLostPetAdvertisementDetailsQueryHandler(AppDbContext context)
    {
        _pets = context.Pets;
        _advertisements = context.LostPetAdvertisements;
    }

    public async Task<LostPetAdvertisementDetailsDto> HandleAsync(GetLostPetAdvertisementDetailsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var pet = await _pets.Include(x => x.Photos).FirstOrDefaultAsync(x => x.Id == query.PetId);

        var advertisements = await _advertisements.FirstOrDefaultAsync(x => x.PetId == query.PetId);

        return advertisements.AsDetailsDto(pet);
    }
}