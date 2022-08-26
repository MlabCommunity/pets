using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class LostPetAdvertisementDto
{
    public Guid PetId { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<Guid> Photos { get; set; }
}