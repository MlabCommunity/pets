using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class Cat : Pet
{
    public CatBreed Breed { get; private set; }
    public CatColor Color { get; private set; }

    private Cat()
    {
    }

    private Cat(OwnerId ownerId, ProfilePhoto profilePhoto, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, CatBreed breed, CatColor color,ICollection<string> photos) : base(
        ownerId, profilePhoto,
        PetType.CAT, name, gender, dateOfBirth, isSterilized, weight,photos)
    {
        Breed = breed;
        Color = color;
    }

    public static Cat Create(OwnerId ownerId, ProfilePhoto profilePhoto, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, CatBreed breed, CatColor color,
        ICollection<string> photos)
    {
        var cat = new Cat(ownerId, profilePhoto, name, gender, dateOfBirth, isSterilized, weight, breed, color,photos);
        return cat;
    }
}