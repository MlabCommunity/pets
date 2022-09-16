namespace Lapka.Pet.Application.Dto;

public class ShelterPetAdvertisementDetailsDto : ShelterPetAdvertisementDto
{
    public bool IsSterilized { get; set; }
    public double Weight { get; set; }
    public List<Guid> Photos { get; set; }
    public string Description { get; set; }
}