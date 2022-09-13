using System.Runtime.InteropServices.ComTypes;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Core.ValueObjects;

public record Worker
{
    public WorkerId WorkerId { get; private set; }
    public Email Email { get; init; }
    public bool Status { get; init; }
    public FirstName FirstName { get; init; }
    public LastName LastName { get; init; }
    public DateTime CreatedAt { get; }


    private Worker()
    {
    }

    public Worker(WorkerId workerId, Email email, FirstName firstName, LastName lastName)
    {
        WorkerId = workerId;
        LastName = lastName;
        FirstName = firstName;
        CreatedAt = DateTime.UtcNow;
        Email = email;
        Status = true;
    }
}