using AutoMapper;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
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


    public GetAllCurrentShelterAdvertisementQueryHandler(AppDbContext context,
        IMapper mapper)
    {
        _shelters = context.Shelters;
        _pet = context.Pets;
        _mapper = mapper;
    }

    public async Task<List<CurrentShelterAdvertisementDto>> HandleAsync(GetAllCurrentShelterAdvertisementQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelters
            .AsNoTracking()
            .Include(x => x.Advertisements)
            .Include(x => x.Workers)
            .FirstOrDefaultAsync(x => x.Workers.Any(w => w.WorkerId == query.PrincipalId) || x.Id == query.PrincipalId);

        var result = shelter.Advertisements.Join(_pet, x => x.PetId.Value, x => x.Id.Value,
            (advertisement, pet) =>
                new CurrentShelterAdvertisementDto
                {
                    Id = advertisement.Id,
                    IsVisible = advertisement.IsReserved,
                    OrganizationName = advertisement.OrganizationName,
                    Localization = advertisement.Localization.ToString(),
                    IsReserved = advertisement.IsReserved,
                    Description = advertisement.Description,
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