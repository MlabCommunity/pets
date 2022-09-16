namespace Lapka.Pet.Core.Exceptions;

internal class InvalidWeightException : DomainException
{
    internal InvalidWeightException() : base("Invalid weight, weight must be greater than 0 and less than 200")
    {
    }
}