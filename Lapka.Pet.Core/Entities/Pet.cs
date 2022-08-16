using System.Data;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.VisualBasic;

namespace Lapka.Pet.Core.Entities;

public abstract class Pet : AggregateRoot
{
    public OwnerId OwnerId { get; protected set; }
    public PetType Type { get; protected set; }
    public PetName Name { get; protected set; }
    public Gender Gender { get; protected set; }

    //   public ICollection<PhotoId> Photos { get; protected set; }
    public DateOfBirth DateOfBirth { get; private set; }
    public bool IsSterilized { get; protected set; }
    public Weight Weight { get; protected set; }
    public DateTime CreatedAt { get; protected set; }

    protected Pet()
    {
    }

    protected Pet(Guid ownerId, PetType type, string name, Gender gender, DateTime dateOfBirth, bool isSterilized,
        double weight)
    {
        Id = Guid.NewGuid();
        OwnerId = ownerId;
        Type = type;
        Weight = weight;
        DateOfBirth = dateOfBirth;
        Name = name;
        Gender = gender;
        IsSterilized = isSterilized;
        CreatedAt = DateTime.UtcNow;
    }


    public void Update(string name, bool isSterilized, double weight)
    {
        Name = name;
        IsSterilized = isSterilized;
        Weight = weight;
    }

    protected void Sterilize()
    {
        IsSterilized = true;
    }
}