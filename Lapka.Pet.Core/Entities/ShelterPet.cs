using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class ShelterPet : Pet
{
    public string Description { get; private set; }
    public OrganizationName OrganizationName { get; private set; }
    public bool IsVisible { get; private set; }
    public Localization Localization { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public ZipCode ZipCode { get; private set; }
    public Shelter Shelter { get; }
    public ShelterId ShelterId { get; }

    protected ShelterPet()
    {
    }

    public ShelterPet(OwnerId ownerId, ProfilePhoto profilePhoto, PetType type, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, string description,
        OrganizationName organizationName, bool isVisible, Longitude longitude, Latitude latitude, string city,
        string street, string zipCode,
        ICollection<string> photos, Shelter shelter) : base(ownerId,
        profilePhoto, type, name, gender, dateOfBirth, isSterilized, weight, photos)
    {
        Description = description;
        OrganizationName = organizationName;
        IsVisible = isVisible;
        Localization = new Localization(longitude, latitude, Id);
        Shelter = shelter;
        ShelterId = shelter.Id;
        City = city;
        Street = street;
        ZipCode = zipCode;
    }

    public void Publish()
    {
        IsVisible = true;
    }

    public void Hide()
    {
        IsVisible = false;
    }

    public void Update(string description, PetName petName, bool isSterilized, Weight weight, List<string> photos,
        bool isVisible)
    {
        Description = description;
        IsVisible = isVisible;
        base.Update(petName, isSterilized, weight, photos);
    }

    internal void UpdateShelterDetails(OrganizationName organizationName, double longitude, double latitude,
        string city, string street, string zipCode)
    {
        OrganizationName = organizationName;
        City = city;
        Street = street;
        ZipCode = zipCode;
        Localization = new Localization(longitude, latitude, Id);
    }
}