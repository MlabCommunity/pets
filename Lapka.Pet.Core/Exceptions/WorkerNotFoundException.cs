namespace Lapka.Pet.Core.Exceptions;

public class WorkerNotFoundException : DomainException
{
    public WorkerNotFoundException() : base("Worker not found")
    {
    }
}