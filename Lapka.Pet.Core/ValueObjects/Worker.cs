namespace Lapka.Pet.Core.ValueObjects;

public record Worker
{
    public WorkerId WorkerId { get; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    private Worker()
    {
    }

    public Worker(WorkerId workerId)
    {
        WorkerId = workerId;
    }
}