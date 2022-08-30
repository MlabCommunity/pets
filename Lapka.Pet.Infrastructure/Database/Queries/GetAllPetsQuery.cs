using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Infrastructure.Database.Queries;

public record GetAllPetsQuery(Guid PrincipalId) :IQuery<List<PetDto>>;