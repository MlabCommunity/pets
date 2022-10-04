using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public record Photo
{
    public PhotoLink Link { get; }
    public Entities.Pet Pet { get; }
    public PetId PetId { get; }

    private Photo()
    {
    }

    public Photo(PhotoLink link, Entities.Pet pet)
    {
        PetId = pet.Id;
        Link = link;
        Pet = pet;
    }
}