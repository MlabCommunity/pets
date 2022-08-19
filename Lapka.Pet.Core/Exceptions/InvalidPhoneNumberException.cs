namespace Lapka.Pet.Core.Exceptions;

public class InvalidPhoneNumberException : DomainException
{
    public InvalidPhoneNumberException() : base("Invalid phone number")
    {
    }
    
}