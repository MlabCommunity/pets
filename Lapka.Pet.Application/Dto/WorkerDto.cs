namespace Lapka.Pet.Application.Dto;

public class WorkerDto
{
    public Guid WorkerId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? CratedAt { get; set; }
    public bool? Status { get; set; }
}