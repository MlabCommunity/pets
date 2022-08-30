using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetVolunteeringQueryHandler : IQueryHandler<GetVolunteeringQuery, VolunteeringDto>
{
    private readonly DbSet<Shelter> _shelters;

    public GetVolunteeringQueryHandler(AppDbContext context)
    {
        _shelters = context.Shelters;
    }

    public async Task<VolunteeringDto> HandleAsync(GetVolunteeringQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelters
            // .AsNoTracking()
            .Include(x => x.Volunteering)
            .FirstOrDefaultAsync(x => x.Id == query.ShelterId);

        return shelter.Volunteering.AsDto();
    }
}