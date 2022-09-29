using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Queries;

public record GetAllShelterAdvertisementQuery
    (Guid PrincipalId,PetType? Type, Gender? Gender,double Longitude,double Latitude, int PageNumber = 1, int PageSize = 10) : Convey.CQRS.Queries.IQuery<
        PagedResult<ShelterPetAdvertisementDto>>;