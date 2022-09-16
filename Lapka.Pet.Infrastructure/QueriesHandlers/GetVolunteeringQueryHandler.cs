using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetVolunteeringQueryHandler : IQueryHandler<GetVolunteeringQuery, VolunteeringDto>
{
    private readonly DbSet<Shelter> _shelters;

    public GetVolunteeringQueryHandler(AppDbContext context)
    {
        _shelters = context.Shelters;
    }

    public async Task<VolunteeringDto> HandleAsync(GetVolunteeringQuery query,
        CancellationToken cancellationToken = new CancellationToken())
        => await _shelters
            .AsNoTracking()
            .Where(x => x.Id == query.ShelterId)
            .Include(x => x.Volunteering)
            .Select(x => x.Volunteering.AsDto()).FirstOrDefaultAsync();
}