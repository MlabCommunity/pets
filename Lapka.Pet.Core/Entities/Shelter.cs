using System.Collections;
using System.Collections.ObjectModel;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Events;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.VisualBasic;

namespace Lapka.Pet.Core.Entities;

public class Shelter : AggregateRoot<ShelterId>
{
    private readonly List<Volunteer> _volunteers = new();
    private readonly List<Worker> _workers = new();
    private readonly List<ShelterPet> _shelterPets = new();
    private readonly List<Archive> _archives = new();

    public OrganizationName OrganizationName { get; private set; }
    public ProfilePhoto? ProfilePhoto { get; private set; }
    public Email Email { get; private set; }
    public Localization Localization { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Krs Krs { get; private set; }
    public Nip Nip { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Volunteering Volunteering { get; private set; }
    public ICollection<ShelterPet> ShelterPets => _shelterPets;
    public ICollection<Volunteer> Volunteers => _volunteers;
    public ICollection<Worker> Workers => _workers;
    public ICollection<Archive> Archives => _archives;

    private Shelter()
    {
    }

    internal Shelter(ShelterId id, Email email, FirstName firstName, LastName lastName, PhoneNumber phoneNumber,
        OrganizationName organizationName, double longitude, double latitude,
        Krs krs, Nip nip)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        ProfilePhoto = null;
        OrganizationName = organizationName;
        Localization = new Localization(longitude, latitude);
        Krs = krs;
        Nip = nip;
        Volunteering = new Volunteering(false, "", "", false, "", false, "");
    }

    public static Shelter Create(ShelterId Id, Email email, FirstName firstName, LastName lastName,
        PhoneNumber phoneNumber, double longitude, double latitude,
        OrganizationName organizationName, Krs krs, Nip nip)
    {
        var shelter = new Shelter(Id, email, firstName, lastName, phoneNumber, organizationName, longitude, latitude,
            krs, nip);
        return shelter;
    }

    public void AddPet(ShelterPet shelterPet)
    {
        ShelterPets.Add(shelterPet);
    }

    public void RemovePet(PetId petId)
    {
        var pet = GetShelterPet(petId);

        ShelterPets.Remove(pet);
        AddEvent(new PetDeletedEvent(petId));
    }

    public void PublishPet(PetId petId)
    {
        var advertisement = GetShelterPet(petId);
        advertisement.Publish();
    }

    public void HidePet(PetId petId)
    {
        var advertisement = GetShelterPet(petId);
        advertisement.Hide();
    }

    public void UpdatePet(PetId petId, string description, PetName petName, bool isSterilized, Weight weight)
    {
        var pet = GetShelterPet(petId);

        pet.Update(description, petName, isSterilized, weight);
    }

    private ShelterPet GetShelterPet(PetId petId)
    {
        var pet = ShelterPets.SingleOrDefault(x => x.Id == petId);

        if (pet is null)
        {
            throw new PetNotFoundException();
        }

        return pet;
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

    public void Update(OrganizationName organizationName, double longitude, double latitude, PhoneNumber phoneNumber,
        Krs krs,
        Nip nip)
    {
        Localization = new Localization(longitude, latitude);
        OrganizationName = organizationName;
        Krs = krs;
        Nip = nip;
        PhoneNumber = phoneNumber;

        AddEvent(new ShelterUpdatedEvent(Id, organizationName, longitude, latitude, krs, nip));
    }

    public void Update(Email email, FirstName firstName, LastName lastName, ProfilePhoto profilePhoto)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        ProfilePhoto = profilePhoto;
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

    public void ArchivePet(Guid petId)
    {
        RemovePet(petId);
        _archives.Add(new Archive(petId));
    }
}