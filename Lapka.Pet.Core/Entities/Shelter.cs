using Lapka.Pet.Core.Domain;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public sealed class Shelter : AggregateRoot
{
    public string  OrganizationName { get; private set; }
    public ICollection<ShelterPet> ShelterPets { get; private set; }
    // private string _street;
    // private string _city;
    // private string _zipCode;
    // private Volunteering _volunteering;
    // private ICollection<Volunteer> _volunteers;
    // private string KRS;
    //  private string NIP;

    private Shelter()
    {
    }

    private Shelter(string organizationName)
    {
        Id = Guid.NewGuid();
        OrganizationName = organizationName;
    }

    // public static Shelter Create(string street, string city, string zipCode, string organizationName,
    //     ICollection<Volunteer> volunteers, string krs, string nip)
    // {
    //    AddEvent(new ShelterCreatedEvent(street, city, zipCode, organizationName));
    //     return new Shelter();
    // }

    //business logic agregatu

    // public void Update(string organizationName, string street, string city, string zipCode, string krs, string nip)
    // {
    //     _street = street;
    //     _city = city;
    //     _zipCode = zipCode;
    //     _organizationName = organizationName;
    //     KRS = krs;
    //     NIP = nip;
    //     
    //    // AddEvent(new ShelterUpdatedEvent(Id, organizationName, street, city, zipCode, krs, nip));
    // }

    //  public string GetLocalization()
    //    => $"{_street}, {_city}";
}