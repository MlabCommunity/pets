using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class UserAdvertisement : Advertisement
{
    public DateOfDisappearance DateOfDisappearance { get; private set; }
    public string StreetOfDisappearance { get; private set; }
    public string CityOfDisappearance { get; private set; }
    public PetId PetId { get; private set; }

    private UserAdvertisement()
    {
    }

    public UserAdvertisement(string description, bool isVisible, DateOfDisappearance dateOfDisappearance, string streetOfDisappearance, string cityOfDisappearance, PetId petId) : base(description, isVisible)
    {
        DateOfDisappearance = dateOfDisappearance;
        StreetOfDisappearance = streetOfDisappearance;
        CityOfDisappearance = cityOfDisappearance;
        PetId = petId;
    }
    
    
}