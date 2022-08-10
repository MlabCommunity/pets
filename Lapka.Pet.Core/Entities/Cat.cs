using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class Cat : Pet
{
    private CatBreed _breed;
    private CatColor _color;

    private Cat()
    {
    }
    
    private Cat(OwnerId ownerId, string name, Gender gender, ICollection<PhotoId> photos,
        DateTime dateOfBirth, bool isSterilized, double weight, CatBreed breed, CatColor color) : base(ownerId,
        PetType.CAT, name, gender, photos, dateOfBirth, isSterilized, weight)
    {
        _breed = breed;
        _color = color;
    }

    public Cat Create(OwnerId ownerId, string name, Gender gender, ICollection<PhotoId> photos,
        DateTime dateOfBirth, bool isSterilized, double weight, CatBreed breed, CatColor color)
    {
        //Domain event
        //Walidacja
        return new Cat(ownerId, name, gender, photos, dateOfBirth, isSterilized, weight, breed, color);
    }
}