using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Application.Queries;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.QueriesHandlers;

internal sealed class GetAllLikedShelterPetsQueryHandler : IQueryHandler<GetAllLikedShelterPetsQuery,
    Application.Dto.PagedResult<LikedShelterPetsDto>>
{
    private readonly DbSet<ShelterPet> _shelters;
    private readonly IUserCacheStorage _storage;

    public GetAllLikedShelterPetsQueryHandler(AppDbContext context, IUserCacheStorage storage)
    {
        _storage = storage;
        _shelters = context.ShelterPets;
    }

    public async Task<Application.Dto.PagedResult<LikedShelterPetsDto>> HandleAsync(GetAllLikedShelterPetsQuery query,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _storage.GetShelterId(query.PrincipalId);

        var pets = await _shelters
            .Include(x => x.Likes)
            .Where(x => x.OwnerId == shelterId)
            .Select(x => x.AsLikedDto(x.Likes.Count()))
            .ToListAsync();

        var count = pets.Count();


        var result = pets
            .OrderByDescending(x => x.Count)
            .ThenByDescending(x => x.CreatedAt)
            .Skip(query.PageSize * (query.PageNumber - 1))
            .Take(query.PageSize).ToList();


        return new Application.Dto.PagedResult<LikedShelterPetsDto>(result, count, query.PageSize, query.PageNumber);
    }
}