using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Queries;


public record GetAllLikedPetsQuery(Guid PrincipalId,PetType? Type, Gender? Gender,double Longitude,double Latitude, int PageNumber = 1, int PageSize = 10) : IQuery<Dto.PagedResult<ShelterPetAdvertisementDto>>;
