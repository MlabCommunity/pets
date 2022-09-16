namespace Lapka.Pet.Application.Dto;

public class LostPetAdvertisementDetailsDto : LostPetAdvertisementDto
{
    public DateTime DateOfDisappearance { get; set; }
    public LocalizationDto Localization { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public List<Guid> Photos { get; set; }
    public double Distance { get; set; }
    public string FirstName { get; set; }
    public string PhoneNumber { get; set; }

}