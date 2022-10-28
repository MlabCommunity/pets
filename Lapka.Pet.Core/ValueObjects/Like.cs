namespace Lapka.Pet.Core.ValueObjects;

public record Like
{
    public UserId UserId { get; }
    public Entities.Pet Pet { get; }
    public PetId PetId { get; }

    private Like()
    {
    }

    public Like(UserId userId, Entities.Pet pet)
    {
        UserId = userId;
        Pet = pet;
        PetId = pet.Id;
    }
}