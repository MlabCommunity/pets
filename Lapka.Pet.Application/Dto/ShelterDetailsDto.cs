namespace Lapka.Pet.Application.Dto;

public class ShelterDetailsDto : ShelterDto
{
    public LocalizationDto Localization { get; set; }
    public string Nip { get; set; }
    public string Krs { get; set; }
}