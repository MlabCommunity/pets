namespace Lapka.Pet.Core.Exceptions;

internal class EmptyNameException : DomainException
{
    internal EmptyNameException() : base("name cannot be empty")
    {
    }
}