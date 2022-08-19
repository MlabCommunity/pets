using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Infrastructure.Database.Queries;

public record GetAllShelterAdvertisementQuery : IQuery<List<ShelterAdvertisementDto>>;