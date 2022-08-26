namespace Lapka.Pet.Application.Dto;

public class LostPetAdvertisementDetailsDto
{
    public DateTime DateOfDisappearance { get; set; }
    public string Localization { get; set; }
    public string Description { get; set; }
    public string FirstName { get; set; }
    public string PhoneNumber { get; set; }
    public object Pet { get; set; }
}