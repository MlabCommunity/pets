namespace Lapka.Pet.Application.Dto;

public class ShelterPetAdvertisementDetailsDto : ShelterPetAdvertisementDto
{
    public bool IsSterilized { get; set; }
    public double Weight { get; set; }
    public List<string> Photos { get; set; }
    public bool IsLiked { get; set; }
    public string Description { get; set; }
    public string Street { get; set; }
}