using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetWorkersQueryHandler : IQueryHandler<GetWorkersQuery, List<WorkerDto>>
{
    private readonly DbSet<Shelter> _shelters;

    public GetWorkersQueryHandler(AppDbContext context)
    {
        _shelters = context.Shelters;
    }

    public async Task<List<WorkerDto>> HandleAsync(GetWorkersQuery query,
        CancellationToken cancellationToken = new CancellationToken())
        => await _shelters
            .Include(x => x.Workers)
            .Where(x => x.Id == query.PrincipalId)
            .Select(x => x.Workers.Select(x => x.AsDto()).ToList())
            .FirstOrDefaultAsync();
}