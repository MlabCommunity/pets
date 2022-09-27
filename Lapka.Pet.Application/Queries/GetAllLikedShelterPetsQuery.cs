using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Application.Queries;

public record GetAllLikedShelterPets(Guid PrincipalId) : IQuery<LikedShelterPetsDto>;