using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetPetQueryHandler : IQueryHandler<GetPetQuery,PetDto>
{
    private readonly DbSet<Core.Entities.Pet> _pets;

    public GetPetQueryHandler(PetDbContext context)
    {
        _pets = context.Pets;
    }

    public async Task<PetDto> HandleAsync(GetPetQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var pet = await _pets.FirstOrDefaultAsync(p => p.Id == query.PetId);
        
        if (pet == null)
        {
            throw new PetNotFoundException();
        }

        return PetExtensions.AsDto(pet);
    }
}