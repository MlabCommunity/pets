using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetShelterQueryHandler : IQueryHandler<GetShelterQuery, ShelterDto>
{
    private readonly DbSet<Shelter> _shelters;
    private readonly IUserCacheStorage _cacheStorage;
    
    public GetShelterQueryHandler(AppDbContext context,IUserCacheStorage cacheStorage)
    {
        _cacheStorage = cacheStorage;
        _shelters = context.Shelters;
    }

    public async Task<ShelterDto> HandleAsync(GetShelterQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId =  _cacheStorage.GetShelterId(query.Id);
        
        return await _shelters
            .Where(x => x.Id == shelterId)
            .Select(x => x.AsDto())
            .FirstOrDefaultAsync();
    }
}