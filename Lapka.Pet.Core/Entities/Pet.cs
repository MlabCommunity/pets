using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Domain;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.VisualBasic;

namespace Lapka.Pet.Core.Entities;

public abstract class Pet : AggregateRoot
{
    public OwnerId OwnerId { get; protected set; }
    public PetType Type { get; protected set; }
    public string Name { get; protected set; }
    public Gender Gender { get; protected set; }
    //   public ICollection<PhotoId> Photos { get; protected set; }
    public DateTime _dateOfBirth;
    public bool IsSterilized { get; protected set; }
    public double Weight { get; protected set; }
    public DateTime CreatedAt { get; protected set; }

    protected Pet()
    {
    }

    protected Pet(OwnerId ownerId, PetType type, string name, Gender gender, bool isSterilized, double weight)
    {
        Id = Guid.NewGuid();
        OwnerId = ownerId;
        Type = type;
        Name = name;
        Gender = gender;
        IsSterilized = isSterilized;
        Weight = weight;
        CreatedAt = DateTime.UtcNow;
    }

    protected void ChangeDateOfBirth(DateTime dateOfBirth)
    {
        if (dateOfBirth > DateTime.Now || dateOfBirth < DateTime.Now.AddYears(-40))
        {
            throw new InvalidDateOfBirthException();
        }

        _dateOfBirth = dateOfBirth;
    }
}