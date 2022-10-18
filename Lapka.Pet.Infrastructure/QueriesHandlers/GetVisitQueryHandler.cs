using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetVisitQueryHandler : IQueryHandler<GetVisitQuery, VisitDetailsDto>
{
    private readonly DbSet<Core.Entities.Pet> _pets;
    private readonly DbSet<Visit> _visits;

    public GetVisitQueryHandler(AppDbContext context)
    {
        _visits = context.Visits;
        _pets = context.Pets;
    }

    public async Task<VisitDetailsDto> HandleAsync(GetVisitQuery query,
        CancellationToken cancellationToken = new CancellationToken())
        => await _visits
            .Include(x => x.VisitTypes)
            .Include(x => x.Pet)
            .Where(x => x.VisitId == query.VisitId && x.Pet.OwnerId == query.PrincipalId)
            .Select(x => x.AsVisitDetailsDto()).FirstOrDefaultAsync();
}