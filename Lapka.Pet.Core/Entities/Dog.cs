using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class Dog : Pet
{
    private DogBreed _breed;
    private DogColor _color;

    
    private Dog()
    {
    }
    
    private Dog(OwnerId ownerId, string name, Gender gender, ICollection<PhotoId> photos,
        DateTime dateOfBirth, bool isSterilized, double weight, DogBreed breed, DogColor color) : base(ownerId,
        PetType.DOG, name, gender, photos, dateOfBirth, isSterilized, weight)
    {
        _breed = breed;
        _color = color;
    }

    public Dog Create(OwnerId ownerId, string name, Gender gender, ICollection<PhotoId> photos,
        DateTime dateOfBirth, bool isSterilized, double weight, DogBreed breed, DogColor color)
    {
        //Domain event
        //Walidacja?
        return new Dog(ownerId, name, gender, photos, dateOfBirth, isSterilized, weight, breed, color);
    }
    
    
    // metody wbogacające agregat
}