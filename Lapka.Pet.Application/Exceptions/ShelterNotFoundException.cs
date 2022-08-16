namespace Lapka.Pet.Application.Exceptions;

public class ShelterNotFoundException : ProjectException
{
    public ShelterNotFoundException() : base("Shelter not found.")
    {
    }
}