using Lapka.Pet.Core.Consts;
using VisitType = Lapka.Pet.Core.ValueObjects.VisitType;

namespace Lapka.Pet.Application.Dto;

public class VisitDto
{
    public Guid VisitId { get; set; }
    public bool HasTookPlace { get; set; }
    public DateTime DateOfVisit { get;set; }
    public string Description { get;set; }
    public ICollection<VisitType> VisitType { get;set; }
    public double WeightOnVisit { get;set; }
}