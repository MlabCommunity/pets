using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetPetQueryHandler : IQueryHandler<GetPetQuery, PetDto>
{
    private readonly DbSet<Core.Entities.Pet> _pets;

    public GetPetQueryHandler(AppDbContext context)
    {
        _pets = context.Pets;
    }

    public async Task<PetDto> HandleAsync(GetPetQuery query,
        CancellationToken cancellationToken = new CancellationToken())
        => await _pets
            .Where(p => p.Id == query.PetId)
            .Include(x => x.Photos)
            .Select(x => x.AsDto())
            .FirstOrDefaultAsync();
}