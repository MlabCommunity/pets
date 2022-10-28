namespace Lapka.Pet.Application.Dto;

public class VisitDto
{
    public bool? HasTookPlace { get; set; }
    public Guid VisitId { get; set; }
    public DateTime DateOfVisit { get; set; }
    public string Description { get; set; }
}