namespace Lapka.Pet.Application.Dto;

public class ShelterOtherPetAdvertisementDetailsDto : ShelterPetAdvertisementDetailsDto
{
    public bool IsSterilized { get; set; }
    public decimal Weight { get; set; }
    public string Description { get; set; }
}