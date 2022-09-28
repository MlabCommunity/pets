using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class ShelterPetAdvertisementDto
{
    public string OrganizationName { get; set; }
    public Guid PetId { get; set; }
    public string Name { get; set; }
    public double Age { get; set; }
    public Gender Gender { get; set; }
    public string ProfilePhoto { get; set; }
    public double  Distance { get; set; }
    public LocalizationDto Localization { get;set; }
}