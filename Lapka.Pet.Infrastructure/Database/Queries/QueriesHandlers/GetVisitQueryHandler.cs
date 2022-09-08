using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

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
        => await _pets.Where(x => x.Id == query.PetId && x.OwnerId == query.PrincipalId)
            .Include(x => x.Visits)
            .ThenInclude(x => x.VisitTypes)
            .Select(x => x.Visits
                .FirstOrDefault(x => x.VisitId == query.VisitId).AsVisitDetailsDto())
            .FirstOrDefaultAsync();


}