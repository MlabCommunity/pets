using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetAllLikedPetsQueryHandler : IQueryHandler<GetAllLikedPetsQuery, Application.Dto.PagedResult<ShelterPetAdvertisementDto>>
{
    private readonly DbSet<ShelterPet> _shelterPets;


    public GetAllLikedPetsQueryHandler(AppDbContext context)
    {
        _shelterPets = context.ShelterPets;
    }


    public async Task<Application.Dto.PagedResult<ShelterPetAdvertisementDto>> HandleAsync(GetAllLikedPetsQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var pets = await _shelterPets
            .Include(x => x.Photos)
            .Include(x => x.Localization)
            .Include(x=>x.Likes)
            .Where(x => x.IsVisible == true && x.Likes.Any(x=>x.UserId==query.PrincipalId) && 
                        (query.Type == null || query.Type == x.Type)  &&
                        (query.Gender == null || query.Gender == x.Gender))
            .Select(x => x.AsAdvertisementDto(query.Latitude, query.Longitude))
            .ToListAsync();

        var result = pets 
            .OrderBy(x => x.Distance)
            .Skip(query.PageSize * (query.PageNumber - 1))
            .Take(query.PageSize).ToList();

        var count = pets.Count();
        
        return new Application.Dto.PagedResult<ShelterPetAdvertisementDto>
            (result, count, query.PageSize, query.PageNumber);
    }
}