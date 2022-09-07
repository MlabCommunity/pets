using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public abstract class Pet : AggregateRoot
{
    public OwnerId OwnerId { get; private set; }
    public PetType Type { get; private set; }
    public ICollection<Photo> Photos = new List<Photo>();
    public PetName Name { get; private set; }
    public Gender Gender { get; private set; }
    public ICollection<Visit> Visits = new List<Visit>();
    public DateOfBirth DateOfBirth { get; private set; }
    public bool IsSterilized { get; private set; }
    public Weight Weight { get; private set; }
    public DateTime CreatedAt { get; private set; }

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

    public void AddPhoto(Photo photo)
    {
        Photos.Add(photo);
    }

    public void AddPhotos(ICollection<Guid> photoIds)
    {
        foreach (var photo in photoIds)
        {
            AddPhoto(new Photo(photo));
        }
    }

    public void AddVisit(Visit visit, Guid ownerId)
    {
        if (ownerId != OwnerId)
        {
            throw new DomainForbidden();
        }

        if (visit.HasTookPlace == true && visit.WeightOnVisit is not null)
        {
            var lastVisit = Visits.Where(x => x.DateOfVisit < DateTime.UtcNow).OrderByDescending(c => c.DateOfVisit)
                .FirstOrDefault();

            if (lastVisit is not null && lastVisit.DateOfVisit <= visit.DateOfVisit)
            {
                Weight = visit.WeightOnVisit.Value;
            }
            else if (lastVisit is null)
            {
                Weight = visit.WeightOnVisit.Value;
            }
        }
        
        Visits.Add(visit);
    }

    public void RemoveVisit(EntityId visitId, OwnerId ownerId)
    {
        if (ownerId != OwnerId)
        {
            throw new DomainForbidden();
        }

        var visit = Visits.FirstOrDefault(x => x.VisitId == visitId);
        Visits.Remove(visit);
    }

    public void UpdateVisit(Guid visitId, Guid ownerId, bool hasTookPlace, DateTime dateOfVisit, string description,
        HashSet<CareType> visitTypes, double weightOnVisit)
    {
        if (ownerId != OwnerId)
        {
            throw new DomainForbidden();
        }

        var visit = Visits.FirstOrDefault(x => x.VisitId == visitId);

        if (visit is null)
        {
            throw new VisitNotFoundException();
        }

        visit.Update(hasTookPlace, dateOfVisit, description, visitTypes, weightOnVisit);

        if (visit.HasTookPlace == true)
        {
            var lastVisit = Visits.Where(x => x.DateOfVisit < DateTime.UtcNow).OrderByDescending(c => c.DateOfVisit)
                .FirstOrDefault();

            if (lastVisit.DateOfVisit <= visit.DateOfVisit || lastVisit is null)
            {
                Weight = visit.WeightOnVisit.Value;
            }
        }
    }
}