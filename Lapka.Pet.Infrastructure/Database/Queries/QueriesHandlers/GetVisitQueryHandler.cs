using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetVisitQueryHandler : IQueryHandler<GetVisitQuery, VisitDto>
{
    private readonly DbSet<Core.Entities.Pet> _pets;
    private readonly DbSet<Visit> _visits;

    public GetVisitQueryHandler(AppDbContext context)
    {
        _visits = context.Visits;
        _pets = context.Pets;
    }

    public async Task<VisitDto> HandleAsync(GetVisitQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var pet = await _pets
            .Include(x => x.Visits)
            .ThenInclude(x=>x.VisitTypes)
            .FirstOrDefaultAsync(x=>x.Id==query.PetId && x.OwnerId ==query.PrincipalId);

        return pet.Visits.Select(x => x.AsVisitDto()).FirstOrDefault(x => x.VisitId == query.VisitId);
    }
}