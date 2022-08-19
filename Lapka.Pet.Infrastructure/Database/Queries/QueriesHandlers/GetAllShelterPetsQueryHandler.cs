using AutoMapper;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetAllShelterPetsQueryHandler : IQueryHandler<GetAllShelterPetsQuery, List<PetDto>>
{
    private readonly DbSet<Core.Entities.Pet> _pets;
    private readonly DbSet<Shelter> _shelters;
    private readonly IMapper _mapper;

    public GetAllShelterPetsQueryHandler(AppDbContext context, IMapper mapper)
    {
        _shelters = context.Shelters;
        _pets = context.Pets;
        _mapper = mapper;
    }

    public async Task<List<PetDto>> HandleAsync(GetAllShelterPetsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelters
            .Include(x => x.Workers)
            .FirstOrDefaultAsync(x => x.Workers.Contains(query.PrincipalId) || x.Id == query.PrincipalId,cancellationToken);

        var pets = _pets.Where(x => x.OwnerId == shelter.Id.Value).ToList();

        return _mapper.Map<List<PetDto>>(pets);
    }
}