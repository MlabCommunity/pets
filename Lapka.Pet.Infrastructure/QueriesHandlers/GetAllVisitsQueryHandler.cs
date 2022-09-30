using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetAllVisitsQueryHandler : IQueryHandler<GetAllVisitsQuery, VisitResponseDto>
{
    private readonly DbSet<Core.Entities.Pet> _pets;

    public GetAllVisitsQueryHandler(AppDbContext context)
    {
        _pets = context.Pets;
    }

    public async Task<VisitResponseDto> HandleAsync(GetAllVisitsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var incomingVisits = await _pets
            .AsNoTracking()
            .Where(x => x.OwnerId == query.PrincipalId && x.Id == query.PetId)
            .Include(x => x.Visits)
            .ThenInclude(x => x.VisitTypes)
            .Select(x => x.Visits
                .Where(x => x.DateOfVisit > DateTime.UtcNow)
                .OrderBy(x => x.DateOfVisit)
                .Select(x => x.AsVisitDto())
                .Skip(query.IncomingVisitPageSize * (query.IncomingVisitPageNumber - 1))
                .Take(query.IncomingVisitPageSize)
                .ToList())
            .FirstOrDefaultAsync();

        var incomingVisitCount = await _pets.Include(x => x.Visits)
            .Where(x => x.OwnerId == query.PrincipalId && x.Id == query.PetId)
            .Select(x => x.Visits
                .Where(x => x.DateOfVisit > DateTime.UtcNow)
                .Count())
            .FirstOrDefaultAsync();

        var lastVisits = await _pets
            .AsNoTracking()
            .Where(x => x.OwnerId == query.PrincipalId && x.Id == query.PetId)
            .Include(x => x.Visits)
            .ThenInclude(x => x.VisitTypes)
            .Select(x => x.Visits
                .Where(x => x.DateOfVisit < DateTime.UtcNow)
                .OrderByDescending(x => x.DateOfVisit)
                .Select(x => x.AsVisitDto())
                .Skip(query.LastVisitPageSize * (query.LastVisitPageNumber - 1))
                .Take(query.LastVisitPageSize)
                .ToList())
            .FirstOrDefaultAsync();

        var lastVisitCount = await _pets
            .Include(x => x.Visits)
            .Where(x => x.OwnerId == query.PrincipalId && x.Id == query.PetId)
            .Select(x => x.Visits
                .Where(x => x.DateOfVisit > DateTime.UtcNow)
                .Count())
            .FirstOrDefaultAsync();

        return new VisitResponseDto
        {
            LastVisits = new Application.Dto.PagedResult<VisitDto>(lastVisits, lastVisitCount, query.LastVisitPageSize,
                query.LastVisitPageNumber),
            IncomingVisits = new Application.Dto.PagedResult<VisitDto>(incomingVisits, incomingVisitCount,
                query.IncomingVisitPageSize, query.IncomingVisitPageNumber)
        };
    }
}