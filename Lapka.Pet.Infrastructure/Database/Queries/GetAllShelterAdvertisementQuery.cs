using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Infrastructure.Database.Queries;

public record GetAllShelterAdvertisementQuery(PetType? Type, Gender? Gender,int PageNumber = 1, int PageSize = 10) : Convey.CQRS.Queries.IQuery<PagedResult<ShelterPetAdvertisementDto>>;