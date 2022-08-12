namespace Lapka.Pet.Core.Exceptions;

public class EmptyPetNameException : DomainException
{
    public EmptyPetNameException() : base("name cannot be empty")
    {
    }
}