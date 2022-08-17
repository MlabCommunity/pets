namespace Lapka.Pet.Core.Exceptions;

public class InvalidEmailException : DomainException
{
    public InvalidEmailException() : base("Invalid email")
    {
    }
}