using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Dto;

public class LostPetAdvertisementDto
{
    public DateTime DateOfDisappearance { get; set; }
    public string Localization { get; set; }
    public string Description { get; set; }
    public PetDto Pet { get; set; }
}