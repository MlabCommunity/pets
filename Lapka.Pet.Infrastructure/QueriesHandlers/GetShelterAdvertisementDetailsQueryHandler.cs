using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class
    GetShelterAdvertisementDetailsQueryHandler : IQueryHandler<GetShelterAdvertisementDetailsQuery,
        ShelterPetAdvertisementDetailsDto>
{
    private readonly DbSet<ShelterPet> _shelterPets;


    public GetShelterAdvertisementDetailsQueryHandler(AppDbContext context)
    {
        _shelterPets = context.ShelterPets;
    }

    public async Task<ShelterPetAdvertisementDetailsDto> HandleAsync(GetShelterAdvertisementDetailsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
        => await _shelterPets
            .Include(x => x.Localization)
            .Include(x => x.Photos)
            .Where(x => x.Id == query.PetId)
            .Select(x => x.AsAdvertisementDetailsDto(query.Longitude, query.Latitude))
            .FirstOrDefaultAsync();
}