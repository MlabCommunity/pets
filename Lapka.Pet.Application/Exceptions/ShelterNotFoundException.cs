namespace Lapka.Pet.Application.Exceptions;

internal class ShelterNotFoundException : ProjectException
{
    internal ShelterNotFoundException() : base("Shelter not found.")
    {
    }
}