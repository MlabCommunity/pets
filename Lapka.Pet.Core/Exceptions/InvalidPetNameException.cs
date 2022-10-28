namespace Lapka.Pet.Core.Exceptions;

internal class InvalidPetNameException : DomainException
{
    internal InvalidPetNameException() : base("Invalid pet name, max length is 20 characters")
    {
    }
}