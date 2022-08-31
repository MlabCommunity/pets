namespace Lapka.Pet.Application.Dto;

public class VisitDto
{
    public List<VisitDetailsDto> IncomingVisits { get; set; }
    public List<VisitDetailsDto> LastVisits { get; set; }
}