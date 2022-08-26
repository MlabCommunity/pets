namespace Lapka.Pet.Application.Dto;

public class ShelterAdvertisementDetailsDto
{
    public Guid AdvertisementId { get; set; }
    public bool IsReserved { get; set; }
    public string Description { get; set; }
    public string OrganizationName { get; set; }
    public string Localization { get; set; }
    public object Pet { get; set; }
}