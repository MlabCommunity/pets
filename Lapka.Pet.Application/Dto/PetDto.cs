using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class PetDto
{
    public Guid Id { get; set; }
    public PetType Type { get; set; }
    public List<Guid> Photos { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsSterilized { get; set; }
    public double Weight { get; set; }
    public DateTime CreatedAt { get; set; }
}