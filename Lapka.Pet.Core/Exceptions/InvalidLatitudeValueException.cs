namespace Lapka.Pet.Core.Exceptions;

internal class InvalidLatitudeValueException : DomainException
{
    internal InvalidLatitudeValueException() : base("Invalid latitude value")
    {
    }
}