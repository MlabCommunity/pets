using AutoMapper;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetShelterQueryHandler : IQueryHandler<GetShelterQuery,ShelterDto>
{
    
    private readonly DbSet<Shelter> _shelters;
    private readonly IMapper _mapper;


    public GetShelterQueryHandler(PetDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _shelters = context.Shelters;
    }
    
    public async Task<ShelterDto> HandleAsync(GetShelterQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelters.FirstOrDefaultAsync(x => x.UserId == query.UserId);

        return _mapper.Map<ShelterDto>(shelter);
    }
}