using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Core.ValueObjects;

public class ShelterPet
{
    public PetId PetId { get; }

    private ShelterPet()
    {
    }

    public ShelterPet(Guid petId)
    {
        PetId = petId;
    }
}