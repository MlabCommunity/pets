using AutoMapper;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

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
        var shelters = await _shelterAdvertisements
            .AsNoTracking()
            .Include(x => x.Shelter)
            .Where(x => x.IsVisible == true).ToListAsync();


        var result = shelters.Join(_pet, advertisement => advertisement.PetId.Value, pet => pet.Id.Value,
            (advertisements, pet) => new ShelterAdvertisementDto
            {
                Id = advertisements.Id,
                OrganizationName = advertisements.OrganizationName,
                Localization = advertisements.Localization.ToString(),
                IsReserved = advertisements.IsReserved,
                Description = advertisements.Description,
                Pet = new PetDto
                {
                    DateOfBirth = pet.DateOfBirth,
                    Gender = pet.Gender,
                    Id = pet.Id,
                    IsSterilized = pet.IsSterilized,
                    Photos = pet.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Name = pet.Name,
                    Type = pet.Type,
                    Weight = pet.Weight
                }
            }).ToList();


        return result;
    }
}