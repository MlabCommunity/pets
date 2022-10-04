using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Core.ValueObjects;

public record Volunteer
{
    public UserId UserId { get; }
    public Shelter Shelter { get; }
    public ShelterId ShelterId { get; }
    
    private Volunteer(){}

    public Volunteer(UserId userId, Shelter shelter)
    {
        ShelterId = shelter.Id;
        UserId = userId;
        Shelter = shelter;
    }
}