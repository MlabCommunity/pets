using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Dto;

public class LostPetAdvertisementDto
{
    public DateTime DateOfDisappearance { get; set; }
    public string StreetOfDisappearance { get; set; }
    public string CityOfDisappearance { get; set; }
    public string Description { get; set; }
    public List<Photo> Photos { get; set; }
    public Guid PetId { get; set; }
}