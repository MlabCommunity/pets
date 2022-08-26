namespace Lapka.Pet.Core.ValueObjects;

public record Worker
{
    public WorkerId WorkerId { get; }

    private Worker()
    {
    }

    public Worker(WorkerId workerId)
    {
        WorkerId = workerId;
    }
}