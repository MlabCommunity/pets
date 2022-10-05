using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class VisitMapper
{
    public static VisitDto AsLastVisitDto(this Visit visit)
        => new()
        {
            HasTookPlace = visit.HasTookPlace,
            VisitId = visit.VisitId,
            Description = visit.Description,
            DateOfVisit = visit.DateOfVisit,
        };

    public static VisitDto AsIncomingVisitDto(this Visit visit)
        => new()
        {
            HasTookPlace = null,
            VisitId = visit.VisitId,
            Description = visit.Description,
            DateOfVisit = visit.DateOfVisit,
        };
}