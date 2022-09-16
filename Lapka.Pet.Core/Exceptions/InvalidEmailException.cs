namespace Lapka.Pet.Core.Exceptions;

internal class InvalidEmailException : DomainException
{
    internal InvalidEmailException() : base("Invalid email")
    {
    }
}