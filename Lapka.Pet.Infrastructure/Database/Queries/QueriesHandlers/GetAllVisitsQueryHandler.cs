using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetAllVisitsQueryHandler : IQueryHandler<GetAllVisitsQuery, List<VisitDto>>
{
    private readonly DbSet<Core.Entities.Pet> _pets;
    
    public GetAllVisitsQueryHandler(AppDbContext context)
    {
        _pets = context.Pets;
    }

    public async Task<List<VisitDto>> HandleAsync(GetAllVisitsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        
        var pet = await _pets
            .AsNoTracking()
            .Include(x => x.Visits)
            .ThenInclude(x=>x.VisitTypes)
            .FirstOrDefaultAsync(x => (x.OwnerId == query.PrincipalId && x.Id==query.PetId));

        return pet.AsVisitDtos();
    }
}