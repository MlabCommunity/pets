using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetArchiveStatsInMonthQueryHandler : IQueryHandler<GetArchiveStatsInMonthQuery, int[]>
{
    private readonly IUserCacheStorage _cacheStorage;
    private readonly DbSet<Shelter> _shelters;

    public GetArchiveStatsInMonthQueryHandler(AppDbContext context, IUserCacheStorage cacheStorage)
    {
        _shelters = context.Shelters;
        _cacheStorage = cacheStorage;
    }


    public async Task<int[]> HandleAsync(GetArchiveStatsInMonthQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(query.PrincipalId);

        var archives = await _shelters
            .Include(x => x.Archives
                .Where(x =>
                    x.CreatedAt.Year == DateTime.UtcNow.Year && x.CreatedAt.Month == DateTime.UtcNow.Month))
            .Where(x => x.Id == shelterId)
            .Select(x => x.Archives)
            .FirstOrDefaultAsync();

        var groupedArchives = archives.GroupBy(x => x.CreatedAt.Day);
        var result = new int[DateTime.DaysInMonth(DateTime.UtcNow.Year, DateTime.UtcNow.Month)];

        foreach (var archive in groupedArchives)
        {
            result[archive.Key - 1] = archive.Count();
        }

        return result;
    }
}