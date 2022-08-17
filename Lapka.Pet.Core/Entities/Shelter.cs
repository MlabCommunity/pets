using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class Shelter : AggregateRoot
{
    public UserId UserId { get; private set; }
    public OrganizationName OrganizationName { get; private set; }
    public ICollection<PetId> ShelterPets = new List<PetId>();
    public string Street { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }
    public ICollection<WorkerId> Workers { get; private set; }

    // private Volunteering _volunteering;
    // private ICollection<Volunteer> _volunteers;
    public string Krs { get; private set; }
    public string Nip { get; private set; }

    private Shelter()
    {
    }

    private Shelter(Guid userId, string organizationName, string street, string city, string zipCode, string krs,
        string nip)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        OrganizationName = organizationName;
        Street = street;
        City = city;
        ZipCode = zipCode;
        Krs = krs;
        Nip = nip;
    }

    public static Shelter Create(Guid userId, string street, string city, string zipCode, string organizationName,
        string krs, string nip)
    {
        var shelter = new Shelter(userId, organizationName, street, city, zipCode, krs, nip);
        // AddEvent(new ShelterCreatedEvent(street, city, zipCode, organizationName));
        return shelter;
    }

    public void AddPet(PetId petId)
    {
        ShelterPets.Add(petId);
    }

    public void AddWorker(Guid workerId)
    {
        Workers.Add(workerId);
    }


    public void Update(string organizationName, string street, string city, string zipCode, string krs, string nip)
    {
        Street = street;
        City = city;
        ZipCode = zipCode;
        OrganizationName = organizationName;
        Krs = krs;
        Nip = nip;

        // AddEvent(new ShelterUpdatedEvent(Id, organizationName, street, city, zipCode, krs, nip));
    }

    public string GetLocalization()
        => $"{Street}, {City}";

    public void RemoveWorker(Guid workerId)
    {
        var worker = Workers.SingleOrDefault(x => x.Value == workerId);

        if (worker is null)
        {
            throw new WorkerNotFoundException();
        }

        Workers.Remove(worker);
    }
}