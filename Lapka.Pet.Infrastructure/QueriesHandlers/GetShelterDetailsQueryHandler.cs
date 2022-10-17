using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetShelterDetailsQueryHandler : IQueryHandler<GetShelterDetailsQuery, ShelterDetailsDto>
{
    private readonly DbSet<Shelter> _shelters;

    public GetShelterDetailsQueryHandler(AppDbContext context)
    {
        _shelters = context.Shelters;
    }

    public async Task<ShelterDetailsDto> HandleAsync(GetShelterDetailsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
        => await _shelters
            .Include(x => x.Localization)
            .Include(x=>x.Volunteering)
            .Where(x => x.Id == query.ShelterId)
            .Select(x => x.AsDetailsDto())
            .FirstOrDefaultAsync();
}