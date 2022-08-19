using AutoMapper;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetPetQueryHandler : IQueryHandler<GetPetQuery, PetDto>
{
    private readonly DbSet<Core.Entities.Pet> _pets;
    private readonly IMapper _mapper;

    public GetPetQueryHandler(AppDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _pets = context.Pets;
    }

    public async Task<PetDto> HandleAsync(GetPetQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var pet = await _pets.FirstOrDefaultAsync(p => p.Id == query.PetId);

        return _mapper.Map<PetDto>(pet);
    }
}