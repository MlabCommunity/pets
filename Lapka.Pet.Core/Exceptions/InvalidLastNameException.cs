namespace Lapka.Pet.Core.Exceptions;

public class InvalidLastNameException : DomainException
{
    public InvalidLastNameException() : base("Invalid last name, max length is 20 characters")
    {
    }
}