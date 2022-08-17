namespace Lapka.Pet.Core.Exceptions;

public class InvalidZipCodeException : DomainException
{
    public InvalidZipCodeException() : base("Invalid zip code")
    {
    }
}