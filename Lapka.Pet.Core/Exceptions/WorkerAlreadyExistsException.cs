namespace Lapka.Pet.Core.Exceptions;

public class WorkerAlreadyExistsException : DomainException
{
    public WorkerAlreadyExistsException() : base("Worker already exists")
    {
    }

}