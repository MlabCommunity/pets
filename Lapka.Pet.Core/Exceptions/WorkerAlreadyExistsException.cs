namespace Lapka.Pet.Core.Exceptions;

internal class WorkerAlreadyExistsException : DomainException
{
    internal WorkerAlreadyExistsException() : base("Worker already exists")
    {
    }
}