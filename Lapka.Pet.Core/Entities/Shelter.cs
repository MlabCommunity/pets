using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class Shelter : AggregateRoot
{
    public OrganizationName OrganizationName { get; private set; }
    public ICollection<ShelterAdvertisement> Advertisements = new List<ShelterAdvertisement>();
    public string Street { get; private set; }
    public string City { get; private set; }
    public ZipCode ZipCode { get; private set; }
    public ICollection<Worker> Workers = new List<Worker>();
    public Volunteering Volunteering { get; private set; }
    public ICollection<Volunteer> Volunteers = new List<Volunteer>();
    public Krs Krs { get; private set; }
    public Nip Nip { get; private set; }

    private Shelter()
    {
    }

    private Shelter(AggregateId id, OrganizationName organizationName, string street, string city, ZipCode zipCode,
        Krs krs,
        Nip nip)
    {
        Id = id;
        OrganizationName = organizationName;
        Street = street;
        City = city;
        ZipCode = zipCode;
        Krs = krs;
        Nip = nip;
        Volunteering = new Volunteering();
    }

    public static Shelter Create(AggregateId Id, string street, string city, ZipCode zipCode,
        OrganizationName organizationName,
        Krs krs, Nip nip)
    {
        var shelter = new Shelter(Id, organizationName, street, city, zipCode, krs, nip);
        return shelter;
    }

    public void AddAdvertisement(ShelterAdvertisement shelterAdvertisement)
    {
        var exists = Advertisements.Any(a => a.PetId == shelterAdvertisement.PetId);

        if (exists)
        {
            throw new AdvertisementAlreadyExistsException();
        }

        Advertisements.Add(shelterAdvertisement);
    }

    public void RemoveAdvertisement(PetId petId)
    {
        var advertisement = Advertisements.SingleOrDefault(x => x.PetId == petId);

        if (advertisement is null)
        {
            throw new AdvertisementNotFoundException();
        }

        Advertisements.Add(advertisement);
    }

    public void ReserveAdvertisement(PetId petId)
    {
        var advertisement = GetAdvertisement(petId);
        advertisement.Reserve();
    }

    public void PublishAdvertisement(PetId petId)
    {
        var advertisement = GetAdvertisement(petId);
        advertisement.Publish();
    }

    public void HideAdvertisement(PetId petId)
    {
        var advertisement = GetAdvertisement(petId);
        advertisement.Hide();
    }

    private ShelterAdvertisement GetAdvertisement(PetId petId)
    {
        var advertisement = Advertisements.SingleOrDefault(x => x.PetId == petId);

        if (advertisement is null)
        {
            throw new AdvertisementNotFoundException();
        }

        return advertisement;
    }

    public void UpdateAdvertisement(PetId petId, string description)
    {
        var advertisement = GetAdvertisement(petId);
        advertisement.Update(description);
    }

    public void UnReserveAdvertisement(PetId petId)
    {
        var advertisement = GetAdvertisement(petId);
        advertisement.UnReserve();
    }

    public void AddWorker(WorkerId worker)
    {
        var exists = Workers.Any(x => x.WorkerId == worker);

        if (exists)
        {
            throw new WorkerAlreadyExistsException();
        }

        Workers.Add(new Worker(worker));
    }

    public void ConfigureVolunteering(Volunteering volunteering)
    {
        Volunteering = volunteering;
    }

    private Worker GetWorker(WorkerId workerId)
    {
        var worker = Workers.SingleOrDefault(x => x.WorkerId == workerId);

        if (worker is null)
        {
            throw new WorkerNotFoundException();
        }

        return worker;
    }

    public void Update(OrganizationName organizationName, string street, string city, ZipCode zipCode, Krs krs, Nip nip)
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
        => $"{City}, {Street}";

    public void RemoveWorker(WorkerId workerId)
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

    public void RemoveVolunteer(UserId volunteerId)
    {
        var volunteer = GetVolunteer(volunteerId);

        Volunteers.Remove(volunteer);
    }

    private Volunteer GetVolunteer(UserId volunteerId)
    {
        var volunteer = Volunteers.SingleOrDefault(x => x.UserId == volunteerId);

        if (volunteer is null)
        {
            throw new VolunteerNotFoundException();
        }

        return volunteer;
    }
}