namespace Lapka.Pet.Core.Exceptions;

internal class InvalidLastNameException : DomainException
{
    internal InvalidLastNameException() : base("Invalid last name, max length is 20 characters")
    {
    }
}