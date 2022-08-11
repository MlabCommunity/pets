using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Core.ValueObjects;

public class ShelterPet
{
    public Shelter Shelter { get; }
    public PetId PetId { get; }

    private ShelterPet()
    {
    }
    
    public ShelterPet(Shelter shelter, PetId petId)
    {
        Shelter = shelter;
        PetId = petId;
    }
}
