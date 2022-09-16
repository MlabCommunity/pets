using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Application.Queries;

public record GetLostPetAdvertisementDetailsQuery(Guid PetId,double Longitude,double Latitude) : IQuery<LostPetAdvertisementDetailsDto>;