using System.Collections;
using System.Collections.ObjectModel;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Events;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.VisualBasic;

namespace Lapka.Pet.Core.Entities;

public class Shelter : AggregateRoot
{
    private readonly List<Volunteer> _volunteers = new();
    private readonly List<Worker> _workers = new();
    private readonly List<ShelterAdvertisement> _advertisements = new();

    public OrganizationName OrganizationName { get; private set; }
    public ProfilePhotoId ProfilePhotoId { get; private set; }
    public Email Email { get; private set; }
    public Localization Localization { get; private set; }
    public ZipCode ZipCode { get; private set; }
    public Volunteering Volunteering { get; private set; }
    public Krs Krs { get; private set; }
    public Nip Nip { get; private set; }
    public ICollection<ShelterAdvertisement> Advertisements => _advertisements;
    public ICollection<Volunteer> Volunteers => _volunteers;
    public ICollection<Worker> Workers => _workers;

    private Shelter()
    {
    }

    internal Shelter(AggregateId id, Email email, OrganizationName organizationName, Localization localization,
        ZipCode zipCode,
        Krs krs,
        Nip nip)
    {
        Id = id;
        Email = email;
        ProfilePhotoId = Guid.Empty;
        OrganizationName = organizationName;
        Localization = localization;
        ZipCode = zipCode;
        Krs = krs;
        Nip = nip;
        Volunteering = new Volunteering(false, "", "", false, "", false, "");
    }

    public static Shelter Create(AggregateId Id, Email email, Localization localization, ZipCode zipCode,
        OrganizationName organizationName,
        Krs krs, Nip nip)
    {
        var shelter = new Shelter(Id, email, organizationName, localization, zipCode, krs, nip);
        return shelter;
    }


    public void ChangeProfilePhoto(ProfilePhotoId profilePhotoId)
        => ProfilePhotoId = profilePhotoId != Guid.Empty ? profilePhotoId : Guid.Empty;


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

    public void AddWorker(Worker worker)
    {
        var exists = Workers.Any(x => x.WorkerId == worker.WorkerId);

        if (exists)
        {
            throw new WorkerAlreadyExistsException();
        }

        Workers.Add(worker);
    }

    public void UpdateVolunteering(Volunteering volunteering)
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

    public bool WorkerExists(WorkerId workerId)
        => Workers.Any(x => x.WorkerId == workerId);


    public void Update(OrganizationName organizationName, Localization localization, ZipCode zipCode, Krs krs, Nip nip)
    {
        Localization = localization;
        ZipCode = zipCode;
        OrganizationName = organizationName;
        Krs = krs;
        Nip = nip;

        AddEvent(new ShelterUpdatedEvent(Id, organizationName, localization.Street, localization.City, zipCode, krs,
            nip));
    }

    public void Update(Email email, ProfilePhotoId profilePhotoId)
    {
        ChangeProfilePhoto(profilePhotoId);
        Email = email;
    }

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