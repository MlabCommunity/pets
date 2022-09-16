using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class VisitMapper
{
    
    public static VisitDto AsVisitDto(this Visit visit)
        => new()
        {
            VisitId = visit.VisitId,
            Description = visit.Description,
            DateOfVisit = visit.DateOfVisit,
        };
}