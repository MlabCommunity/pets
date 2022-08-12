using Lapka.Pet.Infrastructure.Exceptions;

namespace Lapka.Pet.Application.Exceptions;

public class PetNotFoundException : ProjectException
{
    public PetNotFoundException() : base("Pet not found", 404)
    {
    }
}