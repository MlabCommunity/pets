namespace Lapka.Pet.Core.ValueObjects;

public record Worker
{
    public WorkerId WorkerId { get; }
    public Email Email { get; }
    public bool Status { get; }

    public FirstName FirstName { get;}
    public LastName LastName { get; }
    public DateTime CreatedAt { get; }

    private Worker()
    {
    }

    public Worker(WorkerId workerId, Email email,FirstName firstName,LastName lastName)
    {
        WorkerId = workerId;
        LastName = lastName;
        FirstName = firstName;
        CreatedAt = DateTime.UtcNow;
        Email = email;
        Status = true;
    }
}