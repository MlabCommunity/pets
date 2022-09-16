using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class
    GetLostPetAdvertisementDetailsQueryHandler : IQueryHandler<GetLostPetAdvertisementDetailsQuery,
        LostPetAdvertisementDetailsDto>
{
    private readonly DbSet<LostPet> _lostPets;
    
    public GetLostPetAdvertisementDetailsQueryHandler(AppDbContext context)
    {
        _lostPets = context.LostPets;
    }

    public async Task<LostPetAdvertisementDetailsDto> HandleAsync(GetLostPetAdvertisementDetailsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    => await _lostPets
        .Include(x=>x.Localization)
        .Include(x => x.Photos)
        .Where(x=>x.Id==query.PetId)
        .Select(x=>x.AsDetailsDto(query.Longitude,query.Latitude))
        .FirstOrDefaultAsync();

}