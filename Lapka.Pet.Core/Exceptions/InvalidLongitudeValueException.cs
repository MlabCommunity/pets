namespace Lapka.Pet.Core.Exceptions;

internal class InvalidLongitudeValueException : DomainException
{
    internal InvalidLongitudeValueException() : base("Invalid longitude value")
    {
    }
}