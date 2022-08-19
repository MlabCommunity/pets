using AutoMapper;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class
    GetAllShelterAdvertisementQueryHandler : IQueryHandler<GetAllShelterAdvertisementQuery,
        List<ShelterAdvertisementDto>>
{
    private readonly DbSet<ShelterAdvertisement> _shelterAdvertisements;
    private readonly DbSet<Core.Entities.Pet> _pet;
    private readonly IMapper _mapper;

    public GetAllShelterAdvertisementQueryHandler(AppDbContext context, IMapper mapper)
    {
        _shelterAdvertisements = context.ShelterAdvertisements;
        _pet = context.Pets;
        _mapper = mapper;
    }

    public async Task<List<ShelterAdvertisementDto>> HandleAsync(GetAllShelterAdvertisementQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var result =  _shelterAdvertisements.Include(x => x.Shelter)
            .Where(x=>x.IsVisible == true)
            .Join(_pet, advertisement => advertisement.PetId.Value, pet => pet.Id.Value,
            (advertisements, pet) => new ShelterAdvertisementDto
            {
                Id = advertisements.Id,
                OrganizationName = advertisements.Shelter.OrganizationName,
                Localization = advertisements.Shelter.GetLocalization(),
                IsReserved = advertisements.IsReserved,
                Description = advertisements.Description,
                Pet = _mapper.Map<PetDto>(pet)
            });

        return _mapper.Map<List<ShelterAdvertisementDto>>(result);
    }
}