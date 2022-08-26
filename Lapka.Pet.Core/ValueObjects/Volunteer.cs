namespace Lapka.Pet.Core.ValueObjects;

public record Volunteer
{
    public Email Email { get; }
    public UserId UserId { get; }

    private Volunteer()
    {
    }

    public Volunteer(Email email, UserId userId)
    {
        Email = email;
        UserId = userId;
    }
}