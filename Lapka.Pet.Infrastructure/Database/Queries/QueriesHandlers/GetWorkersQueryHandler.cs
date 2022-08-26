using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetWorkersQueryHandler : IQueryHandler<GetWorkersQuery, List<WorkerDto>>
{
    private readonly DbSet<Shelter> _shelters;

    public GetWorkersQueryHandler(AppDbContext context)
    {
        _shelters = context.Shelters;
    }

    public async Task<List<WorkerDto>> HandleAsync(GetWorkersQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelters.Include(x => x.Workers).FirstOrDefaultAsync(x => x.Id == query.PrincipalId);

        return shelter.AsWorkerDtos();
    }
}