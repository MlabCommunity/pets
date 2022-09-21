namespace Lapka.Pet.Core.ValueObjects;

public record Archive
{
    public PetId PetId { get; }
    public DateTime CreatedAt { get; } 

    public Archive(PetId petId)
    {
        PetId = petId;
        CreatedAt =DateTime.UtcNow;
    }
}