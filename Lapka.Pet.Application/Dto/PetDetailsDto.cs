namespace Lapka.Pet.Application.Dto;

public class PetDetailsDto : PetDto
{
    public double Weight { get; set; }
    public bool IsSterilized { get; set; }
    public List<string> Photos { get; set; }
}