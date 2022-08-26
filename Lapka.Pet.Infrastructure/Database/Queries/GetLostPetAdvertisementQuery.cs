using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Infrastructure.Database.Queries;

public record GetLostPetAdvertisementQuery(Guid PetId) : IQuery<LostPetAdvertisementDto>;