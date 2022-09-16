namespace Lapka.Pet.Core.Exceptions;

internal class InvalidPhoneNumberException : DomainException
{
    internal InvalidPhoneNumberException() : base("Invalid phone number")
    {
    }
}