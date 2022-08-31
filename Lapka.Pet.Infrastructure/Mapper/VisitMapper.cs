using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class VisitMapper
{
    public static List<VisitDto> AsVisitDtos(this Core.Entities.Pet pet)
        => new List<VisitDto>(pet.Visits.Select(x => x.AsVisitDto()));
    
    public static VisitDto AsVisitDto(this Visit visit)
        => new()
        {
            VisitId = visit.VisitId,
            Description = visit.Description,
            HasTookPlace = visit.HasTookPlace,
            WeightOnVisit = visit.WeightOnVisit,
            DateOfVisit = visit.DateOfVisit,
            VisitType = visit.VisitTypes
        };
}