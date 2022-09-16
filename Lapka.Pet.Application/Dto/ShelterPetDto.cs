using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class ShelterPetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public PetType Type { get; set; }
    public Gender Gender { get; set; }
    public double Weight { get; set; }
    public bool IsSterilized { get; set; }
    public DateTime CreatedAt { get; set; }
}