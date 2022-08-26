namespace Lapka.Pet.Core.Exceptions;

public class InvalidPetNameException : DomainException
{
    public InvalidPetNameException() : base("Invalid pet name, max length is 20 characters")
    {
    }
}