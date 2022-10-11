using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetAllPetsQueryHandler : Convey.CQRS.Queries.IQueryHandler<GetAllPetsQuery, PagedResult<PetDto>>
{
    private readonly DbSet<Core.Entities.Pet> _pets;

    public GetAllPetsQueryHandler(AppDbContext context)
    {
        _pets = context.Pets;
    }

    public async Task<PagedResult<PetDto>> HandleAsync(GetAllPetsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _pets
            .Where(x => x.OwnerId == query.PrincipalId)
            .Skip(query.PageSize * (query.PageNumber - 1))
            .Take(query.PageSize)
            .Select(x => x.AsDto()).ToListAsync();

        var count = await _pets
            .Where(x => x.OwnerId == query.PrincipalId)
            .CountAsync();
        return new PagedResult<PetDto>(result, count, query.PageSize, query.PageNumber);
    }
}