using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetAllVisitsQueryHandler : IQueryHandler<GetAllVisitsQuery, VisitDto>
{
    private readonly DbSet<Core.Entities.Pet> _pets;

    public GetAllVisitsQueryHandler(AppDbContext context)
    {
        _pets = context.Pets;
    }

    public async Task<VisitDto> HandleAsync(GetAllVisitsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
       var incomingVisits = await _pets
            .AsNoTracking()
            .Where(x => x.OwnerId == query.PrincipalId && x.Id == query.PetId)
            .Include(x => x.Visits)
            .ThenInclude(x => x.VisitTypes)
            
            .Select(x => x.Visits
                .Where(x=>x.DateOfVisit>DateTime.UtcNow)
                .Select(x => x.AsVisitDetailsDto()).ToList())
            .FirstOrDefaultAsync();
       
       var lastVisits = await _pets
           .AsNoTracking()
           .Where(x => x.OwnerId == query.PrincipalId && x.Id == query.PetId)
           .Include(x => x.Visits)
           .ThenInclude(x => x.VisitTypes)
           .Select(x => x.Visits
               .Where(x=>x.DateOfVisit<DateTime.UtcNow)
               .Select(x => x.AsVisitDetailsDto()).ToList())
           .FirstOrDefaultAsync();

       return new VisitDto
       {
           LastVisits = lastVisits,
           IncomingVisits = incomingVisits
       };
    }
        
}