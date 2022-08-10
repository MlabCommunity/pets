using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Domain;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public abstract class Pet : AggregateRoot //AggregateRoot powinien być w Pet czy osobno w kot/pies?
{

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

    protected Pet(OwnerId ownerId, PetType type, string name, Gender gender, ICollection<PhotoId> photos,
        DateTime dateOfBirth, bool isSterilized, double weight)
    {
        Id = Guid.NewGuid();
        OwnerId = ownerId;
        Type = type;
        Name = name;
        Gender = gender;
        Photos = photos;
        DateOfBirth = dateOfBirth;
        IsSterilized = isSterilized;
        Weight = weight;
    }
    
    
}