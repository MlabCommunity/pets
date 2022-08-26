namespace Lapka.Pet.Core.Exceptions;

public class InvalidKrsException : DomainException
{
    public InvalidKrsException() : base("Invalid KRS")
    {
    }
}