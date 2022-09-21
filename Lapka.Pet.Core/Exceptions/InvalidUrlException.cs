namespace Lapka.Pet.Core.Exceptions;

internal class InvalidUrlException : DomainException
{
    internal InvalidUrlException() : base("Invalid Url")
    {
    }
}