using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

internal class InvalidLongitudeValueException : DomainException
{
    internal InvalidLongitudeValueException() : base("Invalid longitude value")
    {
    }
}