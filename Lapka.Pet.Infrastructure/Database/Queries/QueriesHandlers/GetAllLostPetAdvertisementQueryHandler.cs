using AutoMapper;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class
    GetAllLostPetAdvertisementQueryHandler : IQueryHandler<GetAllLostPetAdvertisementQuery,
        List<LostPetAdvertisementDto>>
{
    private readonly DbSet<LostPetAdvertisement> _advertisements;
    private readonly DbSet<Core.Entities.Pet> _pets;
    private readonly IMapper _mapper;

    public GetAllLostPetAdvertisementQueryHandler(AppDbContext context, IMapper mapper)
    {
        _pets = context.Pets;
        _advertisements = context.LostPetAdvertisements;
        _mapper = mapper;
    }

    public async Task<List<LostPetAdvertisementDto>> HandleAsync(GetAllLostPetAdvertisementQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var advertisements = await _advertisements
            .Where(x => x.IsVisible == true).ToListAsync();

        var result = advertisements
            .Join(_pets, x => x.PetId.Value, x => x.Id.Value, (advertisements, pet) => new LostPetAdvertisementDto
            {
                CityOfDisappearance = advertisements.CityOfDisappearance,
                StreetOfDisappearance = advertisements.StreetOfDisappearance,
                DateOfDisappearance = advertisements.DateOfDisappearance,
                Description = advertisements.Description,
                Pet = new PetDto
                {
                    DateOfBirth = pet.DateOfBirth,
                    Gender = pet.Gender,
                    Id = pet.Id,
                    IsSterilized = pet.IsSterilized,
                    Name = pet.Name,
                    Photos = pet.Photos.Select(x => x.PhotoId.Value).ToList(),
                    Type = pet.Type,
                    Weight = pet.Weight
                }
            }).ToList();

        return result;
    }
}