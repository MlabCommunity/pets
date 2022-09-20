using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class PetDto
{
    public Guid PetId { get; set; }
    public string Name { get; set; }
    public string ProfilePhoto { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; }
    
}