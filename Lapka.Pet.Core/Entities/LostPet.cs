using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class LostPet : Pet
{
    public DateOfDisappearance DateOfDisappearance { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Localization Localization { get; private set; }
    public bool IsVisible { get; private set; }
    public FirstName FirstName { get; private set; }
    public string Description { get; private set; }

    protected LostPet()
    {
    }

    public LostPet(OwnerId ownerId, ProfilePhoto profilePhoto, PetType type, PetName name,
        Gender gender, DateOfBirth dateOfBirth, bool isSterilized, Weight weight,
        DateOfDisappearance dateOfDisappearance, PhoneNumber phoneNumber, Longitude longitude, Latitude latitude,
        bool isVisible, FirstName firstName, string description, ICollection<string> photos) : base(ownerId,
        profilePhoto, type, name, gender,
        dateOfBirth, isSterilized, weight, photos)
    {
        DateOfDisappearance = dateOfDisappearance;
        PhoneNumber = phoneNumber;
        Localization = new Localization(longitude, latitude,Id);
        IsVisible = isVisible;
        FirstName = firstName;
        Description = description;
    }

    public void Update(string description, FirstName firstName, PhoneNumber phoneNumber, PetName petName,
        bool isSterilized, Weight weight)
    {
        Description = description;
        FirstName = firstName;
        PhoneNumber = phoneNumber;

        base.Update(petName, isSterilized, weight);
    }
}