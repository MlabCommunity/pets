using Convey.CQRS.Queries;
using Lapka.Pet.Application.Dto;

namespace Lapka.Pet.Application.Queries;

public record GetAllVisitsQuery(Guid PetId, Guid PrincipalId, int IncomingVisitPageNumber = 1,
    int IncomingVisitPageSize = 10, int LastVisitPageNumber = 1, int LastVisitPageSize = 10) : IQuery<VisitResponseDto>;