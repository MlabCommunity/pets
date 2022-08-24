using AutoMapper;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class
    GetLostPetAdvertisementQueryHandler : IQueryHandler<GetLostPetAdvertisementQuery, LostPetAdvertisementDto>
{
    private readonly DbSet<LostPetAdvertisement> _advertisements;
    private readonly DbSet<Core.Entities.Pet> _pets;

    public GetLostPetAdvertisementQueryHandler(AppDbContext context)
    {
        _pets = context.Pets;
        _advertisements = context.LostPetAdvertisements;
    }

    public async Task<LostPetAdvertisementDto> HandleAsync(GetLostPetAdvertisementQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var advertisements = await _advertisements
            .FirstOrDefaultAsync(x => x.PetId == query.PetId);

        var pet = await _pets.FirstOrDefaultAsync(x => x.Id == query.PetId);

        var result = new LostPetAdvertisementDto
        {
            Description = advertisements.Description,
            Localization = advertisements.Localization.ToString(),
            DateOfDisappearance = advertisements.DateOfDisappearance,
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
        };


        return result;
    }
}