using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public sealed class Dog : Pet
{
    public DogBreed Breed { get; private set; }
    public DogColor Color { get; private set; }


    private Dog()
    {
    }

    private Dog(OwnerId ownerId, string name, Gender gender,
        DateTime dateOfBirth, bool isSterilized, double weight, DogBreed breed, DogColor color) : base(ownerId,
        PetType.DOG, name, gender, isSterilized, weight)
    {
        Breed = breed;
        Color = color;
    }

    public static Dog Create(OwnerId ownerId, string name, Gender gender,
        DateTime dateOfBirth, bool isSterilized, double weight, DogBreed breed, DogColor color)
    {
        //Domain event?
        var dog = new Dog(ownerId, name, gender, dateOfBirth, isSterilized, weight, breed, color);
        dog.ChangeDateOfBirth(dateOfBirth);
        return dog;
    }
}