using Lapka.Pet.Core.DomainThings;

namespace Lapka.Pet.Core.ValueObjects;

public record Volunteer 
{
    public Email Email { get;} 
    public EntityId UserId { get;}

    private Volunteer()
    {
    }

    public Volunteer(string email, Guid userId)
    {
        Email = email;
        UserId = userId;
    }
}