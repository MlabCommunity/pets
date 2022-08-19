using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Core.ValueObjects;

public class ShelterAdvertisement : Advertisement
{
    public PetId PetId { get; private set; }
    public Shelter Shelter { get; private set; }   
    public bool IsReserved { get; private set; }

    private ShelterAdvertisement()
    {
    }
    
    public ShelterAdvertisement(string description, bool isVisible, PetId petId) : base(description, isVisible)
    {
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
    
}