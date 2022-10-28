using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetAllUserAdvertisementsQueryHandler : IQueryHandler<GetAllUserLostPetsQuery,
    Application.Dto.PagedResult<LostPetAdvertisementDto>>
{
    private readonly DbSet<LostPet> _lostPets;


    public GetAllUserAdvertisementsQueryHandler(AppDbContext _context)
    {
        _lostPets = _context.LostPets;
    }

    public async Task<Application.Dto.PagedResult<LostPetAdvertisementDto>> HandleAsync(GetAllUserLostPetsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _lostPets
            .Where(x => (query.Type == null || query.Type == x.Type) &&
                        (query.Gender == null || query.Gender == x.Gender) && x.IsVisible == true &&
                        x.OwnerId == query.PrincipalId)
            .OrderByDescending(x=>x.CreatedAt)
            .Select(x => x.AsDto())
            .Skip(query.PageSize * (query.PageNumber - 1))
            .Take(query.PageSize)
            .ToListAsync();

        var count = await _lostPets
            .Where(x => (query.Type == null || query.Type == x.Type) &&
                        (query.Gender == null || query.Gender == x.Gender) && x.IsVisible == true &&
                        x.OwnerId == query.PrincipalId)
            .CountAsync();

        return new Application.Dto.PagedResult<LostPetAdvertisementDto>(result, count, query.PageSize,
            query.PageNumber);
    }
}