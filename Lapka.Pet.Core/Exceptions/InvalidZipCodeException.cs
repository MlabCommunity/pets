namespace Lapka.Pet.Core.Exceptions;

internal class InvalidZipCodeException : DomainException
{
    internal InvalidZipCodeException() : base("Invalid zip code")
    {
    }
}