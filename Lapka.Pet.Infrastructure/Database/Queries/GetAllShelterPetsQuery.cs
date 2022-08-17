using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Infrastructure.Database.Queries.QueriesHandlers;

public record GetAllShelterPetsQuery(Guid PrincipalId) : IQuery<List<PetDto>>;