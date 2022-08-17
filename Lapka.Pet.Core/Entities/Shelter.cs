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
    public ZipCode ZipCode { get; private set; }
    public ICollection<WorkerId> Workers { get; private set; }
    public Volunteering Volunteering { get; private set; }
    public ICollection<Volunteer> Volunteers = new List<Volunteer>();
    public Krs Krs { get; private set; }
    public Nip Nip { get; private set; }

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
        Volunteering = new Volunteering();
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
        var exists = Workers.Any(x => x.Value == workerId);

        if (exists)
        {
            throw new WorkerAlreadyExistsException();
        }

        Workers.Add(workerId);
    }

    public void ConfigureVolunteering(Volunteering volunteering)
    {
        Volunteering = volunteering;
    }

    private WorkerId GetWorker(Guid workerId)
    {
        var worker = Workers.SingleOrDefault(x => x.Value == workerId);

        if (worker is null)
        {
            throw new WorkerNotFoundException();
        }

        return worker;
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
        var worker = GetWorker(workerId);

        Workers.Remove(worker);
    }
    
    public void AddVolunteer(Volunteer volunteer)
    {
        var exists = Volunteers.Any(x => x.UserId == volunteer.UserId);

        if (exists)
        {
            throw new VolunteerAlreadyExistsException();
        }
        Volunteers.Add(volunteer);
    }
    
    public void RemoveVolunteer(Guid volunteerId)
    {
        var volunteer = GetVolunteer(volunteerId);
        
        Volunteers.Remove(volunteer);
    }
    
    private Volunteer GetVolunteer(Guid volunteerId)
    {
        var volunteer = Volunteers.SingleOrDefault(x => x.UserId == volunteerId);

        if (volunteer is null)
        {
            throw new VolunteerNotFoundException();
        }

        return volunteer;
    }
    
    
}