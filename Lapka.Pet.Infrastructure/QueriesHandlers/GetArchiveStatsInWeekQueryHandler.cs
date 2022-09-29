using System.Globalization;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetArchiveStatsInWeekQueryHandler : IQueryHandler<GetArchiveStatsInWeekQuery, int[]>
{
    private readonly IUserCacheStorage _cacheStorage;
    private readonly DbSet<Shelter> _shelters;

    public GetArchiveStatsInWeekQueryHandler(AppDbContext context, IUserCacheStorage cacheStorage)
    {
        _shelters = context.Shelters;
        _cacheStorage = cacheStorage;
    }


    public async Task<int[]> HandleAsync(GetArchiveStatsInWeekQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(query.PrincipalId);

        var archives = await _shelters
            .Include(x => x.Archives.Where(x =>
                x.CreatedAt.Year == DateTime.UtcNow.Year &&
                ISOWeek.GetWeekOfYear(DateTime.UtcNow) ==
                ISOWeek.GetWeekOfYear(x.CreatedAt)))
            .Where(x => x.Id == shelterId)
            .Select(x => x.Archives)
            .FirstOrDefaultAsync();
        
        var groupedArchives = archives.GroupBy(x => (int)x.CreatedAt.DayOfWeek);
        var result = new int[7];
        
        foreach (var archive in groupedArchives)
        {
            if (archive.Key == 0)
            {
                result[6] = archive.Count();     
            }
            result[archive.Key - 1] = archive.Count();
        }
        
        return result;
    }
}