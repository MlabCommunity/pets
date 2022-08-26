using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class ShelterPetAdvertisementDto
{
    public Guid PetId { get; set; }
    public string OrganizationName { get; set; }
    public string Localization { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Name;
    public Gender Gender;
    public List<Guid> Photos { get; set; }
}