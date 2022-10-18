using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Core.ValueObjects;

public record Archive
{
    public PetId PetId { get; }
    public Shelter Shelter { get; }
    public ShelterId ShelterId { get; }
    public DateTime CreatedAt { get; }

    private Archive()
    {
    }

    public Archive(PetId petId, Shelter shelter)
    {
        ShelterId = shelter.Id;
        Shelter = shelter;
        PetId = petId;
        CreatedAt = DateTime.UtcNow;
    }
}