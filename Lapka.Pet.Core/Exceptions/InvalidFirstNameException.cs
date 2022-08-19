namespace Lapka.Pet.Core.Exceptions;

public class InvalidFirstNameException : DomainException
{
    public InvalidFirstNameException() : base("Invalid first name, max length is 20 characters")
    {
    }
    
    
}