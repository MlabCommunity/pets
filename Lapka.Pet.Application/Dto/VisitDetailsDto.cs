using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Dto;

public class VisitDetailsDto
{
    public Guid VisitId { get; set; }
    public bool HasTookPlace { get; set; }
    public DateTime DateOfVisit { get; set; }
    public string Description { get; set; }
    public ICollection<VisitType> VisitType { get; set; }
    public double? WeightOnVisit { get; set; }
}