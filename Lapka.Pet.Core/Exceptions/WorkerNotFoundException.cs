namespace Lapka.Pet.Core.Exceptions;

internal class WorkerNotFoundException : DomainException
{
    internal WorkerNotFoundException() : base("Worker not found")
    {
    }
}