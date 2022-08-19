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

    private Cat(OwnerId ownerId, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, CatBreed breed, CatColor color) : base(
        ownerId,
        PetType.CAT, name, gender, dateOfBirth, isSterilized, weight)
    {
        Breed = breed;
        Color = color;
    }

    public static Cat Create(OwnerId ownerId, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, CatBreed breed, CatColor color)
    {
        var cat = new Cat(ownerId, name, gender, dateOfBirth, isSterilized, weight, breed, color);
        return cat;
    }
}