using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class ShelterPetAdvertisementDto
{
    public Guid PetId { get; set; }
    public string OrganizationName { get; set; }
    public double Latitude { get; set; } = 50.041187;
    public double Longitude { get; set; } = 21.999121;
    public DateTime DateOfBirth { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public List<Guid> Photos { get; set; }
}