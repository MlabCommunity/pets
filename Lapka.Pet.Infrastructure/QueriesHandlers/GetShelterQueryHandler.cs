using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetShelterQueryHandler : IQueryHandler<GetShelterQuery, ShelterDto>
{
    private readonly DbSet<Shelter> _shelters;

    public GetShelterQueryHandler(AppDbContext context)
    {
        _shelters = context.Shelters;
    }

    public async Task<ShelterDto> HandleAsync(GetShelterQuery query,
        CancellationToken cancellationToken = new CancellationToken())
        => await _shelters.Where(x => x.Id == query.Id)
            .Select(x => x.AsDto())
            .FirstOrDefaultAsync();
}