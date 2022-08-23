namespace Lapka.Pet.Application.Dto;

public class ShelterAdvertisementDto
{
    public Guid Id { get; set; }
    public bool IsReserved { get; set; }
    public string Description { get; set; }
    public string OrganizationName { get; set; }
    public string Localization { get; set; }
    public Guid PetId { get; set; }
}