using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Infrastructure.Database.Queries;

public record GetAllShelterAdvertisementQuery(PetType? Type, Gender? Gender) : IQuery<List<ShelterPetAdvertisementDto>>;