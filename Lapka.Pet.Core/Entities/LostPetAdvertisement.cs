using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class LostPetAdvertisement : Advertisement
{
    public DateOfDisappearance DateOfDisappearance { get; private set; }

    public UserId UserId { get; private set; }
    public PetId PetId { get; private set; }

    private LostPetAdvertisement()
    {
    }

    public LostPetAdvertisement(string description, bool isVisible, DateOfDisappearance dateOfDisappearance,
        Localization localization, PetId petId,UserId userId) : base(description, isVisible,localization)
    {
        DateOfDisappearance = dateOfDisappearance;
        UserId = userId;
        PetId = petId;
    }
}