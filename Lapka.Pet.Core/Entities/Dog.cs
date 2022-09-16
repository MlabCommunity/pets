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

    private Dog(OwnerId ownerId,ProfilePhotoId profilePhotoId, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, DogBreed breed, DogColor color) : base(ownerId,
        profilePhotoId,PetType.DOG, name, gender, dateOfBirth, isSterilized, weight)
    {
        Breed = breed;
        Color = color;
    }

    public static Dog Create(OwnerId ownerId,ProfilePhotoId profilePhotoId, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, DogBreed breed, DogColor color,
        ICollection<Guid> photos)
    {
        var dog = new Dog(ownerId,profilePhotoId, name, gender, dateOfBirth, isSterilized, weight, breed, color);
        dog.AddPhotos(photos);
        return dog;
    }
}