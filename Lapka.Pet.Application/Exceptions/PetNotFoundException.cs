namespace Lapka.Pet.Application.Exceptions;

internal class PetNotFoundException : ProjectException
{
    internal PetNotFoundException() : base("Pet not found", 404)
    {
    }
}