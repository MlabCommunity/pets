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

    public GetVisitQueryHandler(AppDbContext context)
    {
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