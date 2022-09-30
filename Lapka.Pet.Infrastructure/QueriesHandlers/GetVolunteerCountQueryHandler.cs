using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetVolunteerCountQueryHandler : IQueryHandler<GetVolunteerCountQuery,VolunteerCountDto>
{
    private readonly DbSet<Shelter> _shelters;
    private readonly IUserCacheStorage _storage;

    public GetVolunteerCountQueryHandler(AppDbContext context, IUserCacheStorage storage)
    {
        _storage = storage;
        _shelters = context.Shelters;
    }


    public async Task<VolunteerCountDto> HandleAsync(GetVolunteerCountQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _storage.GetShelterId(query.PrincipalId);

        var count = await _shelters
            .Include(x => x.Volunteers)
            .Where(x => x.Id == shelterId)
            .Select(x => x.Volunteers.Count())
            .FirstOrDefaultAsync();

        return new VolunteerCountDto
        {
            Count = count
        };
    }
}