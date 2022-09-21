using System.Data.Entity.SqlServer;
using System.Data.SqlTypes;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetArchiveStatsInYearQueryHandler : IQueryHandler<GetArchiveStatsInYearQuery,ChartInYearDto>
{

    private readonly DbSet<Archive> _archives;
    private readonly IUserCacheStorage _cacheStorage;
    private readonly DbSet<Shelter> _shelters;

    public GetArchiveStatsInYearQueryHandler(AppDbContext context,IUserCacheStorage cacheStorage)
    {
        _shelters = context.Shelters;
        _cacheStorage = cacheStorage;
        _archives = context.Archives;
    }

    public async Task<ChartInYearDto> HandleAsync(GetArchiveStatsInYearQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(query.PrincipalId);

        var archives =await _shelters
            .Where(x => x.Id == shelterId)
            .Select(x=>x.Archives)
            .FirstOrDefaultAsync();
        
        
        var sqlMinDate = (DateTime) SqlDateTime.MinValue;
        var result = archives
            .GroupBy(x => new { Month = x.CreatedAt.Month })
            .Select(x => x.Key.Month);


        return null;
    }
}