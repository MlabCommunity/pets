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

    private Cat(OwnerId ownerId, ProfilePhotoId profilePhotoId, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, CatBreed breed, CatColor color) : base(
        ownerId, profilePhotoId,
        PetType.CAT, name, gender, dateOfBirth, isSterilized, weight)
    {
        Breed = breed;
        Color = color;
    }

    public static Cat Create(OwnerId ownerId, ProfilePhotoId profilePhotoId, PetName name, Gender gender,
        DateOfBirth dateOfBirth, bool isSterilized, Weight weight, CatBreed breed, CatColor color,
        ICollection<Guid> photos)
    {
        var cat = new Cat(ownerId, profilePhotoId, name, gender, dateOfBirth, isSterilized, weight, breed, color);
        cat.AddPhotos(photos);
        return cat;
    }
}