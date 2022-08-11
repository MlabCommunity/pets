using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public sealed class Cat : Pet
{
    public CatBreed Breed { get; private set; }
    public CatColor Color { get; private set; }

    private Cat()
    {
    }

    private Cat(OwnerId ownerId, string name, Gender gender,
        DateTime dateOfBirth, bool isSterilized, double weight, CatBreed breed, CatColor color) : base(
        ownerId,
        PetType.CAT, name, gender, isSterilized, weight)
    {
        Breed = breed;
        Color = color;
    }

    public static Cat Create(OwnerId ownerId, string name, Gender gender,
        DateTime dateOfBirth, bool isSterilized, double weight, CatBreed breed, CatColor color)
    {
        var cat = new Cat(ownerId, name, gender, dateOfBirth, isSterilized, weight, breed, color);
        cat.ChangeDateOfBirth(dateOfBirth);
        return cat;
    }
}