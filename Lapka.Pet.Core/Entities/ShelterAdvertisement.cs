using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class ShelterAdvertisement : Advertisement
{
    public PetId PetId { get; private set; }
    public Shelter Shelter { get; private set; }
    public OrganizationName OrganizationName { get; private set; }
    public string Localization { get; private set; }
    public bool IsReserved { get; private set; }

    private ShelterAdvertisement()
    {
    }

    public ShelterAdvertisement(OrganizationName organizationName, string localization,string description, bool isVisible, PetId petId) : base(description, isVisible)
    {
        OrganizationName = organizationName;
        Localization = localization;
        PetId = petId;
        IsReserved = false;
    }

    public void Reserve()
    {
        IsReserved = true;
    }

    public void UnReserve()
    {
        IsReserved = false;
    }
    
    public void UpdateShelterDetails(OrganizationName organizationName, string localization)
    {
        OrganizationName = organizationName;
        Localization = localization;
    }
}