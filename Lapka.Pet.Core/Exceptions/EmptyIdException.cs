namespace Lapka.Pet.Core.Exceptions;

public class EmptyIdException : DomainException
{
    public EmptyIdException() : base("Id cannot be empty")
    {
        
    }
}