namespace Lapka.Pet.Application.Dto;

public class VisitResponseDto
{
    public PagedResult<VisitDto> IncomingVisits { get; set; }
    public PagedResult<VisitDto> LastVisits { get; set; }
}