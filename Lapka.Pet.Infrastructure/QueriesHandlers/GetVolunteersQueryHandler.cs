using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetVolunteersQueryHandler : IQueryHandler<GetVolunteersQuery, List<VolunteerDto>>
{
    private readonly IUserCacheStorage _cacheStorage;
    private readonly DbSet<Shelter> _shelters;

    public GetVolunteersQueryHandler(AppDbContext context, IUserCacheStorage cacheStorage)
    {
        _cacheStorage = cacheStorage;
        _shelters = context.Shelters;
    }

    public async Task<List<VolunteerDto>> HandleAsync(GetVolunteersQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(query.PrincipalId);

        var shelter = await _shelters
            .Include(x=>x.Volunteers)
            .FirstOrDefaultAsync(x => x.Id == shelterId);

        return shelter.Volunteers
            .Select(x=>x.AsDto())
            .ToList();
    }
}