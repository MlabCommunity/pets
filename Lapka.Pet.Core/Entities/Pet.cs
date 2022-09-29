using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public abstract class Pet : AggregateRoot<PetId>
{
    private readonly List<Photo> _photos = new();
    private readonly List<Visit> _visits = new();
    private readonly List<Like> _likes = new();

    public OwnerId OwnerId { get; private set; }
    public ProfilePhoto? ProfilePhoto { get; private set; }
    public PetType Type { get; private set; }
    public PetName Name { get; private set; }
    public Gender Gender { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }
    public bool IsSterilized { get; private set; }
    public Weight Weight { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ICollection<Photo> Photos => _photos;
    public ICollection<Visit> Visits => _visits;
    public ICollection<Like> Likes => _likes;

    protected Pet()
    {
    }

    protected Pet(OwnerId ownerId, ProfilePhoto profilePhoto, PetType type, PetName name, Gender gender,
        DateOfBirth dateOfBirth,
        bool isSterilized,
        Weight weight, ICollection<string> photos)
    {
        Id = Guid.NewGuid();
        OwnerId = ownerId;
        ProfilePhoto = profilePhoto;
        Type = type;
        Weight = weight;
        DateOfBirth = dateOfBirth;
        Name = name;
        Gender = gender;
        IsSterilized = isSterilized;
        CreatedAt = DateTime.UtcNow;
        AddPhotos(photos);
    }

    public void Update(PetName name, bool isSterilized, Weight weight)
    {
        Name = name;
        IsSterilized = isSterilized;
        Weight = weight;
    }

    private void AddPhoto(Photo photo)
    {
        Photos.Add(photo);
    }

    protected void AddPhotos(ICollection<string> photos)
    {
        foreach (var photo in photos)
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

    public void UpdateVisit(OwnerId ownerId, Guid visitId, bool hasTookPlace, DateTime dateOfVisit, string description,
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
            var lastVisit = Visits.Where(x => x.DateOfVisit < DateTime.UtcNow)
                .OrderByDescending(c => c.DateOfVisit)
                .FirstOrDefault();

            if (lastVisit.DateOfVisit <= visit.DateOfVisit || lastVisit is null)
            {
                Weight = visit.WeightOnVisit.Value;
            }
        }
    }

    public void Like(UserId userId)
    {
        var exists = Likes.Any(x => x.UserId == userId);

        if (!exists)
        {
            Likes.Add(new Like(userId));
        }
    }

    public void UnLike(UserId userId)
    {
        var like = Likes.FirstOrDefault(x => x.UserId == userId);

        if (like is not null)
        {
            Likes.Remove(like);
        }
    }

    public bool IsLiked(UserId userId)
    {
        if (userId.IsEmpty())
        {
            return false;
        }
        return Likes.Any(x => x.UserId == userId);
    }
        
}