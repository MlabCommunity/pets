namespace Lapka.Pet.Core.Exceptions;

internal class InvalidFirstNameException : DomainException
{
    internal InvalidFirstNameException() : base("Invalid first name, max length is 20 characters")
    {
    }
}