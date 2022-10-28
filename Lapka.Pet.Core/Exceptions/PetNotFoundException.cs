namespace Lapka.Pet.Core.Exceptions;

internal class PetNotFoundException : DomainException
{
    internal PetNotFoundException() : base("Pet not found")
    {
    }
}