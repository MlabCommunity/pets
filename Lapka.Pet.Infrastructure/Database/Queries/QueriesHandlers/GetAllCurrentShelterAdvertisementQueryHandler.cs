using AutoMapper;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class
    GetAllCurrentShelterAdvertisementQueryHandler : IQueryHandler<GetAllCurrentShelterAdvertisementQuery,
        List<CurrentShelterAdvertisementDto>>
{
    private readonly DbSet<Shelter> _shelters;
    private readonly DbSet<Core.Entities.Pet> _pet;
    private readonly IMapper _mapper;


    public GetAllCurrentShelterAdvertisementQueryHandler(AppDbContext context, IShelterRepository shelterRepository,
        IMapper mapper)
    {
        _shelters = context.Shelters;
        _pet = context.Pets;
        _mapper = mapper;
    }

    public async Task<List<CurrentShelterAdvertisementDto>> HandleAsync(GetAllCurrentShelterAdvertisementQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelters.Include(x => x.Advertisements)
            .Include(x => x.Workers)
            .FirstOrDefaultAsync(x => x.Workers.Contains(query.PrincipalId) || x.Id == query.PrincipalId,cancellationToken);

        var result = shelter.Advertisements.Join(_pet,x=>x.PetId.Value,x=>x.Id.Value,(advertisement, pet) =>new CurrentShelterAdvertisementDto
        {
            Id = advertisement.Id,
            IsVisible = advertisement.IsReserved,
            OrganizationName = advertisement.Shelter.OrganizationName,
            Localization = advertisement.Shelter.GetLocalization(),
            IsReserved = advertisement.IsReserved,
            Description = advertisement.Description,
            Pet = _mapper.Map<PetDto>(pet)
        });
        
        return _mapper.Map<List<CurrentShelterAdvertisementDto>>(result);
    }
}