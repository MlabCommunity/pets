using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Domain;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class Pet : AggregateRoot
{
    public PetId PetId { get; protected set; }
    public OwnerId OwnerId { get; protected set; }
    public PetType Type { get; protected set; }
    public string Name { get; protected set; }
    public Gender Gender { get; protected set; }
    public ICollection<PhotoId> Photos { get; protected set; }
    public DateTime DateOfBirth { get; protected set; }
    public bool IsSterilized { get; protected set; }
    public double Weight { get; protected set; }

    protected Pet()
    {
    }
}