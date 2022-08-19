using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class Dog : Pet
{
    public DogBreed Breed { get; private set; }
    public DogColor Color { get; private set; }


    private Dog()
    {
    }

    private Dog(OwnerId ownerId, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, DogBreed breed, DogColor color) : base(ownerId,
        PetType.DOG, name, gender, dateOfBirth, isSterilized, weight)
    {
        Breed = breed;
        Color = color;
    }

    public static Dog Create(OwnerId ownerId, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, DogBreed breed, DogColor color)
    {
        var dog = new Dog(ownerId, name, gender, dateOfBirth, isSterilized, weight, breed, color);
        return dog;
    }
}