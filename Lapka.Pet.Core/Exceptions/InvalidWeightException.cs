namespace Lapka.Pet.Core.Exceptions;

public class InvalidWeightException : DomainException
{
    public InvalidWeightException() : base("Invalid weight, weight must be greater than 0 and less than 200")
    {
    }
}