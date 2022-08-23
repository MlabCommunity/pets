using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public abstract class Pet : AggregateRoot
{
    public OwnerId OwnerId { get; protected set; }
    public PetType Type { get; protected set; }
    public ICollection<Photo> Photos = new List<Photo>();
    public PetName Name { get; protected set; }
    public Gender Gender { get; protected set; }
    
    public DateOfBirth DateOfBirth { get; private set; }
    public bool IsSterilized { get; protected set; }
    public Weight Weight { get; protected set; }
    public DateTime CreatedAt { get; protected set; }

    protected Pet()
    {
    }

    protected Pet(OwnerId ownerId, PetType type, PetName name, Gender gender, DateOfBirth dateOfBirth,
        bool isSterilized,
        Weight weight)
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


    public void Update(PetName name, bool isSterilized, Weight weight)
    {
        Name = name;
        IsSterilized = isSterilized;
        Weight = weight;
    }

    public void Sterilize()
    {
        IsSterilized = true;
    }

    public void AddPhoto(Photo photo)
    {
        Photos.Add(photo);
    }

    public void AddPhotos(IEnumerable<PhotoId> photoIds)
    {
        foreach (var photo in Photos)
        {
            AddPhoto(photo);
        }
    }
}