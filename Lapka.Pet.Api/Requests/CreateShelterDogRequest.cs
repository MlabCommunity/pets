using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateShelterDogRequest(string Name, string ProfilePhoto, Gender Gender, string Description,
    bool IsVisible, double Age, bool IsSterilized, double Weight,
    DogColor DogColor, DogBreed DogBreed, ICollection<string> Photos);