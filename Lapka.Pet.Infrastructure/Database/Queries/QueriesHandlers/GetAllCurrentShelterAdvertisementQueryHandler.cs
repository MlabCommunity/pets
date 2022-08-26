using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class
    GetAllCurrentShelterAdvertisementQueryHandler : IQueryHandler<GetAllCurrentShelterAdvertisementQuery,
        List<CurrentShelterAdvertisementDetailsDto>>
{
    private readonly DbSet<Shelter> _shelters;
    private readonly DbSet<Core.Entities.Pet> _pet;

    public GetAllCurrentShelterAdvertisementQueryHandler(AppDbContext context
    )
    {
        _shelters = context.Shelters;
        _pet = context.Pets;
    }

    public async Task<List<CurrentShelterAdvertisementDetailsDto>> HandleAsync(
        GetAllCurrentShelterAdvertisementQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelters
            .AsNoTracking()
            .Include(x => x.Advertisements)
            .Include(x => x.Workers)
            .FirstOrDefaultAsync(x => x.Workers.Any(w => w.WorkerId == query.PrincipalId) || x.Id == query.PrincipalId);

        var result = shelter.Advertisements.Join(_pet.Include(x => x.Photos), x => x.PetId.Value, x => x.Id.Value,
            (advertisement, pet) =>
                advertisement.AsCurrentShelterDto(pet)).ToList();

        return result;
    }
}