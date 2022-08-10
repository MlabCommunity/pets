using Lapka.Pet.Core.Domain;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class Shelter : AggregateRoot
{

    private string _street;
    private string _city;
    private string _zipCode;
    private string _organizationName;
    private Volunteering _volunteering;
    private ICollection<Volunteer> _volunteers;
    private string KRS;
    private string NIP;

    private Shelter()
    {
    }

    private Shelter( string street, string city, string zipCode, string organizationName,
        Volunteering volunteering, ICollection<Volunteer> volunteers, string krs, string nip)
    {
        _street = street;
        _city = city;
        _zipCode = zipCode;
        _organizationName = organizationName;
        _volunteering = volunteering;
        _volunteers = volunteers;
        KRS = krs;
        NIP = nip;
    }

    public static Shelter Create(string street, string city, string zipCode, string organizationName,
        ICollection<Volunteer> volunteers, string krs, string nip)
    {
        //walidacja eventy itp
        return new Shelter( street, city, zipCode, organizationName, new Volunteering(), volunteers, krs, nip);
    }

    //business logic agregatu

    public void Update(string organizationName, string street, string city, string zipCode, string krs, string nip)
    {
        _street = street;
        _city = city;
        _zipCode = zipCode;
        _organizationName = organizationName;
        KRS = krs;
        NIP = nip;
    }
}