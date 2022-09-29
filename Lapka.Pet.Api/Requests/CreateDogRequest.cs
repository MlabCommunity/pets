using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateDogRequest(string Name,string ProfilePhoto ,Gender Gender, DateTime DateOfBirth, bool IsSterilized, double Weight,
    DogColor DogColor, DogBreed DogBreed, ICollection<string> Photos);