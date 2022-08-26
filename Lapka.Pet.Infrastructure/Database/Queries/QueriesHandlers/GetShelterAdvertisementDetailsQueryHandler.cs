using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class
    GetShelterAdvertisementDetailsQueryHandler : IQueryHandler<GetShelterAdvertisementDetailsQuery,
        ShelterAdvertisementDetailsDto>
{
    private readonly DbSet<ShelterAdvertisement> _shelterAdvertisements;
    private readonly DbSet<Core.Entities.Pet> _pet;


    public GetShelterAdvertisementDetailsQueryHandler(AppDbContext context)
    {
        _shelterAdvertisements = context.ShelterAdvertisements;
        _pet = context.Pets;
    }

    public async Task<ShelterAdvertisementDetailsDto> HandleAsync(GetShelterAdvertisementDetailsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var advertisement = await _shelterAdvertisements.FirstOrDefaultAsync(x => x.PetId == query.PetId);
        var pet = await _pet.Include(x => x.Photos).FirstOrDefaultAsync(x => x.Id == query.PetId);

        return advertisement.AsDetailsDto(pet);
    }
}