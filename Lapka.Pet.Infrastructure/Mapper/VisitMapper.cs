using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class VisitMapper
{
    
    public static VisitDetailsDto AsVisitDetailsDto(this Visit visit)
        => new()
        {
            VisitId = visit.VisitId,
            Description = visit.Description,
            HasTookPlace = visit.HasTookPlace,
            WeightOnVisit = visit.WeightOnVisit,
            DateOfVisit = visit.DateOfVisit,
            VisitType = visit.VisitTypes
        };
    
    public static VisitDto AsVisitDto(this Visit visit)
        => new()
        {
            VisitId = visit.VisitId,
            Description = visit.Description,
            DateOfVisit = visit.DateOfVisit,
        };
    
}