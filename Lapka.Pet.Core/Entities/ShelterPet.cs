using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class ShelterPet : Pet
{
    
    public string Description { get; private set; }
    public OrganizationName OrganizationName { get; private set; }
    public bool IsVisible { get; private set; }
    public Localization Localization { get; private set; }
    
    protected ShelterPet()
    {
    }

    public ShelterPet(OwnerId ownerId, ProfilePhoto profilePhoto, PetType type, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, string description,
        OrganizationName organizationName, bool isVisible, Longitude longitude, Latitude latitude,ICollection<string> photos) : base(ownerId,
        profilePhoto, type, name, gender, dateOfBirth, isSterilized, weight,photos)
    {
        Description = description;
        OrganizationName = organizationName;
        IsVisible = isVisible;
        Localization = new Localization(longitude, latitude);
    }

    public void Publish()
    {
        IsVisible = true;
    }

    public void Hide()
    {
        IsVisible = false;
    }

    public void Update(string description, PetName petName, bool isSterilized, Weight weight)
    {
        Description = description;
        base.Update(petName, isSterilized, weight);
    }

    public void UpdateShelterDetails(OrganizationName organizationName, double longitude, double latitude)
    {
        OrganizationName = organizationName;
        Localization = new Localization(longitude, latitude);
    }
}