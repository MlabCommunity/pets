using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetVolunteersQueryHandler : IQueryHandler<GetVolunteersQuery, List<VolunteerDto>>
{
    private readonly DbSet<Shelter> _shelters;

    public GetVolunteersQueryHandler(AppDbContext context)
    {
        _shelters = context.Shelters;
    }

    public async Task<List<VolunteerDto>> HandleAsync(GetVolunteersQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelters
            .AsNoTracking()
            .Include(x => x.Volunteers)
            .Include(x => x.Workers)
            .FirstOrDefaultAsync(x => x.Workers.Any(x => x.WorkerId == query.PrincipalId) || x.Id == query.PrincipalId);

        return shelter.AsVolunteerDtos();
    }
}