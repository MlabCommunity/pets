namespace Lapka.Pet.Core.Exceptions;

public class InvalidNipException : DomainException
{
    public InvalidNipException() : base("Invalid Nip")
    {
    }
}