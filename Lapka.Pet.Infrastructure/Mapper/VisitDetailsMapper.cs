using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Mapper;

public static class VisitDetailsMapper
{
    public static VisitDetailsDto AsVisitDetailsDto(this Visit visit)
        => new()
        {
            VisitId = visit.VisitId,
            Description = visit.Description,
            HasTookPlace = visit.HasTookPlace == null ? false : visit.HasTookPlace.Value,
            WeightOnVisit = visit.WeightOnVisit,
            DateOfVisit = visit.DateOfVisit,
            VisitType = visit.VisitTypes
        };
}