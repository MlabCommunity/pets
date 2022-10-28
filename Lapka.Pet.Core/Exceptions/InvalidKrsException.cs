namespace Lapka.Pet.Core.Exceptions;

internal class InvalidKrsException : DomainException
{
    internal InvalidKrsException() : base("Invalid KRS")
    {
    }
}