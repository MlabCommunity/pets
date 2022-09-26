using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetArchiveStatsInMonthQueryHandler : IQueryHandler<GetArchiveStatsInMonthQuery, MonthDto>
{
    private readonly IUserCacheStorage _cacheStorage;
    private readonly DbSet<Shelter> _shelters;

    public GetArchiveStatsInMonthQueryHandler(AppDbContext context, IUserCacheStorage cacheStorage)
    {
        _shelters = context.Shelters;
        _cacheStorage = cacheStorage;
    }


    public async Task<MonthDto> HandleAsync(GetArchiveStatsInMonthQuery query,
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


        return new MonthDto
        {
            Monday = archives.Where(x => x.CreatedAt.DayOfWeek == DayOfWeek.Monday).Count(),
            Tuesday = archives.Where(x => x.CreatedAt.DayOfWeek == DayOfWeek.Tuesday).Count(),
            Wednesday = archives.Where(x => x.CreatedAt.DayOfWeek == DayOfWeek.Wednesday).Count(),
            Thursday = archives.Where(x => x.CreatedAt.DayOfWeek == DayOfWeek.Thursday).Count(),
            Friday = archives.Where(x => x.CreatedAt.DayOfWeek == DayOfWeek.Friday).Count(),
            Saturday = archives.Where(x => x.CreatedAt.DayOfWeek == DayOfWeek.Saturday).Count(),
            Sunday = archives.Where(x => x.CreatedAt.DayOfWeek == DayOfWeek.Sunday).Count(),
        };
    }
}