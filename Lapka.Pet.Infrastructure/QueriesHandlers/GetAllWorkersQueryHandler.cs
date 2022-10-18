using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class
    GetAllWorkersQueryHandler : IQueryHandler<GetAllWorkersQuery, Application.Dto.PagedResult<WorkerDto>>
{
    private readonly DbSet<Shelter> _shelters;

    public GetAllWorkersQueryHandler(AppDbContext context)
    {
        _shelters = context.Shelters;
    }

    public async Task<Application.Dto.PagedResult<WorkerDto>> HandleAsync(GetAllWorkersQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var workers = await _shelters
            .Include(x => x.Workers)
            .Where(x => x.Id == query.PrincipalId)
            .Select(x => x.Workers
                .Select(x => x.AsDto())
                .ToList())
            .FirstOrDefaultAsync();

        var count = workers.Count();

        return new Application.Dto.PagedResult<WorkerDto>(workers, count, query.PageSize, query.PageNumber);
    }
}