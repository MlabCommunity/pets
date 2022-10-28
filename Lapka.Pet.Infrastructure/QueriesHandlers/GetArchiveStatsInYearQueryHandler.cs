using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetArchiveStatsInYearQueryHandler : IQueryHandler<GetArchiveStatsInYearQuery, int[]>
{
    private readonly IUserCacheStorage _cacheStorage;
    private readonly DbSet<Shelter> _shelters;

    public GetArchiveStatsInYearQueryHandler(AppDbContext context, IUserCacheStorage cacheStorage)
    {
        _shelters = context.Shelters;
        _cacheStorage = cacheStorage;
    }

    public async Task<int[]> HandleAsync(GetArchiveStatsInYearQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(query.PrincipalId);

        var archives = await _shelters
            .Include(x => x.Archives.Where(x => x.CreatedAt.Year == DateTime.UtcNow.Year))
            .Where(x => x.Id == shelterId)
            .Select(x => x.Archives)
            .FirstOrDefaultAsync();

        var groupedArchives = archives.GroupBy(x => (int)x.CreatedAt.Month);
        var result = new int[12];

        foreach (var archive in groupedArchives)
        {
            result[archive.Key - 1] = archive.Count();
        }

        return result;
    }
}