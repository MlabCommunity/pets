using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class Dog : Pet
{
    public DogBreed Breed { get; private set; }
    public DogColor Color { get; private set; }


    private Dog()
    {
    }

    private Dog(OwnerId ownerId, ProfilePhoto profilePhoto, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, DogBreed breed, DogColor color,
        ICollection<string> photos) : base(ownerId,
        profilePhoto, PetType.DOG, name, gender, dateOfBirth, isSterilized, weight, photos)
    {
        Breed = breed;
        Color = color;
    }

    public static Dog Create(OwnerId ownerId, ProfilePhoto profilePhoto, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, DogBreed breed, DogColor color,
        ICollection<string> photos)
    {
        var dog = new Dog(ownerId, profilePhoto, name, gender, dateOfBirth, isSterilized, weight, breed, color, photos);
        return dog;
    }
}