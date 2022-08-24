using AutoMapper;
using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

internal sealed class GetAllShelterPetsQueryHandler : IQueryHandler<GetAllShelterPetsQuery, List<PetDto>>
{
    private readonly DbSet<Core.Entities.Pet> _pets;
    private readonly DbSet<Shelter> _shelters;


    public GetAllShelterPetsQueryHandler(AppDbContext context)
    {
        _shelters = context.Shelters;
        _pets = context.Pets;
    }

    public async Task<List<PetDto>> HandleAsync(GetAllShelterPetsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelters
            .AsNoTracking()
            .Include(x => x.Workers)
            .FirstOrDefaultAsync(x => x.Workers.Any(x => x.WorkerId == query.PrincipalId) || x.Id == query.PrincipalId);

        var result = await _pets
            .Include(x => x.Photos)
            .Where(x => x.OwnerId == shelter.Id.Value).Select(x=> new PetDto
            {
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender,
                Id = x.Id,
                IsSterilized = x.IsSterilized,
                Name = x.Name,
                Photos = x.Photos.Select(x=>x.PhotoId.Value).ToList(),
                Type = x.Type,
                Weight = x.Weight
            }).ToListAsync();


        return result;
    }
}