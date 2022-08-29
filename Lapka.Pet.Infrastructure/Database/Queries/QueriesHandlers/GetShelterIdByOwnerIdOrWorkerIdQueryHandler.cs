using Convey.CQRS.Queries;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries;

internal sealed class
    GetShelterIdByOwnerIdOrWorkerIdQueryHandler : IQueryHandler<GetShelterIdByOwnerIdOrWorkerIdQuery, Guid>
{
    private readonly DbSet<Shelter> _shelters;

    public GetShelterIdByOwnerIdOrWorkerIdQueryHandler(AppDbContext context)
    {
        _shelters = context.Shelters;
    }

    public async Task<Guid> HandleAsync(GetShelterIdByOwnerIdOrWorkerIdQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var id = _shelters
            .Include(x => x.Workers)
            .Where(x => x.Workers.Any(x => x.WorkerId == query.PrincipalId) || x.Id == query.PrincipalId)
            .Select(x => x.Id.Value);

        return await id.FirstAsync();
    }
}