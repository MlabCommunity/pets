using AutoMapper;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetVolunteersQueryHandler : IQueryHandler<GetVolunteersQuery, List<VolunteerDto>>
{
    private readonly DbSet<Shelter> _shelters;
    private readonly IMapper _mapper;

    public GetVolunteersQueryHandler(AppDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _shelters = context.Shelters;
    }

    public async Task<List<VolunteerDto>> HandleAsync(GetVolunteersQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelters
            .Include(x => x.Volunteers)
            .Include(x => x.Workers)
            .FirstOrDefaultAsync(x => x.Workers.Contains(query.PrincipalId) || x.Id == query.PrincipalId,
                cancellationToken);


        return _mapper.Map<List<VolunteerDto>>(shelter.Volunteers);
    }
}