namespace Lapka.Pet.Core.Exceptions;

internal class InvalidNipException : DomainException
{
    internal InvalidNipException() : base("Invalid Nip")
    {
    }
}