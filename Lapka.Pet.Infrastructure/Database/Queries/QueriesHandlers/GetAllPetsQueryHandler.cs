using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetAllPetsQueryHandler : IQueryHandler<GetAllPetsQuery, List<PetDto>>
{
    private readonly DbSet<Core.Entities.Pet> _pets;

    public GetAllPetsQueryHandler(AppDbContext context)
    {
        _pets = context.Pets;
    }

    public async Task<List<PetDto>> HandleAsync(GetAllPetsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
        => await _pets
            .Include(x=>x.Photos)
            .Where(x => x.OwnerId == query.PrincipalId)
            .Select(x => x.AsDto()).ToListAsync();
}