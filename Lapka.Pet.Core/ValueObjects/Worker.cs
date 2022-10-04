using System.Runtime.InteropServices.ComTypes;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Core.ValueObjects;

public record Worker
{
    public Shelter Shelter { get; }
    public ShelterId ShelterId { get; }
    public WorkerId WorkerId { get; }
    public Email Email { get; init; }
    public FirstName FirstName { get; init; }
    public LastName LastName { get; init; }
    public DateTime CreatedAt { get; }

    private Worker()
    {
    }

    public Worker(WorkerId workerId, Email email, FirstName firstName, LastName lastName, Shelter shelter)
    {
        WorkerId = workerId;
        LastName = lastName;
        FirstName = firstName;
        CreatedAt = DateTime.UtcNow;
        Email = email;
        Shelter = shelter;
        ShelterId = shelter.Id;
    }
}