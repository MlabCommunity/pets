using AutoMapper;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetVolunteeringQueryHandler : IQueryHandler<GetVolunteeringQuery, VolunteeringDto>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IMapper _mapper;

    public GetVolunteeringQueryHandler(IShelterRepository shelterRepository, IMapper mapper)
    {
        _shelterRepository = shelterRepository;
        _mapper = mapper;
    }

    public async Task<VolunteeringDto> HandleAsync(GetVolunteeringQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByUserIdOrWorkerIdAsync(query.PrincipalId);
        
        return _mapper.Map<VolunteeringDto>(shelter.Volunteering);
    }
}