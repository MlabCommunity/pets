namespace Lapka.Pet.Core.Exceptions;

internal class InvalidDateOfBirthException : DomainException
{
    internal InvalidDateOfBirthException() : base("Invalid date of birth")
    {
    }
}