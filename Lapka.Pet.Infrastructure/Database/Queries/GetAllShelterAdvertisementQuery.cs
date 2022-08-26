using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Database.Queries;

public record GetAllShelterAdvertisementQuery(PetType? Type, Gender? Gender) : IQuery<List<ShelterPetAdvertisementDto>>;