namespace Lapka.Pet.Core.Exceptions;

public class EmptyNameException : DomainException
{
    public EmptyNameException() : base("name cannot be empty")
    {
    }
}