using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class LostPetAdvertisement : Advertisement
{
    public DateOfDisappearance DateOfDisappearance { get; private set; }

    public UserId UserId { get; private set; }
    public PetId PetId { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }
    public FirstName FirstName { get; private set; }

    private LostPetAdvertisement()
    {
    }

    public LostPetAdvertisement(string description, PhoneNumber phoneNumber, FirstName firstName, bool isVisible,
        DateOfDisappearance dateOfDisappearance,
        Localization localization, PetId petId, UserId userId) : base(description, isVisible, localization)
    {
        FirstName = firstName;
        PhoneNumber = phoneNumber;
        DateOfDisappearance = dateOfDisappearance;
        UserId = userId;
        PetId = petId;
    }

    public void Update(string description, FirstName firstName, PhoneNumber phoneNumber)
    {
        FirstName = firstName;
        PhoneNumber = phoneNumber;

        base.Update(description);
    }
}