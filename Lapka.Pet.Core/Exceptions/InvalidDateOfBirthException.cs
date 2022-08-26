namespace Lapka.Pet.Core.Exceptions;

public class InvalidDateOfBirthException : DomainException
{
    public InvalidDateOfBirthException() : base("Invalid date of birth")
    {
    }
}