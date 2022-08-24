using System.Data;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class ShelterAdvertisement : Advertisement
{
    public PetId PetId { get; private set; }
    public Shelter Shelter { get; private set; }
    public ShelterId ShelterId { get; private set; }
    public OrganizationName OrganizationName { get; private set; }

    public bool IsReserved { get; private set; }

    private ShelterAdvertisement()
    {
    }

    public ShelterAdvertisement(OrganizationName organizationName, Localization localization,ShelterId shelterId,string description, bool isVisible, PetId petId) : base(description, isVisible,localization)
    {
        OrganizationName = organizationName;
        ShelterId = shelterId;
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
    
    
    public void UpdateShelterDetails(OrganizationName organizationName, Localization localization)
    {
        OrganizationName = organizationName;
        base.UpdateLocalization(localization);
    }
}