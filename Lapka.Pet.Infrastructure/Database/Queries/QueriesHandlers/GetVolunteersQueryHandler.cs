using AutoMapper;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetVolunteersQueryHandler : IQueryHandler<GetVolunteersQuery,List<VolunteerDto>>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly DbSet<Shelter> _shelters;
    private readonly IMapper _mapper;
    
    public GetVolunteersQueryHandler(PetDbContext context, IMapper mapper, IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
        _mapper = mapper;
        _shelters = context.Shelters;
    }
    
    public async Task<List<VolunteerDto>> HandleAsync(GetVolunteersQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByUserIdOrWorkerIdAsync(query.PrincipalId);
        
        return _mapper.Map<List<VolunteerDto>>(shelter.Volunteers);
    }
}