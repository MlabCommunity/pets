using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetArchiveStatsInYearQueryHandler : IQueryHandler<GetArchiveStatsInYearQuery,YearDto>
{
    
    private readonly IUserCacheStorage _cacheStorage;
    private readonly DbSet<Shelter> _shelters;

    public GetArchiveStatsInYearQueryHandler(AppDbContext context,IUserCacheStorage cacheStorage)
    {
        _shelters = context.Shelters;
        _cacheStorage = cacheStorage;
    }

    public async Task<YearDto> HandleAsync(GetArchiveStatsInYearQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(query.PrincipalId);

        var archives = await _shelters
            .Include(x => x.Archives.Where(x=>x.CreatedAt.Year==DateTime.UtcNow.Year))
            .Where(x => x.Id == shelterId)
            .Select(x => x.Archives)
            .FirstOrDefaultAsync();

 
        return new YearDto
        {
            January = archives.Where(x=>x.CreatedAt.Month==1).Count(),
            February = archives.Where(x=>x.CreatedAt.Month==2).Count(),
            March = archives.Where(x=>x.CreatedAt.Month==3).Count(),
            April = archives.Where(x=>x.CreatedAt.Month==4).Count(),
            May = archives.Where(x=>x.CreatedAt.Month==5).Count(),
            June = archives.Where(x=>x.CreatedAt.Month==6).Count(),
            July = archives.Where(x=>x.CreatedAt.Month==7).Count(),
            August = archives.Where(x=>x.CreatedAt.Month==8).Count(),
            September = archives.Where(x=>x.CreatedAt.Month==9).Count(),
            October = archives.Where(x=>x.CreatedAt.Month==10).Count(),
            November = archives.Where(x=>x.CreatedAt.Month==11).Count(),
            December = archives.Where(x=>x.CreatedAt.Month==12).Count(),
        };
    }
}