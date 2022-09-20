using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetAllSheltersQueryHandler: IQueryHandler<GetAllSheltersQuery,Application.Dto.PagedResult<ShelterDto>>
{
    private readonly DbSet<Shelter> _shelters;

    public GetAllSheltersQueryHandler(AppDbContext context)
    {
        _shelters = context.Shelters;
    }


    public async Task<Application.Dto.PagedResult<ShelterDto>> HandleAsync(GetAllSheltersQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var shelters =await _shelters
            .Include(x=>x.Localization)
            .Select(x => x.AsDto(query.Longitude, query.Latitude)).ToListAsync();
        
        var result = shelters
            .OrderBy(x => x.Distance)
            .Skip(query.PageSize * (query.PageNumber - 1))
            .Take(query.PageSize).ToList();

        var count = shelters.Count();
        
        return new Application.Dto.PagedResult<ShelterDto>(result, count, query.PageSize, query.PageNumber);
    }
}