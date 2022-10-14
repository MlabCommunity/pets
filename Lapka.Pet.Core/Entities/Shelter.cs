using System.Collections;
using System.Collections.ObjectModel;
using Lapka.Pet.Core.Events;
using Lapka.Pet.Core.Events.Handlers;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.Kernel.Types;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.VisualBasic;

namespace Lapka.Pet.Core.Entities;

public class Shelter : AggregateRoot<ShelterId>
{
    private readonly List<Volunteer> _volunteers = new List<Volunteer>();
    private readonly List<Worker> _workers = new List<Worker>();
    private readonly List<ShelterPet> _shelterPets = new List<ShelterPet>();
    private readonly List<Archive> _archives = new List<Archive>();

    public OrganizationName OrganizationName { get; private set; }
    public ProfilePhoto? ProfilePhoto { get; private set; }
    public Email Email { get; private set; }
    public Localization Localization { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Krs Krs { get; private set; }
    public Nip Nip { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public ZipCode ZipCode { get; private set; }
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
        OrganizationName organizationName, double longitude, double latitude,string street,string city,ZipCode zipCode,
        Krs krs, Nip nip)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        ProfilePhoto = null;
        OrganizationName = organizationName;
        Localization = new Localization(longitude, latitude,id);
        City = city;
        Street = street;
        ZipCode = zipCode;
        Krs = krs;
        Nip = nip;
        Volunteering = new Volunteering(false, string.Empty, string.Empty, false, string.Empty, false, "", this);
    }

    public static Shelter Create(ShelterId Id, Email email, FirstName firstName, LastName lastName,
        PhoneNumber phoneNumber, double longitude, double latitude,string street,string city,ZipCode zipCode,
        OrganizationName organizationName, Krs krs, Nip nip)
    {
        var shelter = new Shelter(Id, email, firstName, lastName, phoneNumber, organizationName, longitude, latitude, street,city,zipCode,
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

    public void AddWorker(WorkerId workerId, Email email, FirstName firstName, LastName lastName)
    {
        var exists = Workers.Any(x => x.WorkerId == workerId);

        if (exists)
        {
            throw new WorkerAlreadyExistsException();
        }

        Workers.Add(new Worker(workerId, email, firstName, lastName, this));
        
       // AddEvent(new WorkerAddedEvent(workerId));
    }

    public void UpdateVolunteering(bool isDonationActive, string bankAccountNumber,
        string donationDescription, bool isDailyHelpActive, string dailyHelpDescription,
        bool isTakingDogsOutActive, string takingDogsOutDescription)
    {
        Volunteering = new Volunteering(isDonationActive, bankAccountNumber, donationDescription,
            isDailyHelpActive, dailyHelpDescription, isTakingDogsOutActive,
            takingDogsOutDescription, this);
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

    public void Update(OrganizationName organizationName, double longitude, double latitude,string city,string street,string zipCode, PhoneNumber phoneNumber,
        Krs krs,
        Nip nip)
    {
        Localization = new Localization(longitude, latitude,Id);
        OrganizationName = organizationName;
        Krs = krs;
        Nip = nip;
        PhoneNumber = phoneNumber;
        Street = street;
        City = city;
        ZipCode = zipCode;

        AddEvent(new ShelterUpdatedEvent(Id, organizationName, longitude, latitude,city,street,zipCode, krs, nip));
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
        
       // AddEvent(new WorkerRemovedEvent(workerId));
    }

    public void AddVolunteer(UserId userId)
    {
        var exists = Volunteers.Any(x => x.UserId == userId);

        if (exists)
        {
            throw new VolunteerAlreadyExistsException();
        }

        Volunteers.Add(new Volunteer(userId, this));
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
        _archives.Add(new Archive(petId, this));
    }
}