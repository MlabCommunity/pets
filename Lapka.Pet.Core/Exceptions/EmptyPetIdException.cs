namespace Lapka.Pet.Core.Exceptions;

public class EmptyPetIdException : DomainException
{
    public EmptyPetIdException() : base("Pet Id cannot be empty")
    {
    }
}